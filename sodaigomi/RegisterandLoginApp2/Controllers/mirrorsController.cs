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
    public class mirrorsController : Controller
    {
        private readonly RegisterandLoginApp2Context _context;

        public mirrorsController(RegisterandLoginApp2Context context)
        {
            _context = context;
        }

        // GET: mirrors
        public async Task<IActionResult> Index()
        {
            return View(await _context.mirror.ToListAsync());
        }

        // GET: mirrors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mirror = await _context.mirror
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mirror == null)
            {
                return NotFound();
            }

            return View(mirror);
        }

        // GET: mirrors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: mirrors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Location,TimeLimit,Contact,Price,Photo")] mirror mirror)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mirror);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mirror);
        }

        // GET: mirrors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mirror = await _context.mirror.FindAsync(id);
            if (mirror == null)
            {
                return NotFound();
            }
            return View(mirror);
        }

        // POST: mirrors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Location,TimeLimit,Contact,Price,Photo")] mirror mirror)
        {
            if (id != mirror.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mirror);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!mirrorExists(mirror.ID))
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
            return View(mirror);
        }

        // GET: mirrors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mirror = await _context.mirror
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mirror == null)
            {
                return NotFound();
            }

            return View(mirror);
        }

        // POST: mirrors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mirror = await _context.mirror.FindAsync(id);
            _context.mirror.Remove(mirror);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool mirrorExists(int id)
        {
            return _context.mirror.Any(e => e.ID == id);
        }
    }
}
