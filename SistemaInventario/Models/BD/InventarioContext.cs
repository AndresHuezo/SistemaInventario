using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SistemaInventario.Models.BD
{
    public partial class InventarioContext : DbContext
    {
        public InventarioContext()
        {
        }

        public InventarioContext(DbContextOptions<InventarioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<Estante> Estantes { get; set; } = null!;
        public virtual DbSet<Fila> Filas { get; set; } = null!;
        public virtual DbSet<Inventario> Inventarios { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Proveedor> Proveedors { get; set; } = null!;
        public virtual DbSet<Sucursal> Sucursals { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost; Database=Inventario; Trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.Idcategoria)
                    .HasName("PK_categorias_1");

                entity.ToTable("categorias");

                entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(10)
                    .HasColumnName("descripcion")
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(10)
                    .HasColumnName("nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Estante>(entity =>
            {
                entity.HasKey(e => e.Idestante);

                entity.ToTable("estante");

                entity.Property(e => e.Idestante)
                    .ValueGeneratedNever()
                    .HasColumnName("idestante");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Fila>(entity =>
            {
                entity.HasKey(e => e.Idfila);

                entity.ToTable("fila");

                entity.Property(e => e.Idfila)
                    .ValueGeneratedNever()
                    .HasColumnName("idfila");

                entity.Property(e => e.Idestante).HasColumnName("idestante");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdestanteNavigation)
                    .WithMany(p => p.Filas)
                    .HasForeignKey(d => d.Idestante)
                    .HasConstraintName("FK_fila_estante");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.Idregistro);

                entity.ToTable("inventario");

                entity.Property(e => e.Idregistro).HasColumnName("idregistro");

                entity.Property(e => e.Codproducto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codproducto");

                entity.Property(e => e.Entradastock).HasColumnName("entradastock");

                entity.Property(e => e.Idestante).HasColumnName("idestante");

                entity.Property(e => e.Idproveedor).HasColumnName("idproveedor");

                entity.Property(e => e.Idsucursal).HasColumnName("idsucursal");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.Observaciones)
                    .HasColumnType("text")
                    .HasColumnName("observaciones");

                entity.Property(e => e.Salidastock).HasColumnName("salidastock");

                entity.HasOne(d => d.CodproductoNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.Codproducto)
                    .HasConstraintName("FK_inventario_productos");

                entity.HasOne(d => d.IdestanteNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.Idestante)
                    .HasConstraintName("FK_inventario_estante");

                entity.HasOne(d => d.IdproveedorNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.Idproveedor)
                    .HasConstraintName("FK_inventario_proveedor");

                entity.HasOne(d => d.IdsucursalNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.Idsucursal)
                    .HasConstraintName("FK_inventario_sucursal");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("FK_inventario_usuarios");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Codproducto);

                entity.ToTable("productos");

                entity.Property(e => e.Codproducto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codproducto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Idcategoria)
                    .HasConstraintName("FK_productos_categorias");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.Idproveedor);

                entity.ToTable("proveedor");

                entity.Property(e => e.Idproveedor).HasColumnName("idproveedor");

                entity.Property(e => e.Direccion)
                    .HasColumnType("text")
                    .HasColumnName("direccion");

                entity.Property(e => e.Empresa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("empresa");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.Idsucursal);

                entity.ToTable("sucursal");

                entity.Property(e => e.Idsucursal).HasColumnName("idsucursal");

                entity.Property(e => e.Direccion)
                    .HasColumnType("text")
                    .HasColumnName("direccion");

                entity.Property(e => e.Encargado)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("encargado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dui)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("dui");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Rol).HasColumnName("rol");

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
