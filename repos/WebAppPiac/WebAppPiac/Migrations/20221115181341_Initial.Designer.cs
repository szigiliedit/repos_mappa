﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppPiac.Data;

namespace WebAppPiac.Migrations
{
    [DbContext(typeof(MyDatabaseContext))]
    [Migration("20221115181341_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("WebAppPiac.Models.Gyumolcs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Ar")
                        .HasColumnType("int");

                    b.Property<string>("KepUtvonala")
                        .HasColumnType("text");

                    b.Property<byte>("Minoseg")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("Nev")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Gyumolcs");
                });
#pragma warning restore 612, 618
        }
    }
}
