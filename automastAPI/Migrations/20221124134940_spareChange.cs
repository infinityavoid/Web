using Microsoft.EntityFrameworkCore.Migrations;

namespace automastAPI.Migrations
{
    public partial class spareChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availability",
                table: "SpareParts");

            migrationBuilder.DropColumn(
                name: "SpareType",
                table: "SpareParts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Availability",
                table: "SpareParts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SpareType",
                table: "SpareParts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
