﻿// <auto-generated />
using System;
using CaveProvider.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CaveProvider.Database.Migrations.PostgresMigrations
{
    [DbContext(typeof(PostgresDbContext))]
    partial class PostgresDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CaveProvider.Core.Model.Institution.AcademicYear", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AddedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("AcademicYears");
                });

            modelBuilder.Entity("CaveProvider.Core.Model.Institution.Institution", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AddedBy")
                        .HasColumnType("text");

                    b.Property<string>("AlternativeCode")
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Logo")
                        .HasColumnType("text");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhysicalAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PostBoxAddress")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Institution");
                });

            modelBuilder.Entity("CaveProvider.Core.Model.Institution.Term", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AddedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Terms");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0f715c96-b14c-4505-8d14-64789908fdb3"),
                            DateAdded = new DateTime(2024, 9, 13, 11, 34, 11, 625, DateTimeKind.Utc).AddTicks(5898),
                            IsDeleted = false,
                            Name = "First Term"
                        },
                        new
                        {
                            Id = new Guid("88a0a0c8-d8a3-43d5-9f35-b9c0be502396"),
                            DateAdded = new DateTime(2024, 9, 13, 11, 34, 11, 625, DateTimeKind.Utc).AddTicks(5930),
                            IsDeleted = false,
                            Name = "Second Term"
                        },
                        new
                        {
                            Id = new Guid("c89f1868-f2cd-43a0-9202-c43560013956"),
                            DateAdded = new DateTime(2024, 9, 13, 11, 34, 11, 625, DateTimeKind.Utc).AddTicks(5932),
                            IsDeleted = false,
                            Name = "Third Term"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
