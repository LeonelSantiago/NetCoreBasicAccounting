using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCoreBasicAccounting.Models;
using NetCoreBasicAccounting.Data.Entities;

namespace NetCoreBasicAccounting.Data._Core
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<NetCoreBasicAccounting.Data.Entities.AccountingAccount> AccountingAccount { get; set; }

        public DbSet<NetCoreBasicAccounting.Data.Entities.AccountingParameter> AccountingParameter { get; set; }

        public DbSet<NetCoreBasicAccounting.Data.Entities.AccountType> AccountType { get; set; }

        public DbSet<NetCoreBasicAccounting.Data.Entities.Majorization> Majorization { get; set; }

        public DbSet<NetCoreBasicAccounting.Data.Entities.MoneyCurrency> MoneyCurrency { get; set; }

        public DbSet<NetCoreBasicAccounting.Data.Entities.AccountingEntry> AccountingEntry { get; set; }
    }
}
