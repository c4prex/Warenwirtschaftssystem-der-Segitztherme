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
    public class LagerController : Controller
    {
        private readonly WarenwirtschaftContext _context;

        public LagerController(WarenwirtschaftContext context)
        {
            _context = context;
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LagerID,Beschreibung")] Lager lager)
        {
            if (ModelState.IsValid)
            {
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                try
                {
                    _context.Update(lager);
                    await _context.SaveChangesAsync();
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
