using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACOC2.BaristaApi.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoffeeProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewRecipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrewTimeSeconds = table.Column<int>(type: "int", nullable: false),
                    TemperatureCelsius = table.Column<int>(type: "int", nullable: false),
                    CoffeeProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrewRecipes_CoffeeProducts_CoffeeProductId",
                        column: x => x.CoffeeProductId,
                        principalTable: "CoffeeProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrewRecipes_CoffeeProductId",
                table: "BrewRecipes",
                column: "CoffeeProductId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrewRecipes");

            migrationBuilder.DropTable(
                name: "CoffeeProducts");
        }
    }
}
