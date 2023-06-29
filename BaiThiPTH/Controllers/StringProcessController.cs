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
    public class StringProcessController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StringProcessController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StringProcess
        public async Task<IActionResult> Index()
        {
              return _context.StringProcess != null ? 
                          View(await _context.StringProcess.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.StringProcess'  is null.");
        }

        // GET: StringProcess/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StringProcess == null)
            {
                return NotFound();
            }

            var stringProcess = await _context.StringProcess
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stringProcess == null)
            {
                return NotFound();
            }

            return View(stringProcess);
        }

        // GET: StringProcess/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StringProcess/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Address")] StringProcess stringProcess)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stringProcess);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stringProcess);
        }

        // GET: StringProcess/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StringProcess == null)
            {
                return NotFound();
            }

            var stringProcess = await _context.StringProcess.FindAsync(id);
            if (stringProcess == null)
            {
                return NotFound();
            }
            return View(stringProcess);
        }

        // POST: StringProcess/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Address")] StringProcess stringProcess)
        {
            if (id != stringProcess.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stringProcess);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StringProcessExists(stringProcess.ID))
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
            return View(stringProcess);
        }

        // GET: StringProcess/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StringProcess == null)
            {
                return NotFound();
            }

            var stringProcess = await _context.StringProcess
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stringProcess == null)
            {
                return NotFound();
            }

            return View(stringProcess);
        }

        // POST: StringProcess/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StringProcess == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StringProcess'  is null.");
            }
            var stringProcess = await _context.StringProcess.FindAsync(id);
            if (stringProcess != null)
            {
                _context.StringProcess.Remove(stringProcess);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StringProcessExists(int id)
        {
          return (_context.StringProcess?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
