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
            IEnumerable<ComprobationBalance> comprobationBalance = new List<ComprobationBalance>().AsQueryable();
            using (_context)
            {
             var query = @"SELECT
                e.[AccountID]
	            , a.[Description]
                ,SUM(e.[AccountingSeatAmount]) as AccountAmount
	            , CASE e.MovementType 
		        WHEN 0 THEN 'DEBITO'
		        WHEN 1 THEN 'CREDITO'
		      END as 'MovementTypeDescription'
              FROM [aspnet-NetCoreBasicAccounting-21aff577-0fc2-4b44-8efa-8d6d6cb955f5].[dbo].[AccountingEntry] e,
              [aspnet-NetCoreBasicAccounting-21aff577-0fc2-4b44-8efa-8d6d6cb955f5].[dbo].[AccountingAccount] a
              WHERE e.AccountID = a.ID
              GROUP BY e.AccountID, a.Description, e.MovementType";
                 comprobationBalance = _context.ComprobationBalances.FromSql(query).ToList();
            }

          
            return View(comprobationBalance);
        }
    }
}