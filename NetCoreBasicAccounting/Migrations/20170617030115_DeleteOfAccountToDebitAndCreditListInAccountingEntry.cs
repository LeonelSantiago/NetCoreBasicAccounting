using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreBasicAccounting.Migrations
{
    public partial class DeleteOfAccountToDebitAndCreditListInAccountingEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountingAccount_AccountingEntry_AccountingEntryID",
                table: "AccountingAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountingAccount_AccountingEntry_AccountingEntryID1",
                table: "AccountingAccount");

            migrationBuilder.DropIndex(
                name: "IX_AccountingAccount_AccountingEntryID",
                table: "AccountingAccount");

            migrationBuilder.DropIndex(
                name: "IX_AccountingAccount_AccountingEntryID1",
                table: "AccountingAccount");

            migrationBuilder.DropColumn(
                name: "AccountingEntryID",
                table: "AccountingAccount");

            migrationBuilder.DropColumn(
                name: "AccountingEntryID1",
                table: "AccountingAccount");

            migrationBuilder.RenameColumn(
                name: "MovementType",
                table: "AccountingEntry",
                newName: "AccountToDebit");

            migrationBuilder.RenameColumn(
                name: "AccountingSeatAmount",
                table: "AccountingEntry",
                newName: "AmountToDebit");

            migrationBuilder.AddColumn<int>(
                name: "AccountToCredit",
                table: "AccountingEntry",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountToCredit",
                table: "AccountingEntry",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountToCredit",
                table: "AccountingEntry");

            migrationBuilder.DropColumn(
                name: "AmountToCredit",
                table: "AccountingEntry");

            migrationBuilder.RenameColumn(
                name: "AmountToDebit",
                table: "AccountingEntry",
                newName: "AccountingSeatAmount");

            migrationBuilder.RenameColumn(
                name: "AccountToDebit",
                table: "AccountingEntry",
                newName: "MovementType");

            migrationBuilder.AddColumn<int>(
                name: "AccountingEntryID",
                table: "AccountingAccount",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountingEntryID1",
                table: "AccountingAccount",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountingAccount_AccountingEntryID",
                table: "AccountingAccount",
                column: "AccountingEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingAccount_AccountingEntryID1",
                table: "AccountingAccount",
                column: "AccountingEntryID1");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountingAccount_AccountingEntry_AccountingEntryID",
                table: "AccountingAccount",
                column: "AccountingEntryID",
                principalTable: "AccountingEntry",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountingAccount_AccountingEntry_AccountingEntryID1",
                table: "AccountingAccount",
                column: "AccountingEntryID1",
                principalTable: "AccountingEntry",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
