using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lagersystem.Models;
using Lagersystem.Data;

namespace Lagersystem.Controllers
{
    public class LagerplatzController : Controller
    {
        private readonly WarenwirtschaftContext _context;

        public LagerplatzController(WarenwirtschaftContext context)
        {
            _context = context;
        }

        // GET: Lagerplatz
        public async Task<IActionResult> Index(string suchString)
        {
            var lagerplaetze = _context.Lagerplaetze.AsQueryable();

            if (!string.IsNullOrWhiteSpace(suchString))
            {
                lagerplaetze = lagerplaetze
                    .Where(lp => lp.LagerPlatzName.Contains(suchString));
            }
            else
            {
                suchString = string.Empty;
            }

            ViewData["CurrentFilter"] = suchString;

            return View(await lagerplaetze.ToListAsync());
        }



        // GET: Lagerplatz/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lagerplatz = await _context.Lagerplaetze
                .FirstOrDefaultAsync(m => m.LagerPlatzID == id);
            if (lagerplatz == null)
            {
                return NotFound();
            }

            return View(lagerplatz);
        }

        // GET: Lagerplatz/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lagerplatz/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LagerPlatzID,LagerPlatzName,LagerID,HUAnzahl,MaxGewicht,LagerBereich,LagerTyp")] Lagerplatz lagerplatz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lagerplatz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lagerplatz);
        }

        // GET: Lagerplatz/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lagerplatz = await _context.Lagerplaetze.FindAsync(id);
            if (lagerplatz == null)
            {
                return NotFound();
            }
            return View(lagerplatz);
        }

        // POST: Lagerplatz/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LagerPlatzID,LagerPlatzName,LagerID,HUAnzahl,MaxGewicht,LagerBereich,LagerTyp")] Lagerplatz lagerplatz)
        {
            if (id != lagerplatz.LagerPlatzID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lagerplatz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LagerplatzExists(lagerplatz.LagerPlatzID))
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
            return View(lagerplatz);
        }

        // GET: Lagerplatz/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lagerplatz = await _context.Lagerplaetze
                .FirstOrDefaultAsync(m => m.LagerPlatzID == id);
            if (lagerplatz == null)
            {
                return NotFound();
            }

            return View(lagerplatz);
        }

        // POST: Lagerplatz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lagerplatz = await _context.Lagerplaetze.FindAsync(id);
            if (lagerplatz != null)
            {
                _context.Lagerplaetze.Remove(lagerplatz);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LagerplatzExists(int id)
        {
            return _context.Lagerplaetze.Any(e => e.LagerPlatzID == id);
        }
    }
}
