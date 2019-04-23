using Microsoft.EntityFrameworkCore.Migrations;

namespace ventas.Data.Migrations
{
    public partial class ventasv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonaID",
                table: "Ingreso",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingreso_PersonaID",
                table: "Ingreso",
                column: "PersonaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingreso_Persona_PersonaID",
                table: "Ingreso",
                column: "PersonaID",
                principalTable: "Persona",
                principalColumn: "PersonaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingreso_Persona_PersonaID",
                table: "Ingreso");

            migrationBuilder.DropIndex(
                name: "IX_Ingreso_PersonaID",
                table: "Ingreso");

            migrationBuilder.DropColumn(
                name: "PersonaID",
                table: "Ingreso");
        }
    }
}
