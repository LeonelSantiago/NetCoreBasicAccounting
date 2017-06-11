using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NetCoreBasicAccounting.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "AccountingParameter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MajorizationProcessed = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    MonthFiscalClose = table.Column<int>(nullable: false),
                    ProcessYear = table.Column<int>(nullable: false),
                    Rnc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingParameter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AccountType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Origin = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MoneyCurrency",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    LastExchangeRate = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyCurrency", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AccountingAccount",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountTypeID = table.Column<int>(nullable: true),
                    AllowsTransactions = table.Column<int>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    HigherAccount = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingAccount", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AccountingAccount_AccountType_AccountTypeID",
                        column: x => x.AccountTypeID,
                        principalTable: "AccountType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountingEntry",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountID = table.Column<int>(nullable: true),
                    AccountingSeatAmount = table.Column<decimal>(nullable: false),
                    AccountingSeatDate = table.Column<DateTime>(nullable: false),
                    AuxiliarOrigin = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    MovementType = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingEntry", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AccountingEntry_AccountingAccount_AccountID",
                        column: x => x.AccountID,
                        principalTable: "AccountingAccount",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Majorization",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Balance = table.Column<decimal>(nullable: false),
                    HigherAccountIdentificationID = table.Column<int>(nullable: true),
                    ProcessDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    TipoMovimiento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majorization", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Majorization_AccountingAccount_HigherAccountIdentificationID",
                        column: x => x.HigherAccountIdentificationID,
                        principalTable: "AccountingAccount",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountingAccount_AccountTypeID",
                table: "AccountingAccount",
                column: "AccountTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingEntry_AccountID",
                table: "AccountingEntry",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Majorization_HigherAccountIdentificationID",
                table: "Majorization",
                column: "HigherAccountIdentificationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountingEntry");

            migrationBuilder.DropTable(
                name: "AccountingParameter");

            migrationBuilder.DropTable(
                name: "Majorization");

            migrationBuilder.DropTable(
                name: "MoneyCurrency");

            migrationBuilder.DropTable(
                name: "AccountingAccount");

            migrationBuilder.DropTable(
                name: "AccountType");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
