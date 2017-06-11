using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreBasicAccounting.Data.Migrations
{
    public partial class ChangeOfPropertiesTypeInAccountingAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountingAccount_AccountType_AccountTypeID",
                table: "AccountingAccount");

            migrationBuilder.DropIndex(
                name: "IX_AccountingAccount_AccountTypeID",
                table: "AccountingAccount");

            migrationBuilder.DropColumn(
                name: "AccountTypeID",
                table: "AccountingAccount");

            migrationBuilder.AlterColumn<int>(
                name: "MonthFiscalClose",
                table: "AccountingParameter",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "Month",
                table: "AccountingParameter",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "AccountType",
                table: "AccountingAccount",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "AccountingAccount");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MonthFiscalClose",
                table: "AccountingParameter",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Month",
                table: "AccountingParameter",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AccountTypeID",
                table: "AccountingAccount",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountingAccount_AccountTypeID",
                table: "AccountingAccount",
                column: "AccountTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountingAccount_AccountType_AccountTypeID",
                table: "AccountingAccount",
                column: "AccountTypeID",
                principalTable: "AccountType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
