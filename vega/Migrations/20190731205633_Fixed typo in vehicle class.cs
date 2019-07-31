using Microsoft.EntityFrameworkCore.Migrations;

namespace vega.Migrations
{
    public partial class Fixedtypoinvehicleclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModeInfo",
                table: "Vehicle",
                newName: "MoreInfo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MoreInfo",
                table: "Vehicle",
                newName: "ModeInfo");
        }
    }
}
