using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamenVanguardia.Migrations
{
    public partial class adding_field_estadoMobiliario_to_Mobiliario_changingToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EstadoMobiliario",
                table: "Mobiliario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EstadoMobiliario",
                table: "Mobiliario",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
