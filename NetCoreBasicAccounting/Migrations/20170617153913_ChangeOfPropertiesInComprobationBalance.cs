using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreBasicAccounting.Migrations
{
    public partial class ChangeOfPropertiesInComprobationBalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MovementTypeDescription",
                table: "ComprobationBalances",
                newName: "AmountToCredit");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ComprobationBalances",
                newName: "AccountToDebitDescription");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "ComprobationBalances",
                newName: "AccountToDebit");

            migrationBuilder.RenameColumn(
                name: "AccountAmount",
                table: "ComprobationBalances",
                newName: "AccountToCreditDescription");

            migrationBuilder.AddColumn<int>(
                name: "AccountToCredit",
                table: "ComprobationBalances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountToDebit",
                table: "ComprobationBalances",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountToCredit",
                table: "ComprobationBalances");

            migrationBuilder.DropColumn(
                name: "AmountToDebit",
                table: "ComprobationBalances");

            migrationBuilder.RenameColumn(
                name: "AmountToCredit",
                table: "ComprobationBalances",
                newName: "MovementTypeDescription");

            migrationBuilder.RenameColumn(
                name: "AccountToDebitDescription",
                table: "ComprobationBalances",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "AccountToDebit",
                table: "ComprobationBalances",
                newName: "AccountID");

            migrationBuilder.RenameColumn(
                name: "AccountToCreditDescription",
                table: "ComprobationBalances",
                newName: "AccountAmount");
        }
    }
}
