using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Warenwritschaftssystem_der_Segitztherme.Data;
using Warenwritschaftssystem_der_Segitztherme.Models;

namespace Warenwritschaftssystem_der_Segitztherme.Controllers
{
    public class LagerController : Controller
    {
        private readonly WarenwirtschaftContext _context;

        public LagerController(WarenwirtschaftContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> DeleteSelection(List<int> selectRow)
        {
            if (selectRow == null || !selectRow.Any())
            {
                return BadRequest("Keine IDs angegeben.");
            }

            var lagerItems = await _context.Lager.Where(l => selectRow.Contains(l.LagerID)).ToListAsync();

            if (!lagerItems.Any())
            {
                return NotFound("Keine passenden Datensätze gefunden.");
            }

            _context.Lager.RemoveRange(lagerItems);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

  
        // GET: Lager
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lager.ToListAsync());
        }

        // GET: Lager/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lager = await _context.Lager
                .FirstOrDefaultAsync(m => m.LagerID == id);
            if (lager == null)
            {
                return NotFound();
            }

            return View(lager);
        }

        // GET: Lager/Create
        public IActionResult Create()
        {
            return View();
        }



        // POST: Lager/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LagerID,Beschreibung")] Lager lager)
        {           
            if (ModelState.IsValid)
            {
                // Prüfe ob Lager mit gleichem Namen bereits existiert
                var existiert = await _context.Lager.AnyAsync(l => l.Beschreibung.ToLower() == lager.Beschreibung.ToLower());
                if (existiert)
                {
                    ModelState.AddModelError("Beschreibung", "Ein Lager mit diesem Name existiert bereits.");
                    return View(lager);
                }

                _context.Add(lager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lager);
        }

        // GET: Lager/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lager = await _context.Lager.FindAsync(id);
            if (lager == null)
            {
                return NotFound();
            }
            return View(lager);
        }

        // POST: Lager/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LagerID,Beschreibung")] Lager lager)
        {
            if (id != lager.LagerID)
            {
                return NotFound();
            }            
            
            if (ModelState.IsValid)
            {
                // Prüfe ob ein ANDERES Lager mit gleichem Namen bereits existiert
                var existiert = await _context.Lager
                    .AnyAsync(l => l.Beschreibung.ToLower() == lager.Beschreibung.ToLower()
                                && l.LagerID != lager.LagerID);

                if (existiert)
                {
                    ModelState.AddModelError("Beschreibung", "Ein Lager mit diesem Name existiert bereits.");
                    return View(lager);
                }
                try
                {
                    _context.Update(lager);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Lager wurde erfolgreich aktualisiert!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LagerExists(lager.LagerID))
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
            return View(lager);
        }

        // GET: Lager/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lager = await _context.Lager
                .FirstOrDefaultAsync(m => m.LagerID == id);
            if (lager == null)
            {
                return NotFound();
            }

            return View(lager);
        }

        // POST: Lager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lager = await _context.Lager.FindAsync(id);
            if (lager != null)
            {
                _context.Lager.Remove(lager);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LagerExists(int id)
        {
            return _context.Lager.Any(e => e.LagerID == id);
        }

    }
}
