#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegisterandLoginApp2.Data;
using RegisterandLoginApp2.Models;

namespace RegisterandLoginApp2.Controllers
{
    public class refrigeratorsController : Controller
    {
        private readonly RegisterandLoginApp2Context _context;

        public refrigeratorsController(RegisterandLoginApp2Context context)
        {
            _context = context;
        }

        // GET: refrigerators
        public async Task<IActionResult> Index()
        {
            return View(await _context.refrigerator.ToListAsync());
        }

        // GET: refrigerators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refrigerator = await _context.refrigerator
                .FirstOrDefaultAsync(m => m.ID == id);
            if (refrigerator == null)
            {
                return NotFound();
            }

            return View(refrigerator);
        }

        // GET: refrigerators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: refrigerators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Location,TimeLimit,Contact,Price,Photo")] refrigerator refrigerator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refrigerator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refrigerator);
        }

        // GET: refrigerators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refrigerator = await _context.refrigerator.FindAsync(id);
            if (refrigerator == null)
            {
                return NotFound();
            }
            return View(refrigerator);
        }

        // POST: refrigerators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Location,TimeLimit,Contact,Price,Photo")] refrigerator refrigerator)
        {
            if (id != refrigerator.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refrigerator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!refrigeratorExists(refrigerator.ID))
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
            return View(refrigerator);
        }

        // GET: refrigerators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refrigerator = await _context.refrigerator
                .FirstOrDefaultAsync(m => m.ID == id);
            if (refrigerator == null)
            {
                return NotFound();
            }

            return View(refrigerator);
        }

        // POST: refrigerators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var refrigerator = await _context.refrigerator.FindAsync(id);
            _context.refrigerator.Remove(refrigerator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool refrigeratorExists(int id)
        {
            return _context.refrigerator.Any(e => e.ID == id);
        }
    }
}
