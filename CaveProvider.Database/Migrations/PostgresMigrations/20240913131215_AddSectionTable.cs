using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CaveProvider.Database.Migrations.PostgresMigrations
{
    /// <inheritdoc />
    public partial class AddSectionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: new Guid("0f715c96-b14c-4505-8d14-64789908fdb3"));

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: new Guid("88a0a0c8-d8a3-43d5-9f35-b9c0be502396"));

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: new Guid("c89f1868-f2cd-43a0-9202-c43560013956"));

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    AddedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "Id", "AddedBy", "DateAdded", "DateLastModified", "IsDeleted", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("2893a102-5237-4e2b-bf36-ba6da1983b01"), null, new DateTime(2024, 9, 13, 13, 12, 14, 887, DateTimeKind.Utc).AddTicks(5552), null, false, null, "Second Term" },
                    { new Guid("66c6fa7a-fa3f-4e36-a313-d4b36b935aad"), null, new DateTime(2024, 9, 13, 13, 12, 14, 887, DateTimeKind.Utc).AddTicks(5515), null, false, null, "First Term" },
                    { new Guid("c88e9747-a7b8-4b5c-9117-8edbc7b5d2bf"), null, new DateTime(2024, 9, 13, 13, 12, 14, 887, DateTimeKind.Utc).AddTicks(5576), null, false, null, "Third Term" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: new Guid("2893a102-5237-4e2b-bf36-ba6da1983b01"));

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: new Guid("66c6fa7a-fa3f-4e36-a313-d4b36b935aad"));

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: new Guid("c88e9747-a7b8-4b5c-9117-8edbc7b5d2bf"));

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "Id", "AddedBy", "DateAdded", "DateLastModified", "IsDeleted", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("0f715c96-b14c-4505-8d14-64789908fdb3"), null, new DateTime(2024, 9, 13, 11, 34, 11, 625, DateTimeKind.Utc).AddTicks(5898), null, false, null, "First Term" },
                    { new Guid("88a0a0c8-d8a3-43d5-9f35-b9c0be502396"), null, new DateTime(2024, 9, 13, 11, 34, 11, 625, DateTimeKind.Utc).AddTicks(5930), null, false, null, "Second Term" },
                    { new Guid("c89f1868-f2cd-43a0-9202-c43560013956"), null, new DateTime(2024, 9, 13, 11, 34, 11, 625, DateTimeKind.Utc).AddTicks(5932), null, false, null, "Third Term" }
                });
        }
    }
}
