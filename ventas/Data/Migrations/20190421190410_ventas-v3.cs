using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ventas.Data.Migrations
{
    public partial class ventasv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UbicacionID",
                table: "Articulo",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ubicacion",
                columns: table => new
                {
                    UbicacionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    Estado = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicacion", x => x.UbicacionID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_UbicacionID",
                table: "Articulo",
                column: "UbicacionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_Ubicacion_UbicacionID",
                table: "Articulo",
                column: "UbicacionID",
                principalTable: "Ubicacion",
                principalColumn: "UbicacionID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_Ubicacion_UbicacionID",
                table: "Articulo");

            migrationBuilder.DropTable(
                name: "Ubicacion");

            migrationBuilder.DropIndex(
                name: "IX_Articulo_UbicacionID",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "UbicacionID",
                table: "Articulo");
        }
    }
}
