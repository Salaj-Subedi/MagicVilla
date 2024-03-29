﻿// <auto-generated />
using System;
using MagicVilla.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVilla.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240107165703_AddVillaTable")]
    partial class AddVillaTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MagicVilla.Models.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Amenity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<int>("SqFt")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("updatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Magical_Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenity = "",
                            Details = "abcd acbef sdfsdfhubsdf",
                            ImageUrl = "",
                            Name = "villa1",
                            Occupancy = 5,
                            Rate = 500,
                            SqFt = 5000,
                            createdDate = new DateTime(2024, 1, 7, 22, 42, 3, 702, DateTimeKind.Local).AddTicks(4756)
                        },
                        new
                        {
                            Id = 2,
                            Amenity = "",
                            Details = "abcdsafasd acbef sdfsdfhubsdf",
                            ImageUrl = "",
                            Name = "villa2",
                            Occupancy = 6,
                            Rate = 300,
                            SqFt = 4000,
                            createdDate = new DateTime(2024, 1, 7, 22, 42, 3, 702, DateTimeKind.Local).AddTicks(4758)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
