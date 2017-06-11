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
    public class MajorizationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MajorizationsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Majorization.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var majorization = await _context.Majorization
                .SingleOrDefaultAsync(m => m.ID == id);
            if (majorization == null)
            {
                return NotFound();
            }

            return View(majorization);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Majorization majorization)
        {
            if (ModelState.IsValid)
            {
                _context.Add(majorization);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(majorization);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var majorization = await _context.Majorization.SingleOrDefaultAsync(m => m.ID == id);
            if (majorization == null)
            {
                return NotFound();
            }
            return View(majorization);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Majorization majorization)
        {
            if (id != majorization.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(majorization);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MajorizationExists(majorization.ID))
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
            return View(majorization);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var majorization = await _context.Majorization
                .SingleOrDefaultAsync(m => m.ID == id);
            if (majorization == null)
            {
                return NotFound();
            }

            return View(majorization);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var majorization = await _context.Majorization.SingleOrDefaultAsync(m => m.ID == id);
            _context.Majorization.Remove(majorization);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MajorizationExists(int id)
        {
            return _context.Majorization.Any(e => e.ID == id);
        }
    }
}
