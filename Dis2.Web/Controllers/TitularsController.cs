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
    public class TitularsController : Controller
    {
        private readonly DataContext _context;

        public TitularsController(DataContext context)
        {
            _context = context;
        }

        // GET: Titulars
        public async Task<IActionResult> Index()
        {
            return View(await _context.titulars.ToListAsync());
        }

        // GET: Titulars/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Titulars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Titulars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Identificacion,Nombres,Apellidos,Telefono,Direccion")] Titular titular)
        {
            if (ModelState.IsValid)
            {
                _context.Add(titular);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(titular);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Identificacion,Nombres,Apellidos,Telefono,Direccion")] Titular titular)
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
