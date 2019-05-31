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
    public class FashionWomenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FashionWomenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FashionWomen
        public async Task<IActionResult> Index()
        {
            return View(await _context.FashionWomens.ToListAsync());
        }

        // GET: FashionWomen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fashionWomen = await _context.FashionWomens
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fashionWomen == null)
            {
                return NotFound();
            }

            return View(fashionWomen);
        }

        // GET: FashionWomen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FashionWomen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Picture,ID,Name,Price")] FashionWomen fashionWomen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fashionWomen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fashionWomen);
        }

        // GET: FashionWomen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fashionWomen = await _context.FashionWomens.FindAsync(id);
            if (fashionWomen == null)
            {
                return NotFound();
            }
            return View(fashionWomen);
        }

        // POST: FashionWomen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Picture,ID,Name,Price")] FashionWomen fashionWomen)
        {
            if (id != fashionWomen.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fashionWomen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FashionWomenExists(fashionWomen.ID))
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
            return View(fashionWomen);
        }

        // GET: FashionWomen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fashionWomen = await _context.FashionWomens
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fashionWomen == null)
            {
                return NotFound();
            }

            return View(fashionWomen);
        }

        // POST: FashionWomen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fashionWomen = await _context.FashionWomens.FindAsync(id);
            _context.FashionWomens.Remove(fashionWomen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FashionWomenExists(int id)
        {
            return _context.FashionWomens.Any(e => e.ID == id);
        }
    }
}
