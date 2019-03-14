using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ventas.Data.Migrations
{
    public partial class MigracionIngresos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comprobante",
                columns: table => new
                {
                    ComprobanteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(nullable: true),
                    Serie = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprobante", x => x.ComprobanteID);
                });

            migrationBuilder.CreateTable(
                name: "Ingreso",
                columns: table => new
                {
                    IngresoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "Date", nullable: false),
                    hora = table.Column<TimeSpan>(type: "time", nullable: false),
                    Impuesto = table.Column<int>(nullable: false),
                    Estado = table.Column<byte>(type: "tinyint", nullable: false),
                    ComprobanteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingreso", x => x.IngresoID);
                    table.ForeignKey(
                        name: "FK_Ingreso_Comprobante_ComprobanteID",
                        column: x => x.ComprobanteID,
                        principalTable: "Comprobante",
                        principalColumn: "ComprobanteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleIngreso",
                columns: table => new
                {
                    DetalleIngresoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cantidad = table.Column<int>(nullable: false),
                    PrecioCompra = table.Column<decimal>(type: "money", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "money", nullable: false),
                    IngresoID = table.Column<int>(nullable: false),
                    ArticuloID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleIngreso", x => x.DetalleIngresoID);
                    table.ForeignKey(
                        name: "FK_DetalleIngreso_Articulo_ArticuloID",
                        column: x => x.ArticuloID,
                        principalTable: "Articulo",
                        principalColumn: "ArticuloID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleIngreso_Ingreso_IngresoID",
                        column: x => x.IngresoID,
                        principalTable: "Ingreso",
                        principalColumn: "IngresoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleIngreso_ArticuloID",
                table: "DetalleIngreso",
                column: "ArticuloID");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleIngreso_IngresoID",
                table: "DetalleIngreso",
                column: "IngresoID");

            migrationBuilder.CreateIndex(
                name: "IX_Ingreso_ComprobanteID",
                table: "Ingreso",
                column: "ComprobanteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleIngreso");

            migrationBuilder.DropTable(
                name: "Ingreso");

            migrationBuilder.DropTable(
                name: "Comprobante");
        }
    }
}
