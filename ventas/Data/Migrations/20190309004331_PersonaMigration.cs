using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ventas.Data.Migrations
{
    public partial class PersonaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    PersonaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoPersona = table.Column<byte>(type: "tinyint", nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    TipoDocumento = table.Column<byte>(type: "tinyint", nullable: false),
                    NumeroDocumento = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.PersonaID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
