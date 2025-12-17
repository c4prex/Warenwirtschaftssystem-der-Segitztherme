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
            // Prüfe ob Lager existieren
            var lagerExist = await _context.Lager.AnyAsync();
            ViewBag.LagerExist = lagerExist;

            if (!lagerExist)
            {
                return View(new List<Lagerplatz>()); // Leere Liste zurückgeben
            }

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
        public async Task<IActionResult> Create()
        {
            // Prüfe ob Lager existieren
            var lagerExist = await _context.Lager.AnyAsync();
            if (!lagerExist)
            {
                TempData["ErrorMessage"] = "Bitte legen Sie zuerst ein Lager an, bevor Sie Lagerplätze erstellen.";
                return RedirectToAction("Index");
            }

            // Lade Lager für Dropdown
            ViewBag.LagerListe = new SelectList(await _context.Lager.ToListAsync(), "LagerID", "Beschreibung");
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
                TempData["SuccessMessage"] = $"Lagerplatz '{lagerplatz.LagerPlatzName}' wurde erfolgreich angelegt!";
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

            // Lade Lager für Dropdown
            ViewBag.LagerListe = new SelectList(await _context.Lager.ToListAsync(), "LagerID", "Beschreibung", lagerplatz.LagerID);

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
                    TempData["SuccessMessage"] = "Lagerplatz wurde erfolgreich aktualisiert!";
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
