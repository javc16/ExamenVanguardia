using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamenVanguardia.Migrations
{
    public partial class adding_field_estado_to_EstadoCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "EstadoCliente",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "EstadoCliente");
        }
    }
}
