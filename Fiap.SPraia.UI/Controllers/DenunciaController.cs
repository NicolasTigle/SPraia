using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fiap.SPraia.UI.Models;

namespace Fiap.SPraia.UI.Controllers
{
    public class DenunciaController : Controller
    {
        private readonly DenunciaContexto _context;

        public DenunciaController(DenunciaContexto context)
        {
            _context = context;
        }

        // GET: Denuncia
        public async Task<IActionResult> Index()
        {
              return _context.Denuncia != null ? 
                          View(await _context.Denuncia.ToListAsync()) :
                          Problem("Entity set 'DenunciaContexto.Denuncia'  is null.");
        }

        // GET: Denuncia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Denuncia == null)
            {
                return NotFound();
            }

            var denuncia = await _context.Denuncia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (denuncia == null)
            {
                return NotFound();
            }

            return View(denuncia);
        }

        // GET: Denuncia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Denuncia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Praia,Descricao,Status,DataCriacao")] Denuncia denuncia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(denuncia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(denuncia);
        }

        // GET: Denuncia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Denuncia == null)
            {
                return NotFound();
            }

            var denuncia = await _context.Denuncia.FindAsync(id);
            if (denuncia == null)
            {
                return NotFound();
            }
            return View(denuncia);
        }

        // POST: Denuncia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Praia,Descricao,Status,DataCriacao")] Denuncia denuncia)
        {
            if (id != denuncia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(denuncia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DenunciaExists(denuncia.Id))
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
            return View(denuncia);
        }

        // GET: Denuncia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Denuncia == null)
            {
                return NotFound();
            }

            var denuncia = await _context.Denuncia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (denuncia == null)
            {
                return NotFound();
            }

            return View(denuncia);
        }

        // POST: Denuncia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Denuncia == null)
            {
                return Problem("Entity set 'DenunciaContexto.Denuncia'  is null.");
            }
            var denuncia = await _context.Denuncia.FindAsync(id);
            if (denuncia != null)
            {
                _context.Denuncia.Remove(denuncia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DenunciaExists(int id)
        {
          return (_context.Denuncia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
