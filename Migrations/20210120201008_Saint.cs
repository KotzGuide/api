using Microsoft.EntityFrameworkCore.Migrations;

namespace Api___KotzGuide.Migrations
{
    public partial class Saint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias");

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "Saints");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Saints",
                table: "Saints",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Saints",
                table: "Saints");

            migrationBuilder.RenameTable(
                name: "Saints",
                newName: "Categorias");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias",
                column: "Id");
        }
    }
}
