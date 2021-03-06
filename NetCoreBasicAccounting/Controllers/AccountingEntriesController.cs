using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreBasicAccounting.Data.Entities;
using NetCoreBasicAccounting.Data.Enums;
using NetCoreBasicAccounting.Data._Core;
using Remotion.Linq.Clauses;

namespace NetCoreBasicAccounting.Controllers
{
    public class AccountingEntriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountingEntriesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<AccountingParameter> accountingParameters = _context.AccountingParameter;
            var accountingParametersProcessed = (
                from c in accountingParameters
                where c.ID == 1 select c.MajorizationProcessed.GetHashCode()).FirstOrDefault();

            ViewBag.AccountingParameterProccessed = accountingParametersProcessed;

            return View(await _context.AccountingEntry.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountingEntry = await _context.AccountingEntry
                .SingleOrDefaultAsync(m => m.ID == id);
            if (accountingEntry == null)
            {
                return NotFound();
            }

            return View(accountingEntry);
        }

        //public Task GetAccountsToCreditDropwDown(int accountToDebitId)
        //{
        //   return ViewBag.AccountingAccount = new SelectList(_context.AccountingAccount.Where(c => c.AllowsTransactions == 0  && c.ID != accountToDebitId), "ID", "Description");
        //}

        public async Task SetDropDowns()
        {
            ViewBag.AccountingAccount = new SelectList(_context.AccountingAccount.Where(c => c.AllowsTransactions == 0), "ID", "Description");
            ViewBag.MoneyCurrency = new SelectList(_context.MoneyCurrency, "ID", "Description");

        }

        public async Task<IActionResult> Create()
        {
           await SetDropDowns();
            return View();
        }

        public async Task AccountAmountUpdate(string accountId, int movementType, decimal entryAmount)
        {
            var accountingEntryAccount = await _context.AccountingAccount.SingleOrDefaultAsync(m => m.ID.ToString() == accountId );
            
            var higherAccount = await _context.AccountingAccount.SingleOrDefaultAsync(
                m => m.ID.ToString() == accountingEntryAccount.HigherAccount.ToString());

            if (movementType == 0)
            {
                accountingEntryAccount.Balance -= entryAmount;
                higherAccount.Balance -= entryAmount;
            }
            else
            {
                accountingEntryAccount.Balance = accountingEntryAccount.Balance + entryAmount;
                higherAccount.Balance = higherAccount.Balance + entryAmount;
            }
            _context.Update(accountingEntryAccount);
            _context.Update(higherAccount);
            await _context.SaveChangesAsync();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AccountingEntry accountingEntry)
        {
            accountingEntry.MoneyCurrencyRate = (from c in _context.MoneyCurrency
                                              where c.ID.ToString() == accountingEntry.MoneyCurrency.ToString()
                                              select c.LastExchangeRate).Single();

            accountingEntry.AccountToDebitDescription = (from c in _context.AccountingAccount
                where c.ID.ToString() == accountingEntry.AccountToDebit.ToString()
                select c.Description).Single();

            accountingEntry.AccountToCreditDescription = (from c in _context.AccountingAccount
                where c.ID.ToString() == accountingEntry.AccountToCredit.ToString()
                select c.Description).Single();

            accountingEntry.IsMajorizationProcessed = MajorizationProcessed.NotProcessed;

            if (ModelState.IsValid)
            {
                _context.Add(accountingEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(accountingEntry);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountingEntry = await _context.AccountingEntry.SingleOrDefaultAsync(m => m.ID == id);
            if (accountingEntry == null)
            {
                return NotFound();
            }
            return View(accountingEntry);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AccountingEntry accountingEntry)
        {
            if (id != accountingEntry.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountingEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountingEntryExists(accountingEntry.ID))
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
            return View(accountingEntry);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountingEntry = await _context.AccountingEntry
                .SingleOrDefaultAsync(m => m.ID == id);
            if (accountingEntry == null)
            {
                return NotFound();
            }

            return View(accountingEntry);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountingEntry = await _context.AccountingEntry.SingleOrDefaultAsync(m => m.ID == id);
            _context.AccountingEntry.Remove(accountingEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AccountingEntryExists(int id)
        {
            return _context.AccountingEntry.Any(e => e.ID == id);
        }
    }
}
