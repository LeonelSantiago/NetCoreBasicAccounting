using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreBasicAccounting.Migrations
{
    public partial class SomePropertiesModificationsInMajorizationEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Majorization_AccountingAccount_HigherAccountIdentificationID",
                table: "Majorization");

            migrationBuilder.DropIndex(
                name: "IX_Majorization_HigherAccountIdentificationID",
                table: "Majorization");

            migrationBuilder.DropColumn(
                name: "HigherAccountIdentificationID",
                table: "Majorization");

            migrationBuilder.RenameColumn(
                name: "TipoMovimiento",
                table: "Majorization",
                newName: "AccountingEntryId");

            migrationBuilder.AddColumn<int>(
                name: "AccountToCredit",
                table: "Majorization",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountToCreditHigherAccount",
                table: "Majorization",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountToDebit",
                table: "Majorization",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountToDebitHigherAccount",
                table: "Majorization",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountToCredit",
                table: "Majorization",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountToDebit",
                table: "Majorization",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountToCredit",
                table: "Majorization");

            migrationBuilder.DropColumn(
                name: "AccountToCreditHigherAccount",
                table: "Majorization");

            migrationBuilder.DropColumn(
                name: "AccountToDebit",
                table: "Majorization");

            migrationBuilder.DropColumn(
                name: "AccountToDebitHigherAccount",
                table: "Majorization");

            migrationBuilder.DropColumn(
                name: "AmountToCredit",
                table: "Majorization");

            migrationBuilder.DropColumn(
                name: "AmountToDebit",
                table: "Majorization");

            migrationBuilder.RenameColumn(
                name: "AccountingEntryId",
                table: "Majorization",
                newName: "TipoMovimiento");

            migrationBuilder.AddColumn<int>(
                name: "HigherAccountIdentificationID",
                table: "Majorization",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Majorization_HigherAccountIdentificationID",
                table: "Majorization",
                column: "HigherAccountIdentificationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Majorization_AccountingAccount_HigherAccountIdentificationID",
                table: "Majorization",
                column: "HigherAccountIdentificationID",
                principalTable: "AccountingAccount",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
