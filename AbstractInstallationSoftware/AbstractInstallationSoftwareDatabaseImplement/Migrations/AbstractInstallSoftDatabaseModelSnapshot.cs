﻿// <auto-generated />
using System;
using AbstractInstallationSoftwareDatabaseImplement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AbstractInstallationSoftwareDatabaseImplement.Migrations
{
    [DbContext(typeof(AbstractInstallSoftDatabase))]
    partial class AbstractInstallSoftDatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AbstractInstallationSoftwareDatabaseImplement.Models.Component", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ComponentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("AbstractInstallationSoftwareDatabaseImplement.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateImplement")
                        .HasColumnType("datetime2");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PackageId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("AbstractInstallationSoftwareDatabaseImplement.Models.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PackageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("AbstractInstallationSoftwareDatabaseImplement.Models.PackageComponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ComponentId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComponentId");

                    b.HasIndex("PackageId");

                    b.ToTable("PackageComponents");
                });

            modelBuilder.Entity("AbstractInstallationSoftwareDatabaseImplement.Models.Order", b =>
                {
                    b.HasOne("AbstractInstallationSoftwareDatabaseImplement.Models.Package", "Package")
                        .WithMany("Orders")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AbstractInstallationSoftwareDatabaseImplement.Models.PackageComponent", b =>
                {
                    b.HasOne("AbstractInstallationSoftwareDatabaseImplement.Models.Component", "Component")
                        .WithMany("PackageComponents")
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AbstractInstallationSoftwareDatabaseImplement.Models.Package", "Package")
                        .WithMany("PackageComponents")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
