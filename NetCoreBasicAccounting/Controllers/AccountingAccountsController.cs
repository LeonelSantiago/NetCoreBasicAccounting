using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreBasicAccounting.Data.Entities;
using NetCoreBasicAccounting.Data._Core;

namespace NetCoreBasicAccounting.Controllers
{
    public class AccountingAccountsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountingAccountsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountingAccount.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountingAccount = await _context.AccountingAccount
                .SingleOrDefaultAsync(m => m.ID == id);
            if (accountingAccount == null)
            {
                return NotFound();
            }

            return View(accountingAccount);
        }

        public IActionResult Create()
        {
            ViewBag.HigherAccounts = new SelectList(_context.AccountingAccount, "ID", "Description");
            ViewBag.AccountsType = new SelectList(_context.AccountType, "ID", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AccountingAccount accountingAccount, IFormCollection form)
        {
            var accountType = form["AccountType"];
            accountingAccount.AccountType = (from c in _context.AccountType
                where c.ID.ToString() == accountType.ToString()
                select c).Single();

            if (ModelState.IsValid)
            {
                _context.Add(accountingAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(accountingAccount);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.HigherAccounts = new SelectList(_context.AccountingAccount, "ID", "Description");
            ViewBag.AccountsType = new SelectList(_context.AccountType, "ID", "Description");

            if (id == null)
            {
                return NotFound();
            }

            var accountingAccount = await _context.AccountingAccount.SingleOrDefaultAsync(m => m.ID == id);
            if (accountingAccount == null)
            {
                return NotFound();
            }
            return View(accountingAccount);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AccountingAccount accountingAccount, IFormCollection form)
        {
            var accountType = form["AccountType"];
            accountingAccount.AccountType = (from c in _context.AccountType
                where c.ID.ToString() == accountType.ToString()
                select c).Single();

            if (id != accountingAccount.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountingAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountingAccountExists(accountingAccount.ID))
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
            return View(accountingAccount);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountingAccount = await _context.AccountingAccount
                .SingleOrDefaultAsync(m => m.ID == id);
            if (accountingAccount == null)
            {
                return NotFound();
            }

            return View(accountingAccount);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountingAccount = await _context.AccountingAccount.SingleOrDefaultAsync(m => m.ID == id);
            _context.AccountingAccount.Remove(accountingAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AccountingAccountExists(int id)
        {
            return _context.AccountingAccount.Any(e => e.ID == id);
        }
    }
}
