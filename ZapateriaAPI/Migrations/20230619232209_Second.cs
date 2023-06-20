using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZapateriaAPI.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saliers_Producties_Products",
                table: "Saliers");

            migrationBuilder.DropIndex(
                name: "IX_Saliers_Products",
                table: "Saliers");

            migrationBuilder.DropColumn(
                name: "Products",
                table: "Saliers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Products",
                table: "Saliers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Saliers_Products",
                table: "Saliers",
                column: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Saliers_Producties_Products",
                table: "Saliers",
                column: "Products",
                principalTable: "Producties",
                principalColumn: "productId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
