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
    public class AccountingParametersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountingParametersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: AccountingParameters
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountingParameter.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountingParameter = await _context.AccountingParameter
                .SingleOrDefaultAsync(m => m.ID == id);
            if (accountingParameter == null)
            {
                return NotFound();
            }

            return View(accountingParameter);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AccountingParameter accountingParameter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountingParameter);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(accountingParameter);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountingParameter = await _context.AccountingParameter.SingleOrDefaultAsync(m => m.ID == id);
            if (accountingParameter == null)
            {
                return NotFound();
            }
            return View(accountingParameter);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AccountingParameter accountingParameter)
        {
            if (id != accountingParameter.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountingParameter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountingParameterExists(accountingParameter.ID))
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
            return View(accountingParameter);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountingParameter = await _context.AccountingParameter
                .SingleOrDefaultAsync(m => m.ID == id);
            if (accountingParameter == null)
            {
                return NotFound();
            }

            return View(accountingParameter);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountingParameter = await _context.AccountingParameter.SingleOrDefaultAsync(m => m.ID == id);
            _context.AccountingParameter.Remove(accountingParameter);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AccountingParameterExists(int id)
        {
            return _context.AccountingParameter.Any(e => e.ID == id);
        }
    }
}
