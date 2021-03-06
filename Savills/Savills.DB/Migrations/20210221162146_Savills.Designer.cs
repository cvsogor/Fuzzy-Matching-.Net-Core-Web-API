﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Savills.DB;

namespace Savills.DB.Migrations
{
    [DbContext(typeof(SavillsDbContext))]
    [Migration("20210221162146_Savills")]
    partial class Savills
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Savills.Data.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Floorarea")
                        .HasColumnType("int");

                    b.Property<int?>("Floorcount")
                        .HasColumnType("int");

                    b.Property<double?>("Lat")
                        .HasColumnType("float");

                    b.Property<double?>("Lon")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("S1Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("S1Id")
                        .HasColumnType("int");

                    b.Property<string>("S2Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("S2Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Savills.Data.S1", b =>
                {
                    b.Property<int?>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Floorcount")
                        .HasColumnType("int");

                    b.Property<double?>("Lat")
                        .HasColumnType("float");

                    b.Property<double?>("Lon")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("S1");
                });

            modelBuilder.Entity("Savills.Data.S2", b =>
                {
                    b.Property<int?>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Floorarea")
                        .HasColumnType("int");

                    b.Property<double?>("Lat")
                        .HasColumnType("float");

                    b.Property<double?>("Lon")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postcode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("S2");
                });
#pragma warning restore 612, 618
        }
    }
}
