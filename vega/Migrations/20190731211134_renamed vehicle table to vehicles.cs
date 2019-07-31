using Microsoft.EntityFrameworkCore.Migrations;

namespace vega.Migrations
{
    public partial class renamedvehicletabletovehicles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Models_ModelId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleFeature_Vehicle_VehicleId",
                table: "VehicleFeature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "vehicles");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_ModelId",
                table: "vehicles",
                newName: "IX_vehicles_ModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_vehicles",
                table: "vehicles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleFeature_vehicles_VehicleId",
                table: "VehicleFeature",
                column: "VehicleId",
                principalTable: "vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_Models_ModelId",
                table: "vehicles",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleFeature_vehicles_VehicleId",
                table: "VehicleFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_Models_ModelId",
                table: "vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vehicles",
                table: "vehicles");

            migrationBuilder.RenameTable(
                name: "vehicles",
                newName: "Vehicle");

            migrationBuilder.RenameIndex(
                name: "IX_vehicles_ModelId",
                table: "Vehicle",
                newName: "IX_Vehicle_ModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Models_ModelId",
                table: "Vehicle",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleFeature_Vehicle_VehicleId",
                table: "VehicleFeature",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
