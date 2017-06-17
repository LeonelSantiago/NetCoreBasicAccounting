using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreBasicAccounting.Data._Core;
using NetCoreBasicAccounting.Models;

namespace NetCoreBasicAccounting.Controllers
{
    public class ComprobationBalanceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComprobationBalanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var accountingEnry = from c in _context.AccountingEntry select c;
            var comprobationBalance = _context.ComprobationBalances;
            foreach (var item in accountingEnry)
            {
                comprobationBalance
            }


        }
    }
}