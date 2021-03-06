﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dis2.Web.Data;
using Dis2.Web.Data.Entities;
using Dis2.Web.Models;
using Dis2.Web.Helpers;

namespace Dis2.Web.Controllers
{
    public class TitularsController : Controller
    {
        private readonly DataContext _context;
        private readonly IUsuarioHelper _usuarioHelper;

        public TitularsController(DataContext context, IUsuarioHelper usuarioHelper)
        {
            _context = context;
            _usuarioHelper = usuarioHelper;
        }

        // GET: Titulars
        public IActionResult Index()
        {
            return View(_context.titulars
                .Include(t => t.Usuario)
                .Include(t => t.Pacientes));
        }

        // GET: Titulars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titular = await _context.titulars
                .Include(t => t.Usuario)
                .Include(t => t.Pacientes)
                .ThenInclude(p => p.Historias)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (titular == null)
            {
                return NotFound();
            }

            return View(titular);
        }

        // GET: Titulars/Create
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
                    UserName = model.Username
                };

                var response = await _usuarioHelper.AddUsuarioAsync(usuario, model.Password);
                if (response.Succeeded)
                {
                    var usuarioDB = await _usuarioHelper.GetUsuarioByEmailAsync(model.Username);
                    await _usuarioHelper.AddUsuarioPorRolAsync(usuarioDB, "Cliente");

                    var titular = new Titular
                    {
                        Pacientes = new List<Paciente>(),
                        Usuario = usuarioDB
                    };

                    _context.titulars.Add(titular);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, response.Errors.FirstOrDefault().Description);
                
            }

            return View(model);
        }

        // GET: Titulars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titular = await _context.titulars.FindAsync(id);
            if (titular == null)
            {
                return NotFound();
            }
            return View(titular);
        }

        // POST: Titulars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Titular titular)
        {
            if (id != titular.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(titular);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TitularExists(titular.Id))
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
            return View(titular);
        }

        // GET: Titulars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titular = await _context.titulars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (titular == null)
            {
                return NotFound();
            }

            return View(titular);
        }

        // POST: Titulars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var titular = await _context.titulars.FindAsync(id);
            _context.titulars.Remove(titular);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TitularExists(int id)
        {
            return _context.titulars.Any(e => e.Id == id);
        }
    }
}
