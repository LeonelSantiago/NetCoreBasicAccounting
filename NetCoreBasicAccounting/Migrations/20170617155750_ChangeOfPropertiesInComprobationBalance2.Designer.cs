using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NetCoreBasicAccounting.Data._Core;
using NetCoreBasicAccounting.Data.Enums;

namespace NetCoreBasicAccounting.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170617155750_ChangeOfPropertiesInComprobationBalance2")]
    partial class ChangeOfPropertiesInComprobationBalance2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("NetCoreBasicAccounting.Data.Entities.AccountingAccount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountTypeID");

                    b.Property<int>("AllowsTransactions");

                    b.Property<decimal>("Balance");

                    b.Property<string>("Description");

                    b.Property<int>("HigherAccount");

                    b.Property<int>("Level");

                    b.Property<int>("Status");

                    b.HasKey("ID");

                    b.HasIndex("AccountTypeID");

                    b.ToTable("AccountingAccount");
                });

            modelBuilder.Entity("NetCoreBasicAccounting.Data.Entities.AccountingEntry", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountToCredit");

                    b.Property<string>("AccountToCreditDescription");

                    b.Property<int>("AccountToDebit");

                    b.Property<string>("AccountToDebitDescription");

                    b.Property<DateTime>("AccountingSeatDate");

                    b.Property<decimal>("AmountToCredit");

                    b.Property<decimal>("AmountToDebit");

                    b.Property<int>("AuxiliarOrigin");

                    b.Property<string>("Description");

                    b.Property<int>("IsMajorizationProcessed");

                    b.Property<int>("MoneyCurrency");

                    b.Property<decimal>("MoneyCurrencyRate");

                    b.Property<int>("Status");

                    b.HasKey("ID");

                    b.ToTable("AccountingEntry");
                });

            modelBuilder.Entity("NetCoreBasicAccounting.Data.Entities.AccountingEntryDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountId");

                    b.Property<int?>("AccountingEntryID");

                    b.Property<decimal>("AmountToCredit");

                    b.Property<decimal>("AmountToDebit");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int>("MovementType");

                    b.HasKey("ID");

                    b.HasIndex("AccountingEntryID");

                    b.ToTable("AccountingEntryDetails");
                });

            modelBuilder.Entity("NetCoreBasicAccounting.Data.Entities.AccountingParameter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MajorizationProcessed");

                    b.Property<int>("Month");

                    b.Property<int>("MonthFiscalClose");

                    b.Property<int>("ProcessYear");

                    b.Property<string>("Rnc");

                    b.HasKey("ID");

                    b.ToTable("AccountingParameter");
                });

            modelBuilder.Entity("NetCoreBasicAccounting.Data.Entities.AccountType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("Origin");

                    b.Property<int>("Status");

                    b.HasKey("ID");

                    b.ToTable("AccountType");
                });

            modelBuilder.Entity("NetCoreBasicAccounting.Data.Entities.Majorization", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountToCredit");

                    b.Property<int>("AccountToCreditHigherAccount");

                    b.Property<int>("AccountToDebit");

                    b.Property<int>("AccountToDebitHigherAccount");

                    b.Property<int>("AccountingEntryId");

                    b.Property<decimal>("AmountToCredit");

                    b.Property<decimal>("AmountToDebit");

                    b.Property<decimal>("Balance");

                    b.Property<DateTime>("ProcessDate");

                    b.Property<int>("Status");

                    b.HasKey("ID");

                    b.ToTable("Majorization");
                });

            modelBuilder.Entity("NetCoreBasicAccounting.Data.Entities.MoneyCurrency", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<decimal>("LastExchangeRate");

                    b.Property<int>("Status");

                    b.HasKey("ID");

                    b.ToTable("MoneyCurrency");
                });

            modelBuilder.Entity("NetCoreBasicAccounting.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("NetCoreBasicAccounting.Models.ComprobationBalance", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountToCredit");

                    b.Property<string>("AccountToCreditDescription");

                    b.Property<int>("AccountToDebit");

                    b.Property<string>("AccountToDebitDescription");

                    b.Property<decimal>("AmountToCredit");

                    b.Property<decimal>("AmountToDebit");

                    b.HasKey("ID");

                    b.ToTable("ComprobationBalances");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("NetCoreBasicAccounting.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("NetCoreBasicAccounting.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NetCoreBasicAccounting.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NetCoreBasicAccounting.Data.Entities.AccountingAccount", b =>
                {
                    b.HasOne("NetCoreBasicAccounting.Data.Entities.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("AccountTypeID");
                });

            modelBuilder.Entity("NetCoreBasicAccounting.Data.Entities.AccountingEntryDetail", b =>
                {
                    b.HasOne("NetCoreBasicAccounting.Data.Entities.AccountingEntry", "AccountingEntry")
                        .WithMany()
                        .HasForeignKey("AccountingEntryID");
                });
        }
    }
}
