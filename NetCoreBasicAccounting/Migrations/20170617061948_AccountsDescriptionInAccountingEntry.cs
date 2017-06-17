using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreBasicAccounting.Migrations
{
    public partial class AccountsDescriptionInAccountingEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountToCreditDescription",
                table: "AccountingEntry",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AccountToDebitDescription",
                table: "AccountingEntry",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountToCreditDescription",
                table: "AccountingEntry");

            migrationBuilder.DropColumn(
                name: "AccountToDebitDescription",
                table: "AccountingEntry");
        }
    }
}
