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
    public class AccountTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountTypesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountType.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountType = await _context.AccountType
                .SingleOrDefaultAsync(m => m.ID == id);
            if (accountType == null)
            {
                return NotFound();
            }

            return View(accountType);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AccountType accountType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(accountType);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountType = await _context.AccountType.SingleOrDefaultAsync(m => m.ID == id);
            if (accountType == null)
            {
                return NotFound();
            }
            return View(accountType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  AccountType accountType)
        {
            if (id != accountType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountTypeExists(accountType.ID))
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
            return View(accountType);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountType = await _context.AccountType
                .SingleOrDefaultAsync(m => m.ID == id);
            if (accountType == null)
            {
                return NotFound();
            }

            return View(accountType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountType = await _context.AccountType.SingleOrDefaultAsync(m => m.ID == id);
            _context.AccountType.Remove(accountType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AccountTypeExists(int id)
        {
            return _context.AccountType.Any(e => e.ID == id);
        }
    }
}
