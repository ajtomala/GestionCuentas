using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
 
using Dominio.Entidades;

namespace Infraestructura.Context
{
    public partial class CuentaContext : DbContext
    {
        public CuentaContext()
        {
        }

        public CuentaContext(DbContextOptions<CuentaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Cuentum> Cuenta { get; set; }
        public virtual DbSet<Movimiento> Movimientos { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Personaid);

                entity.ToTable("Cliente");

                entity.HasIndex(e => e.Personaid, "IX_clienteid")
                    .IsUnique();

                entity.Property(e => e.Personaid).ValueGeneratedNever();

                entity.Property(e => e.Contrasenia)
                    .IsRequired()
                    .HasColumnName("contrasenia");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.HasOne(d => d.Persona)
                    .WithOne(p => p.Cliente)
                    .HasForeignKey<Cliente>(d => d.Personaid)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Cuentum>(entity =>
            {
                entity.HasKey(e => e.Cuentaid);

                entity.HasIndex(e => e.Clienteid, "IX_Cuenta_clienteid");

                entity.HasIndex(e => e.Numcuenta, "IX_Cuenta_numcuenta")
                    .IsUnique();

                entity.Property(e => e.Cuentaid).HasColumnName("cuentaid");

                entity.Property(e => e.Clienteid).HasColumnName("clienteid");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Numcuenta)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("numcuenta");

                entity.Property(e => e.Saldoinicial)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("saldoinicial");

                entity.Property(e => e.Tipocuenta)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("tipocuenta");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.Clienteid);
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.ToTable("Movimiento");

                entity.HasIndex(e => e.Cuentaid, "IX_Movimiento_cuentaid");

                entity.Property(e => e.Movimientoid).HasColumnName("movimientoid");

                entity.Property(e => e.Cuentaid).HasColumnName("cuentaid");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Saldo)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("saldo");

                entity.Property(e => e.Tipomovimiento)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("tipomovimiento");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.Cuenta)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.Cuentaid);
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Persona");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Identificacion)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
