using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreBasicAccounting.Data.Entities;
using NetCoreBasicAccounting.Data.Enums;
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

        public async Task<IActionResult> AccountEntryMajorization(int accountryEntryId)
        {
            var accountingEntry = _context.AccountingEntry.SingleOrDefault(m => m.ID == accountryEntryId);
            var majorization = new Majorization();
            majorization.AccountingEntryId = accountryEntryId;
            majorization.AccountToDebit = accountingEntry.AccountToDebit;
            var accountToDebitHigherAccount = (from c in _context.AccountingAccount
                where c.ID == accountingEntry.AccountToDebit
                select c.HigherAccount).Single();
            majorization.AccountToDebitHigherAccount = accountToDebitHigherAccount;
            majorization.AmountToDebit = accountingEntry.AmountToDebit * accountingEntry.MoneyCurrencyRate;
            majorization.AccountToCredit = accountingEntry.AccountToCredit;
            var accountToCreditHigherAccount = (from c in _context.AccountingAccount
                where c.ID == accountingEntry.AccountToDebit
                select c.HigherAccount).Single();
            majorization.AccountToCreditHigherAccount = accountToCreditHigherAccount;
            majorization.AmountToCredit = accountingEntry.AmountToCredit * accountingEntry.MoneyCurrencyRate;
            majorization.ProcessDate = DateTime.Now;
            majorization.Balance = accountingEntry.AmountToCredit * accountingEntry.MoneyCurrencyRate;

            return View(majorization);
        }

        [HttpPost]
        public async Task<IActionResult> AccountEntryMajorization(Majorization majorization)
        {

            //Getting of accounting Entry by ID
            var accountingEntry = await _context.AccountingEntry
                .SingleOrDefaultAsync( m => m.ID.ToString() == majorization.AccountingEntryId.ToString());
            accountingEntry.IsMajorizationProcessed = 0;
            //Getting of Account to Debit by ID
            var accountToDebit =
                await _context.AccountingAccount.SingleOrDefaultAsync(
                    m => m.ID.ToString() == majorization.AccountToDebit.ToString());
            //Getting of Account to Credit by ID
            var accountToCredit =
                await _context.AccountingAccount.SingleOrDefaultAsync(
                    m => m.ID.ToString() == majorization.AccountToCredit.ToString());
            //Getting of Higher Debit Account by Id
            var higherDebitAccount = await _context.AccountingAccount
                .SingleOrDefaultAsync(m => m.ID.ToString() == majorization.AccountToDebitHigherAccount.ToString());
            var higherCreditAccount = await _context.AccountingAccount
                .SingleOrDefaultAsync(m => m.ID.ToString() == majorization.AccountToCreditHigherAccount.ToString());


            //If the Higher Debit Account is not level one you need to find the higher account of it
            if (higherDebitAccount.Level == AccountLevels.LevelTwo)
            {
                var higherDebitAccountLevelOne = await _context.AccountingAccount
                    .SingleOrDefaultAsync(m => m.ID.ToString() == higherDebitAccount.ID.ToString());
                accountToDebit.Balance -= majorization.AmountToDebit;
                _context.Update(higherDebitAccountLevelOne);
                _context.Update(accountToDebit);
                await _context.SaveChangesAsync();
            }
            else
            {
                accountToDebit.Balance -= majorization.AmountToDebit;
                _context.Update(accountToDebit);
                await _context.SaveChangesAsync();
            }

            //If the Higher Credit Account is not level one you need to find the higher account of it
            if (higherCreditAccount.Level == AccountLevels.LevelTwo)
            {
                var higherCreditAccountLevelOne = await _context.AccountingAccount
                    .SingleOrDefaultAsync(m => m.ID.ToString() == higherCreditAccount.ID.ToString());
                accountToCredit.Balance -= majorization.AmountToCredit;
                _context.Update(higherCreditAccountLevelOne);
                _context.Update(accountToCredit);
                await _context.SaveChangesAsync();
            }
            else
            {
                accountToCredit.Balance -= majorization.AmountToCredit;
                _context.Update(accountToCredit);
                await _context.SaveChangesAsync();
            }
            _context.Update(accountingEntry);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "AccountingEntries");
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
