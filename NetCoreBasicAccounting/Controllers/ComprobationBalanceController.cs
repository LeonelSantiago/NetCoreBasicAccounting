//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using NetCoreBasicAccounting.Data.Entities;
//using NetCoreBasicAccounting.Data._Core;
//using NetCoreBasicAccounting.Models;

//namespace NetCoreBasicAccounting.Controllers
//{
//    public class ComprobationBalanceController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public ComprobationBalanceController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IActionResult> Index()
//        {
//            var accountingEntry = _context.AccountingEntry.ToList();
//            IEnumerable<ComprobationBalance> comprobationBalance = new List<ComprobationBalance>();
//            foreach (var item in accountingEntry)
//            {
//                comprobationBalance = new List<ComprobationBalance>
//                {
//                    AccountToCredit = item.AccountToCredit,
//                    AccountToCreditDescription = item.AccountToCreditDescription,
//                    AmountToCredit =  item.AmountToCredit,
//                    AccountToDebit = item.AccountToDebit,
//                    AccountToDebitDescription = item.AccountToDebitDescription,
//                    AmountToDebit = item.AmountToDebit
//                };
//                //comprobationBalance.AccountToCredit = item.AccountToCredit;
//                //comprobationBalance.AccountToCreditDescription = item.AccountToCreditDescription;
//                //comprobationBalance.AmountToCredit = item.AmountToCredit;
//                //comprobationBalance.AccountToDebit = item.AccountToDebit;
//                //comprobationBalance.AccountToDebitDescription = item.AccountToDebitDescription;
//                //comprobationBalance.AmountToDebit = item.AmountToDebit;
//            }
//            return View(comprobationBalance);
//        }
//    }
//}