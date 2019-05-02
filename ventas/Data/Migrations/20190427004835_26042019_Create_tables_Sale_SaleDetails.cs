using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ventas.Data.Migrations
{
    public partial class _26042019_Create_tables_Sale_SaleDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    SaleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "Date", nullable: false),
                    Hora = table.Column<TimeSpan>(type: "Time", nullable: false),
                    Impuesto = table.Column<int>(nullable: false),
                    Estado = table.Column<byte>(type: "Tinyint", nullable: false),
                    ComprobanteID = table.Column<int>(nullable: false),
                    PersonaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.SaleID);
                    table.ForeignKey(
                        name: "FK_Sale_Comprobante_ComprobanteID",
                        column: x => x.ComprobanteID,
                        principalTable: "Comprobante",
                        principalColumn: "ComprobanteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sale_Persona_PersonaID",
                        column: x => x.PersonaID,
                        principalTable: "Persona",
                        principalColumn: "PersonaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleDetail",
                columns: table => new
                {
                    SaleDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cantidad = table.Column<int>(nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "Money", nullable: false),
                    ArticuloID = table.Column<int>(nullable: false),
                    SaleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleDetail", x => x.SaleDetailID);
                    table.ForeignKey(
                        name: "FK_SaleDetail_Articulo_ArticuloID",
                        column: x => x.ArticuloID,
                        principalTable: "Articulo",
                        principalColumn: "ArticuloID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleDetail_Sale_SaleID",
                        column: x => x.SaleID,
                        principalTable: "Sale",
                        principalColumn: "SaleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sale_ComprobanteID",
                table: "Sale",
                column: "ComprobanteID");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_PersonaID",
                table: "Sale",
                column: "PersonaID");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_ArticuloID",
                table: "SaleDetail",
                column: "ArticuloID");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_SaleID",
                table: "SaleDetail",
                column: "SaleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleDetail");

            migrationBuilder.DropTable(
                name: "Sale");
        }
    }
}
