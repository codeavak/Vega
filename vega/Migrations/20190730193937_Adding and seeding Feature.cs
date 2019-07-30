using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vega.Migrations
{
    public partial class AddingandseedingFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelFeature",
                columns: table => new
                {
                    ModelId = table.Column<int>(nullable: false),
                    FeatureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelFeature", x => new { x.ModelId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_ModelFeature_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelFeature_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModelFeature_FeatureId",
                table: "ModelFeature",
                column: "FeatureId");

            migrationBuilder.Sql("insert into features(name) values ('Remote Keyless Entry')");
            migrationBuilder.Sql("insert into features(name) values ('Anti - Lock Brakes(ABS)')");
            migrationBuilder.Sql("insert into features(name) values ('Electronic Stability')");
            migrationBuilder.Sql("insert into features(name) values ('Telescoping Steering Wheel')");
            migrationBuilder.Sql("insert into features(name) values ('DVD Player')");
            migrationBuilder.Sql("insert into features(name) values ('GPS Navigation System')");
            migrationBuilder.Sql("insert into features(name) values ('Side Airbags')");
        
    }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelFeature");

            migrationBuilder.DropTable(
                name: "Features");

        }
    }
}
