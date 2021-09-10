using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(128)", nullable: false),
                    Apellido = table.Column<string>(type: "VARCHAR(128)", nullable: false),
                    Identificacion = table.Column<long>(nullable: false),
                    FechaVenta = table.Column<DateTime>(nullable: false),
                    TotalVenta = table.Column<decimal>(type: "DECIMAL(18, 0)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "DECIMAL(18, 0)", nullable: false),
                    Direccion = table.Column<string>(type: "VARCHAR(128)", nullable: false),
                    Telefono = table.Column<int>(nullable: false),
                    FechaEntrega = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(128)", nullable: false),
                    ValorVentaConIva = table.Column<decimal>(type: "DECIMAL(18, 0)", nullable: false),
                    CantidadUnidadesInventario = table.Column<int>(nullable: false),
                    PorcentajeIvaaplicado = table.Column<decimal>(type: "DECIMAL(3, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetalleFactura",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    ValorUnitarioSinIva = table.Column<decimal>(type: "DECIMAL(18, 0)", nullable: false),
                    ValorUnitarioConIva = table.Column<decimal>(type: "DECIMAL(18, 0)", nullable: false),
                    ValorTotalProducto = table.Column<decimal>(type: "DECIMAL(18, 0)", nullable: false),
                    FacturaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleFactura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleFactura_Factura_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Factura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleFactura_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFactura_FacturaId",
                table: "DetalleFactura",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFactura_ProductoId",
                table: "DetalleFactura",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleFactura");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}
