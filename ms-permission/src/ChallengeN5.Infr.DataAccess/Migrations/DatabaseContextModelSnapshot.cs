﻿// <auto-generated />
using System;
using ChallengeN5.Infr.DataAccess.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChallengeN5.Infr.DataAccess.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ChallengeN5.Domain.AggregateRoots.Permission.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Unique ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("CreatedDate")
                        .HasColumnType("date")
                        .HasColumnName("FechaPermiso")
                        .HasComment("Permission granted on Date");

                    b.Property<string>("Forename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NombreEmpleado")
                        .HasComment("Employee Forename");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ApellidoEmpleado")
                        .HasComment("Employee Surname");

                    b.Property<int>("TypeId")
                        .HasColumnType("int")
                        .HasColumnName("TipoPermiso")
                        .HasComment("Permission Type");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Permisos", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateOnly(2023, 11, 14),
                            Forename = "Miguel",
                            Surname = "Garcia",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateOnly(2023, 11, 14),
                            Forename = "Pedro",
                            Surname = "Pereira",
                            TypeId = 3
                        });
                });

            modelBuilder.Entity("ChallengeN5.Domain.AggregateRoots.Permission.PermissionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Unique ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Descripcion")
                        .HasComment("Permission description");

                    b.HasKey("Id");

                    b.ToTable("TiposPermisos", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            Description = "READ_WRITE"
                        },
                        new
                        {
                            Id = 3,
                            Description = "WRITE"
                        },
                        new
                        {
                            Id = 4,
                            Description = "READ"
                        });
                });

            modelBuilder.Entity("ChallengeN5.Domain.AggregateRoots.Permission.Permission", b =>
                {
                    b.HasOne("ChallengeN5.Domain.AggregateRoots.Permission.PermissionType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });
#pragma warning restore 612, 618
        }
    }
}