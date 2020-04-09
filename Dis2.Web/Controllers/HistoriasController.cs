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
    public class HistoriasController : Controller
    {
        private readonly DataContext _context;

        public HistoriasController(DataContext context)
        {
            _context = context;
        }

        // GET: Historias
        public async Task<IActionResult> Index()
        {
            return View(await _context.historias.ToListAsync());
        }

        // GET: Historias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historia = await _context.historias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historia == null)
            {
                return NotFound();
            }

            return View(historia);
        }

        // GET: Historias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Historias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Fecha,Detalle")] Historia historia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(historia);
        }

        // GET: Historias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historia = await _context.historias.FindAsync(id);
            if (historia == null)
            {
                return NotFound();
            }
            return View(historia);
        }

        // POST: Historias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Fecha,Detalle")] Historia historia)
        {
            if (id != historia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoriaExists(historia.Id))
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
            return View(historia);
        }

        // GET: Historias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historia = await _context.historias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historia == null)
            {
                return NotFound();
            }

            return View(historia);
        }

        // POST: Historias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historia = await _context.historias.FindAsync(id);
            _context.historias.Remove(historia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoriaExists(int id)
        {
            return _context.historias.Any(e => e.Id == id);
        }
    }
}
