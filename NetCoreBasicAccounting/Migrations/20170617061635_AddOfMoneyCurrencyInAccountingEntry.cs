using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreBasicAccounting.Migrations
{
    public partial class AddOfMoneyCurrencyInAccountingEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MoneyCurrency",
                table: "AccountingEntry",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MoneyCurrencyRate",
                table: "AccountingEntry",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoneyCurrency",
                table: "AccountingEntry");

            migrationBuilder.DropColumn(
                name: "MoneyCurrencyRate",
                table: "AccountingEntry");
        }
    }
}
