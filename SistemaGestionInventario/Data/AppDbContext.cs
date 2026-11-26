using Microsoft.EntityFrameworkCore;
using SistemaGestionInventario.Models;

namespace SistemaGestionInventario.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Tablas principales
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Almacen> Almacenes { get; set; }

        // Control de inventario
        public DbSet<ProductoAlmacen> ProductosAlmacen { get; set; }
        public DbSet<MovimientoInventario> MovimientosInventario { get; set; }

        // Compras
        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetalleCompra> DetallesCompra { get; set; }

        // Salidas
        public DbSet<Salida> Salidas { get; set; }
        public DbSet<DetalleSalida> DetallesSalida { get; set; }

        // Transferencias
        public DbSet<Transferencia> Transferencias { get; set; }
        public DbSet<DetalleTransferencia> DetallesTransferencia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Claves Primarias
            // CLAVES PRIMARIAS (PK)
            modelBuilder.Entity<Categoria>().HasKey(c => c.IdCategoria);
            modelBuilder.Entity<Producto>().HasKey(p => p.IdProducto);
            modelBuilder.Entity<Proveedor>().HasKey(p => p.IdProveedor);
            modelBuilder.Entity<Almacen>().HasKey(a => a.IdAlmacen);
            modelBuilder.Entity<ProductoAlmacen>().HasKey(pa => pa.IdProductoAlmacen);
            modelBuilder.Entity<Compra>().HasKey(c => c.IdCompra);
            modelBuilder.Entity<DetalleCompra>().HasKey(d => d.IdDetalleCompra);
            modelBuilder.Entity<Salida>().HasKey(s => s.IdSalida);
            modelBuilder.Entity<DetalleSalida>().HasKey(d => d.IdDetalleSalida);
            modelBuilder.Entity<Transferencia>().HasKey(t => t.IdTransferencia);
            modelBuilder.Entity<DetalleTransferencia>().HasKey(d => d.IdDetalleTransferencia);
            modelBuilder.Entity<MovimientoInventario>().HasKey(m => m.IdMovimiento);

            // Producto - Categoria
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.IdCategoria);

            // ProductoAlmacen - Producto
            modelBuilder.Entity<ProductoAlmacen>()
                .HasOne(pa => pa.Producto)
                .WithMany(p => p.ProductosAlmacen)
                .HasForeignKey(pa => pa.IdProducto);

            // ProductoAlmacen - Almacen
            modelBuilder.Entity<ProductoAlmacen>()
                .HasOne(pa => pa.Almacen)
                .WithMany(a => a.ProductosAlmacen)
                .HasForeignKey(pa => pa.IdAlmacen);

            // Evitar repetir un producto dentro del mismo almacén
            modelBuilder.Entity<ProductoAlmacen>()
                .HasIndex(pa => new { pa.IdProducto, pa.IdAlmacen })
                .IsUnique();

            // Producto - Codigo único
            modelBuilder.Entity<Producto>()
                .HasIndex(p => p.Codigo)
                .IsUnique();

            // Proveedor - RUC único
            modelBuilder.Entity<Proveedor>()
                .HasIndex(p => p.RUC)
                .IsUnique();

            // Compra - Proveedor
            modelBuilder.Entity<Compra>()
                .HasOne(c => c.Proveedor)
                .WithMany(p => p.Compras)
                .HasForeignKey(c => c.IdProveedor);

            // Compra - Detalles
            modelBuilder.Entity<DetalleCompra>()
                .HasOne(d => d.Compra)
                .WithMany(c => c.Detalles)
                .HasForeignKey(d => d.IdCompra);

            modelBuilder.Entity<DetalleCompra>()
                .HasOne(d => d.Producto)
                .WithMany(p => p.DetallesCompra)
                .HasForeignKey(d => d.IdProducto);

            // Salida - Almacen
            modelBuilder.Entity<Salida>()
                .HasOne(s => s.Almacen)
                .WithMany(a => a.Salidas)
                .HasForeignKey(s => s.IdAlmacen);

            // Salida - Detalles
            modelBuilder.Entity<DetalleSalida>()
                .HasOne(d => d.Salida)
                .WithMany(s => s.Detalles)
                .HasForeignKey(d => d.IdSalida);

            modelBuilder.Entity<DetalleSalida>()
                .HasOne(d => d.Producto)
                .WithMany(p => p.DetallesSalida)
                .HasForeignKey(d => d.IdProducto);

            // Transferencia - Almacen origen
            modelBuilder.Entity<Transferencia>()
                .HasOne(t => t.AlmacenOrigen)
                .WithMany(a => a.TransferenciasOrigen)
                .HasForeignKey(t => t.IdAlmacenOrigen)
                .OnDelete(DeleteBehavior.Restrict);

            // Transferencia - Almacen destino
            modelBuilder.Entity<Transferencia>()
                .HasOne(t => t.AlmacenDestino)
                .WithMany(a => a.TransferenciasDestino)
                .HasForeignKey(t => t.IdAlmacenDestino)
                .OnDelete(DeleteBehavior.Restrict);

            // Transferencia - Detalles
            modelBuilder.Entity<DetalleTransferencia>()
                .HasOne(d => d.Transferencia)
                .WithMany(t => t.Detalles)
                .HasForeignKey(d => d.IdTransferencia);

            modelBuilder.Entity<DetalleTransferencia>()
                .HasOne(d => d.Producto)
                .WithMany(p => p.DetallesTransferencia)
                .HasForeignKey(d => d.IdProducto);

            // MovimientoInventario - Producto
            modelBuilder.Entity<MovimientoInventario>()
                .HasOne(m => m.Producto)
                .WithMany(p => p.Movimientos)
                .HasForeignKey(m => m.IdProducto);

            // MovimientoInventario - Almacen
            modelBuilder.Entity<MovimientoInventario>()
                .HasOne(m => m.Almacen)
                .WithMany(a => a.Movimientos)
                .HasForeignKey(m => m.IdAlmacen);
        }
    }
}
