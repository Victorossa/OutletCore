using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OutletCore.Models
{
    public partial class OuletBDContext : DbContext
    {
        public OuletBDContext()
        {
        }

        public OuletBDContext(DbContextOptions<OuletBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProdPrecRegistroPrecio> ProdPrecRegistroPrecio { get; set; }
        public virtual DbSet<ProdPrecTipoPrecio> ProdPrecTipoPrecio { get; set; }
        public virtual DbSet<ProdProducto> ProdProducto { get; set; }
        public virtual DbSet<ProdTipoProducto> ProdTipoProducto { get; set; }
        public virtual DbSet<ProdUdmCategoriaUnidadDeMedida> ProdUdmCategoriaUnidadDeMedida { get; set; }
        public virtual DbSet<ProdUdmUnidadDeMedida> ProdUdmUnidadDeMedida { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<ProdPrecRegistroPrecio>(entity =>
            {
                entity.HasKey(e => e.RegistroPrecio)
                    .HasName("PK_prod-prec-registro-precio");

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.Property(e => e.TipoPrecioId).HasColumnName("TipoPrecioID");
            });

            modelBuilder.Entity<ProdPrecTipoPrecio>(entity =>
            {
                entity.HasKey(e => e.TipoPrecioId)
                    .HasName("PK_prod-prec-tipo-precio");

                entity.Property(e => e.TipoPrecioId).HasColumnName("TipoPrecioID");

                entity.Property(e => e.NombreTipoPrecio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProdProducto>(entity =>
            {
                entity.HasKey(e => e.ProductoId)
                    .HasName("PK_prod_producto");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.Property(e => e.CodigoDeBarrasEan13)
                    .IsRequired()
                    .HasColumnName("CodigoDeBarrasEAN13")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenciaInterna)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoProductoId).HasColumnName("TipoProductoID");

                entity.Property(e => e.UnidadDeMedidaId).HasColumnName("UnidadDeMedidaID");
            });

            modelBuilder.Entity<ProdTipoProducto>(entity =>
            {
                entity.HasKey(e => e.TipoProductoId)
                    .HasName("PK_prod_tipoproducto");

                entity.Property(e => e.TipoProductoId).HasColumnName("TipoProductoID");

                entity.Property(e => e.NombreTipoProducto)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProdUdmCategoriaUnidadDeMedida>(entity =>
            {
                entity.HasKey(e => e.CategoriaUnidadDeMedidaId)
                    .HasName("PK_prod_udm_categoriaunidaddemedida");

                entity.Property(e => e.CategoriaUnidadDeMedidaId).HasColumnName("CategoriaUnidadDeMedidaID");
            });

            modelBuilder.Entity<ProdUdmUnidadDeMedida>(entity =>
            {
                entity.HasKey(e => e.UnidadDeMedidaId)
                    .HasName("PK_prod_unidaddemedida");

                entity.Property(e => e.UnidadDeMedidaId).HasColumnName("UnidadDeMedidaID");

                entity.Property(e => e.CategoriaUnidadDeMedidaId).HasColumnName("CategoriaUnidadDeMedidaID");

                entity.Property(e => e.NombreUnidadDeMedida)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
