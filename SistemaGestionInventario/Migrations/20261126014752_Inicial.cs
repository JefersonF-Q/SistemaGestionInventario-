using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGestionInventario.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Almacenes",
                columns: table => new
                {
                    IdAlmacen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Responsable = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Almacenes", x => x.IdAlmacen);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    IdProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazonSocial = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    RUC = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.IdProveedor);
                });

            migrationBuilder.CreateTable(
                name: "Salidas",
                columns: table => new
                {
                    IdSalida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAlmacen = table.Column<int>(type: "int", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salidas", x => x.IdSalida);
                    table.ForeignKey(
                        name: "FK_Salidas_Almacenes_IdAlmacen",
                        column: x => x.IdAlmacen,
                        principalTable: "Almacenes",
                        principalColumn: "IdAlmacen",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transferencias",
                columns: table => new
                {
                    IdTransferencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAlmacenOrigen = table.Column<int>(type: "int", nullable: false),
                    IdAlmacenDestino = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencias", x => x.IdTransferencia);
                    table.ForeignKey(
                        name: "FK_Transferencias_Almacenes_IdAlmacenDestino",
                        column: x => x.IdAlmacenDestino,
                        principalTable: "Almacenes",
                        principalColumn: "IdAlmacen",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transferencias_Almacenes_IdAlmacenOrigen",
                        column: x => x.IdAlmacenOrigen,
                        principalTable: "Almacenes",
                        principalColumn: "IdAlmacen",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PrecioCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockMinimo = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    IdCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProveedor = table.Column<int>(type: "int", nullable: false),
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK_Compras_Proveedores_IdProveedor",
                        column: x => x.IdProveedor,
                        principalTable: "Proveedores",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesSalida",
                columns: table => new
                {
                    IdDetalleSalida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSalida = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesSalida", x => x.IdDetalleSalida);
                    table.ForeignKey(
                        name: "FK_DetallesSalida_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesSalida_Salidas_IdSalida",
                        column: x => x.IdSalida,
                        principalTable: "Salidas",
                        principalColumn: "IdSalida",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesTransferencia",
                columns: table => new
                {
                    IdDetalleTransferencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTransferencia = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesTransferencia", x => x.IdDetalleTransferencia);
                    table.ForeignKey(
                        name: "FK_DetallesTransferencia_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesTransferencia_Transferencias_IdTransferencia",
                        column: x => x.IdTransferencia,
                        principalTable: "Transferencias",
                        principalColumn: "IdTransferencia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovimientosInventario",
                columns: table => new
                {
                    IdMovimiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    IdAlmacen = table.Column<int>(type: "int", nullable: false),
                    TipoMovimiento = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientosInventario", x => x.IdMovimiento);
                    table.ForeignKey(
                        name: "FK_MovimientosInventario_Almacenes_IdAlmacen",
                        column: x => x.IdAlmacen,
                        principalTable: "Almacenes",
                        principalColumn: "IdAlmacen",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimientosInventario_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductosAlmacen",
                columns: table => new
                {
                    IdProductoAlmacen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    IdAlmacen = table.Column<int>(type: "int", nullable: false),
                    StockActual = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosAlmacen", x => x.IdProductoAlmacen);
                    table.ForeignKey(
                        name: "FK_ProductosAlmacen_Almacenes_IdAlmacen",
                        column: x => x.IdAlmacen,
                        principalTable: "Almacenes",
                        principalColumn: "IdAlmacen",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductosAlmacen_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesCompra",
                columns: table => new
                {
                    IdDetalleCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompra = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesCompra", x => x.IdDetalleCompra);
                    table.ForeignKey(
                        name: "FK_DetallesCompra_Compras_IdCompra",
                        column: x => x.IdCompra,
                        principalTable: "Compras",
                        principalColumn: "IdCompra",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesCompra_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_IdProveedor",
                table: "Compras",
                column: "IdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesCompra_IdCompra",
                table: "DetallesCompra",
                column: "IdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesCompra_IdProducto",
                table: "DetallesCompra",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesSalida_IdProducto",
                table: "DetallesSalida",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesSalida_IdSalida",
                table: "DetallesSalida",
                column: "IdSalida");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesTransferencia_IdProducto",
                table: "DetallesTransferencia",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesTransferencia_IdTransferencia",
                table: "DetallesTransferencia",
                column: "IdTransferencia");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosInventario_IdAlmacen",
                table: "MovimientosInventario",
                column: "IdAlmacen");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosInventario_IdProducto",
                table: "MovimientosInventario",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Codigo",
                table: "Productos",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdCategoria",
                table: "Productos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosAlmacen_IdAlmacen",
                table: "ProductosAlmacen",
                column: "IdAlmacen");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosAlmacen_IdProducto_IdAlmacen",
                table: "ProductosAlmacen",
                columns: new[] { "IdProducto", "IdAlmacen" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_RUC",
                table: "Proveedores",
                column: "RUC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Salidas_IdAlmacen",
                table: "Salidas",
                column: "IdAlmacen");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencias_IdAlmacenDestino",
                table: "Transferencias",
                column: "IdAlmacenDestino");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencias_IdAlmacenOrigen",
                table: "Transferencias",
                column: "IdAlmacenOrigen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesCompra");

            migrationBuilder.DropTable(
                name: "DetallesSalida");

            migrationBuilder.DropTable(
                name: "DetallesTransferencia");

            migrationBuilder.DropTable(
                name: "MovimientosInventario");

            migrationBuilder.DropTable(
                name: "ProductosAlmacen");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Salidas");

            migrationBuilder.DropTable(
                name: "Transferencias");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Almacenes");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
