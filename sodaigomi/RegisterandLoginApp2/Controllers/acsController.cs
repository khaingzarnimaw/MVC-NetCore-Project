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
    public class acsController : Controller
    {
        private readonly RegisterandLoginApp2Context _context;

        public acsController(RegisterandLoginApp2Context context)
        {
            _context = context;
        }

        // GET: acs
        public async Task<IActionResult> Index()
        {
            return View(await _context.ac.ToListAsync());
        }

        // GET: acs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ac = await _context.ac
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ac == null)
            {
                return NotFound();
            }

            return View(ac);
        }

        // GET: acs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: acs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Location,TimeLimit,Contact,Price,Photo")] ac ac)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ac);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ac);
        }

        // GET: acs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ac = await _context.ac.FindAsync(id);
            if (ac == null)
            {
                return NotFound();
            }
            return View(ac);
        }

        // POST: acs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Location,TimeLimit,Contact,Price,Photo")] ac ac)
        {
            if (id != ac.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!acExists(ac.ID))
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
            return View(ac);
        }

        // GET: acs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ac = await _context.ac
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ac == null)
            {
                return NotFound();
            }

            return View(ac);
        }

        // POST: acs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ac = await _context.ac.FindAsync(id);
            _context.ac.Remove(ac);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool acExists(int id)
        {
            return _context.ac.Any(e => e.ID == id);
        }
    }
}
