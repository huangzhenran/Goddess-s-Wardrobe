using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Goddess_s_Wardrode1.Data;
using Goddess_s_Wardrode1.Models;

namespace Goddess_s_Wardrode1.Controllers
{
    public class ChineseCheongsamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChineseCheongsamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ChineseCheongsams
        public async Task<IActionResult> Index()
        {
            return View(await _context.ChineseCheongsams.ToListAsync());
        }

        // GET: ChineseCheongsams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chineseCheongsam = await _context.ChineseCheongsams
                .FirstOrDefaultAsync(m => m.ID == id);
            if (chineseCheongsam == null)
            {
                return NotFound();
            }

            return View(chineseCheongsam);
        }

        // GET: ChineseCheongsams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChineseCheongsams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Picture,ID,Name,Price")] ChineseCheongsam chineseCheongsam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chineseCheongsam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chineseCheongsam);
        }

        // GET: ChineseCheongsams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chineseCheongsam = await _context.ChineseCheongsams.FindAsync(id);
            if (chineseCheongsam == null)
            {
                return NotFound();
            }
            return View(chineseCheongsam);
        }

        // POST: ChineseCheongsams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Picture,ID,Name,Price")] ChineseCheongsam chineseCheongsam)
        {
            if (id != chineseCheongsam.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chineseCheongsam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChineseCheongsamExists(chineseCheongsam.ID))
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
            return View(chineseCheongsam);
        }

        // GET: ChineseCheongsams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chineseCheongsam = await _context.ChineseCheongsams
                .FirstOrDefaultAsync(m => m.ID == id);
            if (chineseCheongsam == null)
            {
                return NotFound();
            }

            return View(chineseCheongsam);
        }

        // POST: ChineseCheongsams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chineseCheongsam = await _context.ChineseCheongsams.FindAsync(id);
            _context.ChineseCheongsams.Remove(chineseCheongsam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChineseCheongsamExists(int id)
        {
            return _context.ChineseCheongsams.Any(e => e.ID == id);
        }
    }
}
