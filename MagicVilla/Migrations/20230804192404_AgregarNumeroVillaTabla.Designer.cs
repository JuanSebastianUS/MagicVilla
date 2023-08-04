﻿// <auto-generated />
using System;
using MagicVilla_API.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVilla_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230804192404_AgregarNumeroVillaTabla")]
    partial class AgregarNumeroVillaTabla
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicVilla_API.Models.NumeroVilla", b =>
                {
                    b.Property<int>("VillaNumero")
                        .HasColumnType("int");

                    b.Property<string>("DetalleEspecial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("Villa")
                        .HasColumnType("int");

                    b.Property<int>("VillaId")
                        .HasColumnType("int");

                    b.HasKey("VillaNumero");

                    b.ToTable("NumeroVillas");
                });

            modelBuilder.Entity("MagicVilla_API.Models.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagenUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MetrosCuadrados")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ocupantes")
                        .HasColumnType("int");

                    b.Property<int>("Tarifa")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenidad = "",
                            Detalle = "Detalle de la Villa",
                            FechaActualizacion = new DateTime(2023, 8, 4, 14, 24, 3, 927, DateTimeKind.Local).AddTicks(9890),
                            FechaCreacion = new DateTime(2023, 8, 4, 14, 24, 3, 927, DateTimeKind.Local).AddTicks(9878),
                            ImagenUrl = "",
                            MetrosCuadrados = 5,
                            Nombre = "Villa Real",
                            Ocupantes = 5,
                            Tarifa = 200
                        },
                        new
                        {
                            Id = 2,
                            Amenidad = "",
                            Detalle = "Detalle de la Villa",
                            FechaActualizacion = new DateTime(2023, 8, 4, 14, 24, 3, 927, DateTimeKind.Local).AddTicks(9893),
                            FechaCreacion = new DateTime(2023, 8, 4, 14, 24, 3, 927, DateTimeKind.Local).AddTicks(9893),
                            ImagenUrl = "",
                            MetrosCuadrados = 4,
                            Nombre = "Villa Chica",
                            Ocupantes = 4,
                            Tarifa = 200
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
