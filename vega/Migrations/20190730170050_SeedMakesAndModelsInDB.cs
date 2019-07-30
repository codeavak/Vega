using Microsoft.EntityFrameworkCore.Migrations;

namespace vega.Migrations
{
    public partial class SeedMakesAndModelsInDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into makes(name) values ('Honda')");
            migrationBuilder.Sql("insert into makes(name) values ('Toyota')");
            migrationBuilder.Sql("insert into makes(name) values ('Lamborghini')");
            migrationBuilder.Sql("insert into models(name, makeid) values('Civic', (select id from makes where name = 'Honda'))");
            migrationBuilder.Sql("insert into models(name, makeid) values('Odyssey', (select id from makes where name = 'Honda'))");
            migrationBuilder.Sql("insert into models(name, makeid) values('Accord', (select id from makes where name = 'Honda'))");

            migrationBuilder.Sql("insert into models(name, makeid) values('Corolla', (select id from makes where name = 'Toyota'))");
            migrationBuilder.Sql("insert into models(name, makeid) values('Camry', (select id from makes where name = 'Toyota'))");
            migrationBuilder.Sql("insert into models(name, makeid) values('Prius', (select id from makes where name = 'Toyota'))");

            migrationBuilder.Sql("insert into models(name, makeid) values('Huracan', (select id from makes where name = 'Lamborghini'))");
            migrationBuilder.Sql("insert into models(name, makeid) values('Urus', (select id from makes where name = 'Lamborghini'))");
            migrationBuilder.Sql("insert into models(name, makeid) values('Aventador', (select id from makes where name = 'Lamborghini'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from models where makeid= (select id from make where name='Honda')");
            migrationBuilder.Sql("delete from models where makeid= (select id from make where name='Toyota')");
            migrationBuilder.Sql("delete from models where makeid= (select id from make where name='Lamborghini')");
            migrationBuilder.Sql("delete from makes where name='Honda'");
            migrationBuilder.Sql("delete from makes where name='Toyota'");
            migrationBuilder.Sql("delete from makes where name='Lamborghini'");

        }
    }
}
