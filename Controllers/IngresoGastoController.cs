using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlIngresoGasto.Data;
using ControlIngresoGasto.Models;

namespace ControlIngresoGasto.Controllers
{
    public class IngresoGastoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IngresoGastoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IngresoGasto
        public async Task<IActionResult> Index()
        {
            return View(await _context.IngresoGastos.ToListAsync());
        }

        // GET: IngresoGasto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingresoGasto = await _context.IngresoGastos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingresoGasto == null)
            {
                return NotFound();
            }

            return View(ingresoGasto);
        }

        // GET: IngresoGasto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IngresoGasto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoriaId,Fecha,Valor")] IngresoGasto ingresoGasto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingresoGasto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ingresoGasto);
        }

        // GET: IngresoGasto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingresoGasto = await _context.IngresoGastos.FindAsync(id);
            if (ingresoGasto == null)
            {
                return NotFound();
            }
            return View(ingresoGasto);
        }

        // POST: IngresoGasto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoriaId,Fecha,Valor")] IngresoGasto ingresoGasto)
        {
            if (id != ingresoGasto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingresoGasto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngresoGastoExists(ingresoGasto.Id))
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
            return View(ingresoGasto);
        }

        // GET: IngresoGasto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingresoGasto = await _context.IngresoGastos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingresoGasto == null)
            {
                return NotFound();
            }

            return View(ingresoGasto);
        }

        // POST: IngresoGasto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingresoGasto = await _context.IngresoGastos.FindAsync(id);
            _context.IngresoGastos.Remove(ingresoGasto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngresoGastoExists(int id)
        {
            return _context.IngresoGastos.Any(e => e.Id == id);
        }
    }
}
