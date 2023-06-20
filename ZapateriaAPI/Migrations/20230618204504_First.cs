using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZapateriaAPI.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producties",
                columns: table => new
                {
                    productId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productMarca = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    productModelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productTipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productColor = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    productTalla = table.Column<double>(type: "float", maxLength: 4, nullable: false),
                    productGenero = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    productPrecio = table.Column<double>(type: "float", nullable: false),
                    productUbicacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producties", x => x.productId);
                });

            migrationBuilder.CreateTable(
                name: "Temp_Producties",
                columns: table => new
                {
                    temp_productId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productMarca = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    productModelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productTalla = table.Column<double>(type: "float", maxLength: 4, nullable: false),
                    productGenero = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    productPrecio = table.Column<double>(type: "float", nullable: false),
                    productUbicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productCantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temp_Producties", x => x.temp_productId);
                });

            migrationBuilder.CreateTable(
                name: "Inventaries",
                columns: table => new
                {
                    inventaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Products = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventaries", x => x.inventaryId);
                    table.ForeignKey(
                        name: "FK_Inventaries_Producties_Products",
                        column: x => x.Products,
                        principalTable: "Producties",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Saliers",
                columns: table => new
                {
                    salesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Products = table.Column<int>(type: "int", nullable: false),
                    salesPrecioV = table.Column<double>(type: "float", nullable: false),
                    salesTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saliers", x => x.salesId);
                    table.ForeignKey(
                        name: "FK_Saliers_Producties_Products",
                        column: x => x.Products,
                        principalTable: "Producties",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Producties",
                columns: new[] { "productId", "productColor", "productGenero", "productMarca", "productModelo", "productPrecio", "productTalla", "productTipo", "productUbicacion" },
                values: new object[,]
                {
                    { 1, "Rojo", "F", "Nike", "Air Force 1", 500.0, 42.5, "Rojo, con detalles negros", "Bodega" },
                    { 2, "Blanco", "F", "Adidas", "Road Street", 500.0, 42.5, "Blanco, con detalles negros", "Bodega" },
                    { 3, "Amarillo", "F", "New Balance", "Zapatillas", 500.0, 42.5, "Rojo, con detalles negros", "Bodega" },
                    { 4, "Verde", "F", "Lacoste", "Zapatos", 500.0, 42.5, "Rojo, con detalles negros", "Bodega" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventaries_Products",
                table: "Inventaries",
                column: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Saliers_Products",
                table: "Saliers",
                column: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventaries");

            migrationBuilder.DropTable(
                name: "Saliers");

            migrationBuilder.DropTable(
                name: "Temp_Producties");

            migrationBuilder.DropTable(
                name: "Producties");
        }
    }
}
