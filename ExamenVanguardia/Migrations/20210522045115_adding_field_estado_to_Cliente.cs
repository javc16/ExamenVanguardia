using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamenVanguardia.Migrations
{
    public partial class adding_field_estado_to_Cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdEstado",
                table: "Cliente",
                newName: "IdEstadoCliente");

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Identidad",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Identidad",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "IdEstadoCliente",
                table: "Cliente",
                newName: "IdEstado");
        }
    }
}
