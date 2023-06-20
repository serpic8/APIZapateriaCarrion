using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZapateriaAPI.Migrations
{
    /// <inheritdoc />
    public partial class Fourthy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "salesTotal",
                table: "Saliers",
                newName: "SalesTotal");

            migrationBuilder.RenameColumn(
                name: "salesPrecioV",
                table: "Saliers",
                newName: "SalesPrecioV");

            migrationBuilder.RenameColumn(
                name: "salesId",
                table: "Saliers",
                newName: "SalesId");

            migrationBuilder.AddColumn<int>(
                name: "SalesCantidad",
                table: "Saliers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SalesFecha",
                table: "Saliers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesCantidad",
                table: "Saliers");

            migrationBuilder.DropColumn(
                name: "SalesFecha",
                table: "Saliers");

            migrationBuilder.RenameColumn(
                name: "SalesTotal",
                table: "Saliers",
                newName: "salesTotal");

            migrationBuilder.RenameColumn(
                name: "SalesPrecioV",
                table: "Saliers",
                newName: "salesPrecioV");

            migrationBuilder.RenameColumn(
                name: "SalesId",
                table: "Saliers",
                newName: "salesId");
        }
    }
}
