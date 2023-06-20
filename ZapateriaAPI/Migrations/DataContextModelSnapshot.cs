﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZapateriaAPI.DbContexts;

#nullable disable

namespace ZapateriaAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ZapateriaAPI.Models.Inventary", b =>
                {
                    b.Property<int>("inventaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("inventaryId"));

                    b.Property<int>("Products")
                        .HasColumnType("int");

                    b.HasKey("inventaryId");

                    b.HasIndex("Products");

                    b.ToTable("Inventaries");
                });

            modelBuilder.Entity("ZapateriaAPI.Models.Products", b =>
                {
                    b.Property<int>("productId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("productId"));

                    b.Property<string>("productColor")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("productGenero")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("productMarca")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("productModelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("productPrecio")
                        .HasColumnType("float");

                    b.Property<double>("productTalla")
                        .HasMaxLength(4)
                        .HasColumnType("float");

                    b.Property<string>("productTipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productUbicacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("productId");

                    b.ToTable("Producties");

                    b.HasData(
                        new
                        {
                            productId = 1,
                            productColor = "Rojo",
                            productGenero = "F",
                            productMarca = "Nike",
                            productModelo = "Air Force 1",
                            productPrecio = 500.0,
                            productTalla = 42.5,
                            productTipo = "Rojo, con detalles negros",
                            productUbicacion = "Bodega"
                        },
                        new
                        {
                            productId = 2,
                            productColor = "Blanco",
                            productGenero = "F",
                            productMarca = "Adidas",
                            productModelo = "Road Street",
                            productPrecio = 500.0,
                            productTalla = 42.5,
                            productTipo = "Blanco, con detalles negros",
                            productUbicacion = "Bodega"
                        },
                        new
                        {
                            productId = 3,
                            productColor = "Amarillo",
                            productGenero = "F",
                            productMarca = "New Balance",
                            productModelo = "Zapatillas",
                            productPrecio = 500.0,
                            productTalla = 42.5,
                            productTipo = "Rojo, con detalles negros",
                            productUbicacion = "Bodega"
                        },
                        new
                        {
                            productId = 4,
                            productColor = "Verde",
                            productGenero = "F",
                            productMarca = "Lacoste",
                            productModelo = "Zapatos",
                            productPrecio = 500.0,
                            productTalla = 42.5,
                            productTipo = "Rojo, con detalles negros",
                            productUbicacion = "Bodega"
                        });
                });

            modelBuilder.Entity("ZapateriaAPI.Models.Sales", b =>
                {
                    b.Property<int>("SalesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalesId"));

                    b.Property<int>("SalesCantidad")
                        .HasColumnType("int");

                    b.Property<DateTime>("SalesFecha")
                        .HasColumnType("datetime2");

                    b.Property<double>("SalesPrecioV")
                        .HasColumnType("float");

                    b.Property<double>("SalesTotal")
                        .HasColumnType("float");

                    b.HasKey("SalesId");

                    b.ToTable("Saliers");
                });

            modelBuilder.Entity("ZapateriaAPI.Models.Temp_Products", b =>
                {
                    b.Property<int>("temp_productId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("temp_productId"));

                    b.Property<int>("productCantidad")
                        .HasColumnType("int");

                    b.Property<string>("productDescripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productGenero")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("productMarca")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("productModelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("productPrecio")
                        .HasColumnType("float");

                    b.Property<double>("productTalla")
                        .HasMaxLength(4)
                        .HasColumnType("float");

                    b.Property<string>("productUbicacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("temp_productId");

                    b.ToTable("Temp_Producties");
                });

            modelBuilder.Entity("ZapateriaAPI.Models.Inventary", b =>
                {
                    b.HasOne("ZapateriaAPI.Models.Products", "productsMarca")
                        .WithMany()
                        .HasForeignKey("Products")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("productsMarca");
                });
#pragma warning restore 612, 618
        }
    }
}
