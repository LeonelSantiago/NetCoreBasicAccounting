using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreBasicAccounting.Migrations
{
    public partial class ChangeOfPropertiesInComprobationBalance2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "AmountToCredit",
                table: "ComprobationBalances",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AmountToCredit",
                table: "ComprobationBalances",
                nullable: true,
                oldClrType: typeof(decimal));
        }
    }
}
