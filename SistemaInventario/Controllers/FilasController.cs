#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaInventario.Models.BD;

namespace SistemaInventario.Controllers
{
    public class FilasController : Controller
    {
        private readonly InventarioContext _context;

        public FilasController(InventarioContext context)
        {
            _context = context;
        }

        // GET: Filas
        public async Task<IActionResult> Index()
        {
            var inventarioContext = _context.Filas.Include(f => f.IdestanteNavigation);
            return View(await inventarioContext.ToListAsync());
        }

        // GET: Filas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fila = await _context.Filas
                .Include(f => f.IdestanteNavigation)
                .FirstOrDefaultAsync(m => m.Idfila == id);
            if (fila == null)
            {
                return NotFound();
            }

            return View(fila);
        }

        // GET: Filas/Create
        public IActionResult Create()
        {
            ViewData["Idestante"] = new SelectList(_context.Estantes, "Idestante", "Idestante");
            return View();
        }

        // POST: Filas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idfila,Nombre,Idestante")] Fila fila)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fila);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idestante"] = new SelectList(_context.Estantes, "Idestante", "Idestante", fila.Idestante);
            return View(fila);
        }

        // GET: Filas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fila = await _context.Filas.FindAsync(id);
            if (fila == null)
            {
                return NotFound();
            }
            ViewData["Idestante"] = new SelectList(_context.Estantes, "Idestante", "Idestante", fila.Idestante);
            return View(fila);
        }

        // POST: Filas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idfila,Nombre,Idestante")] Fila fila)
        {
            if (id != fila.Idfila)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fila);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilaExists(fila.Idfila))
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
            ViewData["Idestante"] = new SelectList(_context.Estantes, "Idestante", "Idestante", fila.Idestante);
            return View(fila);
        }

        // GET: Filas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fila = await _context.Filas
                .Include(f => f.IdestanteNavigation)
                .FirstOrDefaultAsync(m => m.Idfila == id);
            if (fila == null)
            {
                return NotFound();
            }

            return View(fila);
        }

        // POST: Filas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fila = await _context.Filas.FindAsync(id);
            _context.Filas.Remove(fila);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilaExists(int id)
        {
            return _context.Filas.Any(e => e.Idfila == id);
        }
    }
}
