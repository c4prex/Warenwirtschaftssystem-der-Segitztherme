using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Warenwritschaftssystem_der_Segitztherme.Data;
using Warenwritschaftssystem_der_Segitztherme.Models;

namespace Warenwritschaftssystem_der_Segitztherme.Controllers
{
    public class HUController : Controller
    {
        private readonly WarenwirtschaftContext _context;

        public HUController(WarenwirtschaftContext context)
        {
            _context = context;
        }

        // GET: HU
        public async Task<IActionResult> Index()
        {
            return View(await _context.HUs.ToListAsync());
        }

        // GET: HU/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hU = await _context.HUs
                .FirstOrDefaultAsync(m => m.HuId == id);
            if (hU == null)
            {
                return NotFound();
            }

            return View(hU);
        }

        // löschen von mehreren Eintrgeä
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSelected(int[] selectedIds)
        {
            if (selectedIds != null && selectedIds.Length > 0)
            {
                var hus = _context.HUs.Where(h => selectedIds.Contains(h.HuId));
                _context.HUs.RemoveRange(hus);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: HU/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HU/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HuId")] HU hU)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hU);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hU);
        }

        // GET: HU/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hU = await _context.HUs.FindAsync(id);
            if (hU == null)
            {
                return NotFound();
            }
            return View(hU);
        }

        // POST: HU/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HuId,ArtikelID,LagerID,GewichtHu,AnzahlArtikel")] HU hU)
        {
            if (id != hU.HuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hU);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HUExists(hU.HuId))
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
            return View(hU);
        }

        // GET: HU/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hU = await _context.HUs
                .FirstOrDefaultAsync(m => m.HuId == id);
            if (hU == null)
            {
                return NotFound();
            }

            return View(hU);
        }

        // POST: HU/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hU = await _context.HUs.FindAsync(id);
            if (hU != null)
            {
                _context.HUs.Remove(hU);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HUExists(int id)
        {
            return _context.HUs.Any(e => e.HuId == id);
        }
    }
}
