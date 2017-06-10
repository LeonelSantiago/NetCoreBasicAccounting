using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCoreBasicAccounting.Data.Entities;

namespace NetCoreBasicAccounting.Data._Core
{
    public class GeneralAccountingContext : IdentityDbContext
    {
        public GeneralAccountingContext(DbContextOptions<GeneralAccountingContext> options) : base(options)
        {
        }

        public DbSet<AccountingAccount> AccountingAccounts { get; set; }
        public DbSet<AccountingEntry> AccountingEntries { get; set; }
        public DbSet<AccountingParameter> AccountingParamenters { get; set; }
        public DbSet<AccountType> AccountingTypes { get; set; }
        public DbSet<Majorization> Majorizations { get; set; }
        public DbSet<MoneyCurrency> MoneyCurrencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountingAccount>().ToTable("AccountingAccount");
            modelBuilder.Entity<AccountingEntry>().ToTable("AccountingEntry");
            modelBuilder.Entity<AccountingParameter>().ToTable("AccountingParameter");
            modelBuilder.Entity<AccountType>().ToTable("AccountType");
            modelBuilder.Entity<Majorization>().ToTable("Majorization");
            modelBuilder.Entity<MoneyCurrency>().ToTable("MoneyCurrency");

        }
    }
}
