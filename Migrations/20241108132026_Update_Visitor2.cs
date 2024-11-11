using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisitorManagement.Migrations
{
    public partial class Update_Visitor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdNumber",
                table: "Visitors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdNumber",
                table: "Visitors");
        }
    }
}
