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
    public class ItemStocksController : Controller
    {
        private readonly RegisterandLoginApp2Context _context;

        public ItemStocksController(RegisterandLoginApp2Context context)
        {
            _context = context;
        }

        // GET: ItemStocks
        public async Task<IActionResult> Index()
        {
            return View(await _context.ItemStock.ToListAsync());
        }

        // GET: ItemStocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemStock = await _context.ItemStock
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemStock == null)
            {
                return NotFound();
            }

            return View(itemStock);
        }

        // GET: ItemStocks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemStocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Location,TimeLimit,Contact,Price,Photo")] ItemStock itemStock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemStock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemStock);
        }

        // GET: ItemStocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemStock = await _context.ItemStock.FindAsync(id);
            if (itemStock == null)
            {
                return NotFound();
            }
            return View(itemStock);
        }

        // POST: ItemStocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Location,TimeLimit,Contact,Price,Photo")] ItemStock itemStock)
        {
            if (id != itemStock.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemStock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemStockExists(itemStock.ID))
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
            return View(itemStock);
        }

        // GET: ItemStocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemStock = await _context.ItemStock
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemStock == null)
            {
                return NotFound();
            }

            return View(itemStock);
        }

        // POST: ItemStocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemStock = await _context.ItemStock.FindAsync(id);
            _context.ItemStock.Remove(itemStock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemStockExists(int id)
        {
            return _context.ItemStock.Any(e => e.ID == id);
        }
    }
}
