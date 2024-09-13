using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CaveProvider.Database.Migrations.PostgresMigrations
{
    /// <inheritdoc />
    public partial class AddTermsSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Terms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    AddedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Terms");
        }
    }
}
