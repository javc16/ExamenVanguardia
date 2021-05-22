using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamenVanguardia.Migrations
{
    public partial class adding_field_estadoMobiliario_to_Mobiliario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoMobiliario",
                table: "Mobiliario",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoMobiliario",
                table: "Mobiliario");
        }
    }
}
