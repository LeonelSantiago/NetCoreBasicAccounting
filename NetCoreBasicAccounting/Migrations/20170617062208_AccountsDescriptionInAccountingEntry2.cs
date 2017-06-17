using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreBasicAccounting.Migrations
{
    public partial class AccountsDescriptionInAccountingEntry2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AccountToCreditDescription",
                table: "AccountingEntry",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AccountToCreditDescription",
                table: "AccountingEntry",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
