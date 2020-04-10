using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dis2.Web.Data;
using Dis2.Web.Data.Entities;
using Dis2.Web.Helpers;
using Dis2.Web.Models;

namespace Dis2.Web.Controllers
{
    public class PacientesController : Controller
    {
        private readonly DataContext _context;
        private readonly IUsuarioHelper _usuarioHelper;

        public PacientesController(DataContext context, IUsuarioHelper usuarioHelper)
        {
            _context = context;
            _usuarioHelper = usuarioHelper;
        }

        // GET: Pacientes
        public IActionResult Index()
        {
            return View(_context.pacientes
                .Include(p => p.Titular)
                .Include(p => p.Historias));
        }

        // GET: Pacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.pacientes
                .Include(p => p.Titular)
                .Include(p => p.Historias)
                .ThenInclude(h => h.Especialista)
                .Include(p => p.Titular)
                .ThenInclude(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AgregarUsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    Direccion = model.Direccion,
                    Identificacion = model.Identificacion,
                    Nombres = model.Nombres,
                    Apellidos = model.Apellidos,
                    Email = model.Username,
                    PhoneNumber = model.PhoneNumber,
                    Estado = model.Estado,
                    FechaNacimiento = model.FechaNacimientoLocal,
                    UserName = model.Username
                };

                var response = await _usuarioHelper.AddUsuarioAsync(usuario, model.Password);
                if (response.Succeeded)
                {
                    var usuarioDB = await _usuarioHelper.GetUsuarioByEmailAsync(model.Username);
                    await _usuarioHelper.AddUsuarioPorRolAsync(usuarioDB, "Cliente");

                    var paciente = new Paciente
                    {
                        Historias = new List<Historia>(),
                        Usuario = usuarioDB
                    };

                    _context.pacientes.Add(paciente);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, response.Errors.FirstOrDefault().Description);
            }
            return View(model);
        }

        // GET: Pacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaNacimiento")] Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.pacientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paciente = await _context.pacientes.FindAsync(id);
            _context.pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(int id)
        {
            return _context.pacientes.Any(e => e.Id == id);
        }
    }
}
