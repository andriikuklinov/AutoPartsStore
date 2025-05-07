using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Products.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characteristics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characteristics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductsCharacteristics",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CharacteristicId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsCharacteristics", x => new { x.ProductId, x.CharacteristicId });
                    table.ForeignKey(
                        name: "FK_ProductsCharacteristics_Characteristics_CharacteristicId",
                        column: x => x.CharacteristicId,
                        principalTable: "Characteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsCharacteristics_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characteristics",
                columns: new[] { "Id", "Name", "Unit" },
                values: new object[,]
                {
                    { 1, "Voltage", "V" },
                    { 2, "Capacity", "Ah" },
                    { 3, "Width", "cm" },
                    { 4, "Radius", "cm" },
                    { 5, "Type", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Accumulator", "Bosh 12v", 0m },
                    { 2, "Accumulator", "Varta 12v", 0m },
                    { 3, "tire", "Tire R14", 0m },
                    { 4, "tire 13", "Tire R13", 0m }
                });

            migrationBuilder.InsertData(
                table: "ProductsCharacteristics",
                columns: new[] { "CharacteristicId", "ProductId", "Value" },
                values: new object[,]
                {
                    { 1, 1, "12" },
                    { 2, 1, "100" },
                    { 5, 1, "AGM" },
                    { 1, 2, "24" },
                    { 2, 2, "200" },
                    { 5, 2, "AGM" },
                    { 3, 3, "20" },
                    { 4, 3, "14" },
                    { 3, 4, "20" },
                    { 4, 4, "18" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsCharacteristics_CharacteristicId",
                table: "ProductsCharacteristics",
                column: "CharacteristicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsCharacteristics");

            migrationBuilder.DropTable(
                name: "Characteristics");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
