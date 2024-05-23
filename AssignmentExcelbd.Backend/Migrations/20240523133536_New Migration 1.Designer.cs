﻿// <auto-generated />
using System;
using AssignmentExcelbd.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AssignmentExcelbd.Backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240523133536_New Migration 1")]
    partial class NewMigration1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AssignmentExcelbd.Shared.Allergies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Allergies");
                });

            modelBuilder.Entity("AssignmentExcelbd.Shared.Allergies_Details", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AllergiesId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AllergiesId");

                    b.HasIndex("PatientId");

                    b.ToTable("Allergies_Details");
                });

            modelBuilder.Entity("AssignmentExcelbd.Shared.DiseasesInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Diseases");
                });

            modelBuilder.Entity("AssignmentExcelbd.Shared.NCD", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NCDs");
                });

            modelBuilder.Entity("AssignmentExcelbd.Shared.NCD_Details", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NcdId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NcdId");

                    b.HasIndex("PatientId");

                    b.ToTable("NCD_Details");
                });

            modelBuilder.Entity("AssignmentExcelbd.Shared.PatientInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DiseasesId")
                        .HasColumnType("int");

                    b.Property<string>("IsEpilepsy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DiseasesId");

                    b.ToTable("PatientInfos");
                });

            modelBuilder.Entity("AssignmentExcelbd.Shared.Allergies_Details", b =>
                {
                    b.HasOne("AssignmentExcelbd.Shared.Allergies", "Allergies")
                        .WithMany()
                        .HasForeignKey("AllergiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssignmentExcelbd.Shared.PatientInfo", "Patient")
                        .WithMany("Allergies_Details")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Allergies");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("AssignmentExcelbd.Shared.NCD_Details", b =>
                {
                    b.HasOne("AssignmentExcelbd.Shared.NCD", "NCD")
                        .WithMany()
                        .HasForeignKey("NcdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssignmentExcelbd.Shared.PatientInfo", "Patient")
                        .WithMany("NCD_Details")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NCD");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("AssignmentExcelbd.Shared.PatientInfo", b =>
                {
                    b.HasOne("AssignmentExcelbd.Shared.DiseasesInfo", "Diseases")
                        .WithMany()
                        .HasForeignKey("DiseasesId");

                    b.Navigation("Diseases");
                });

            modelBuilder.Entity("AssignmentExcelbd.Shared.PatientInfo", b =>
                {
                    b.Navigation("Allergies_Details");

                    b.Navigation("NCD_Details");
                });
#pragma warning restore 612, 618
        }
    }
}
