using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dis2.Web.Data;
using Dis2.Web.Data.Entities;

namespace Dis2.Web.Controllers
{
    public class TipoTratamientoesController : Controller
    {
        private readonly DataContext _context;

        public TipoTratamientoesController(DataContext context)
        {
            _context = context;
        }

        // GET: TipoTratamientoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.tipoTratamientos.ToListAsync());
        }

        // GET: TipoTratamientoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTratamiento = await _context.tipoTratamientos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoTratamiento == null)
            {
                return NotFound();
            }

            return View(tipoTratamiento);
        }

        // GET: TipoTratamientoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoTratamientoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] TipoTratamiento tipoTratamiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoTratamiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoTratamiento);
        }

        // GET: TipoTratamientoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTratamiento = await _context.tipoTratamientos.FindAsync(id);
            if (tipoTratamiento == null)
            {
                return NotFound();
            }
            return View(tipoTratamiento);
        }

        // POST: TipoTratamientoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] TipoTratamiento tipoTratamiento)
        {
            if (id != tipoTratamiento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoTratamiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoTratamientoExists(tipoTratamiento.Id))
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
            return View(tipoTratamiento);
        }

        // GET: TipoTratamientoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTratamiento = await _context.tipoTratamientos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoTratamiento == null)
            {
                return NotFound();
            }

            return View(tipoTratamiento);
        }

        // POST: TipoTratamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoTratamiento = await _context.tipoTratamientos.FindAsync(id);
            _context.tipoTratamientos.Remove(tipoTratamiento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoTratamientoExists(int id)
        {
            return _context.tipoTratamientos.Any(e => e.Id == id);
        }
    }
}
