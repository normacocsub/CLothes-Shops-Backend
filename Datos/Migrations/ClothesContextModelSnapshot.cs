﻿// <auto-generated />
using System;
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Datos.Migrations
{
    [DbContext(typeof(ClothesContext))]
    partial class ClothesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entity.Categoria", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Categoria");

                    b.HasData(
                        new
                        {
                            Codigo = 1,
                            Nombre = "Camisas"
                        },
                        new
                        {
                            Codigo = 2,
                            Nombre = "Chaquetas"
                        },
                        new
                        {
                            Codigo = 3,
                            Nombre = "Faldas"
                        },
                        new
                        {
                            Codigo = 4,
                            Nombre = "Pantalones"
                        },
                        new
                        {
                            Codigo = 5,
                            Nombre = "Sudaderas"
                        },
                        new
                        {
                            Codigo = 6,
                            Nombre = "Vestidos"
                        });
                });

            modelBuilder.Entity("Entity.DetalleFactura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int?>("FacturaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FacturaId");

                    b.HasIndex("ProductoId");

                    b.ToTable("DetalleFactura");
                });

            modelBuilder.Entity("Entity.Factura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("Entity.Producto", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("UrlImagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Codigo");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("Entity.Rol", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Rol");

                    b.HasData(
                        new
                        {
                            Codigo = 1,
                            Nombre = "Administrador"
                        },
                        new
                        {
                            Codigo = 2,
                            Nombre = "Proveedor"
                        },
                        new
                        {
                            Codigo = 3,
                            Nombre = "Cliente"
                        });
                });

            modelBuilder.Entity("Entity.Usuario", b =>
                {
                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Correo");

                    b.HasIndex("RolId");

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            Correo = "admin123@gmail.com",
                            Apellido = "",
                            Cedula = "",
                            Ciudad = "",
                            Direccion = "",
                            Genero = "",
                            HashPassword = "CD0FD917F8A83A248614BCE69172839D2E06F30D77C6ADBD9DBD693DF6184ABE",
                            Nombre = "",
                            RolId = 1,
                            Telefono = ""
                        });
                });

            modelBuilder.Entity("Entity.DetalleFactura", b =>
                {
                    b.HasOne("Entity.Factura", null)
                        .WithMany("Detalles")
                        .HasForeignKey("FacturaId");

                    b.HasOne("Entity.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Entity.Factura", b =>
                {
                    b.HasOne("Entity.Usuario", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Entity.Producto", b =>
                {
                    b.HasOne("Entity.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Entity.Usuario", b =>
                {
                    b.HasOne("Entity.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Entity.Factura", b =>
                {
                    b.Navigation("Detalles");
                });
#pragma warning restore 612, 618
        }
    }
}