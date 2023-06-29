using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiThiPTH.Models;

namespace BaiThiPTH.Controllers
{
    public class PTHCau3Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public PTHCau3Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PTHCau3
        public async Task<IActionResult> Index()
        {
              return _context.PTHCau3 != null ? 
                          View(await _context.PTHCau3.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PTHCau3'  is null.");
        }

        // GET: PTHCau3/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PTHCau3 == null)
            {
                return NotFound();
            }

            var pTHCau3 = await _context.PTHCau3
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pTHCau3 == null)
            {
                return NotFound();
            }

            return View(pTHCau3);
        }

        // GET: PTHCau3/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PTHCau3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameSV,Age")] PTHCau3 pTHCau3)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pTHCau3);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pTHCau3);
        }

        // GET: PTHCau3/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PTHCau3 == null)
            {
                return NotFound();
            }

            var pTHCau3 = await _context.PTHCau3.FindAsync(id);
            if (pTHCau3 == null)
            {
                return NotFound();
            }
            return View(pTHCau3);
        }

        // POST: PTHCau3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,NameSV,Age")] PTHCau3 pTHCau3)
        {
            if (id != pTHCau3.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pTHCau3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PTHCau3Exists(pTHCau3.Id))
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
            return View(pTHCau3);
        }

        // GET: PTHCau3/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PTHCau3 == null)
            {
                return NotFound();
            }

            var pTHCau3 = await _context.PTHCau3
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pTHCau3 == null)
            {
                return NotFound();
            }

            return View(pTHCau3);
        }

        // POST: PTHCau3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.PTHCau3 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PTHCau3'  is null.");
            }
            var pTHCau3 = await _context.PTHCau3.FindAsync(id);
            if (pTHCau3 != null)
            {
                _context.PTHCau3.Remove(pTHCau3);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PTHCau3Exists(int? id)
        {
          return (_context.PTHCau3?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
