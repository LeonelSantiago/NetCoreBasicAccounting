using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreBasicAccounting.Data.Entities;
using NetCoreBasicAccounting.Data._Core;

namespace NetCoreBasicAccounting.Controllers
{
    public class MoneyCurrenciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoneyCurrenciesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.MoneyCurrency.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moneyCurrency = await _context.MoneyCurrency
                .SingleOrDefaultAsync(m => m.ID == id);
            if (moneyCurrency == null)
            {
                return NotFound();
            }

            return View(moneyCurrency);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MoneyCurrency moneyCurrency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moneyCurrency);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(moneyCurrency);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moneyCurrency = await _context.MoneyCurrency.SingleOrDefaultAsync(m => m.ID == id);
            if (moneyCurrency == null)
            {
                return NotFound();
            }
            return View(moneyCurrency);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MoneyCurrency moneyCurrency)
        {
            if (id != moneyCurrency.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moneyCurrency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoneyCurrencyExists(moneyCurrency.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(moneyCurrency);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moneyCurrency = await _context.MoneyCurrency
                .SingleOrDefaultAsync(m => m.ID == id);
            if (moneyCurrency == null)
            {
                return NotFound();
            }

            return View(moneyCurrency);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moneyCurrency = await _context.MoneyCurrency.SingleOrDefaultAsync(m => m.ID == id);
            _context.MoneyCurrency.Remove(moneyCurrency);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MoneyCurrencyExists(int id)
        {
            return _context.MoneyCurrency.Any(e => e.ID == id);
        }
    }
}
