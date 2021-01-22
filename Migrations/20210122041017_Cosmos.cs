using Microsoft.EntityFrameworkCore.Migrations;

namespace Api___KotzGuide.Migrations
{
    public partial class Cosmos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecommendedCosmoSetId",
                table: "Saints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cosmos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    CosmoType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cosmos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CosmoSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolarId = table.Column<int>(type: "int", nullable: false),
                    LunarId = table.Column<int>(type: "int", nullable: false),
                    StarId = table.Column<int>(type: "int", nullable: false),
                    LegendaryId = table.Column<int>(type: "int", nullable: false),
                    SaintId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CosmoSets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cosmos");

            migrationBuilder.DropTable(
                name: "CosmoSets");

            migrationBuilder.DropColumn(
                name: "RecommendedCosmoSetId",
                table: "Saints");
        }
    }
}
