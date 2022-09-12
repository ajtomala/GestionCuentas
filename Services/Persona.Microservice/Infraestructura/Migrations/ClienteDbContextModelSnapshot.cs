﻿// <auto-generated />
using System;
using Infraestructura.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infraestructura.Migrations
{
    [DbContext(typeof(ClienteDbContext))]
    partial class ClienteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dominio.Entidades.Cuenta", b =>
                {
                    b.Property<long>("cuentaid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("clienteid")
                        .HasColumnType("bigint");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("numcuenta")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("saldoinicial")
                        .HasColumnType("decimal(12,2)");

                    b.Property<string>("tipocuenta")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("cuentaid");

                    b.HasIndex("clienteid");

                    b.HasIndex("numcuenta")
                        .IsUnique();

                    b.ToTable("Cuenta");
                });

            modelBuilder.Entity("Dominio.Entidades.Movimiento", b =>
                {
                    b.Property<long>("movimientoid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("cuentaid")
                        .HasColumnType("bigint");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("saldo")
                        .HasColumnType("decimal(12,2)");

                    b.Property<string>("tipomovimiento")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("valor")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("movimientoid");

                    b.HasIndex("cuentaid");

                    b.ToTable("Movimiento");
                });

            modelBuilder.Entity("Dominio.Entidades.Persona", b =>
                {
                    b.Property<long>("Personaid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Personaid");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("Dominio.Entidades.Cliente", b =>
                {
                    b.HasBaseType("Dominio.Entidades.Persona");

                    b.Property<byte[]>("contrasenia")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.HasIndex("Personaid")
                        .IsUnique()
                        .HasDatabaseName("IX_clienteid");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Dominio.Entidades.Cuenta", b =>
                {
                    b.HasOne("Dominio.Entidades.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("clienteid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");
                });

            modelBuilder.Entity("Dominio.Entidades.Movimiento", b =>
                {
                    b.HasOne("Dominio.Entidades.Cuenta", "cuenta")
                        .WithMany("movimientos")
                        .HasForeignKey("cuentaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cuenta");
                });

            modelBuilder.Entity("Dominio.Entidades.Cliente", b =>
                {
                    b.HasOne("Dominio.Entidades.Persona", null)
                        .WithOne()
                        .HasForeignKey("Dominio.Entidades.Cliente", "Personaid")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Entidades.Cuenta", b =>
                {
                    b.Navigation("movimientos");
                });
#pragma warning restore 612, 618
        }
    }
}
