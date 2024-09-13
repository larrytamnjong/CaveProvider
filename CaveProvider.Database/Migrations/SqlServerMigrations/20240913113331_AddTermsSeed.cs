using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CaveProvider.Database.Migrations.SqlServerMigrations
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    { new Guid("14821966-8d27-4a07-861d-babd2ac402df"), null, new DateTime(2024, 9, 13, 11, 33, 30, 554, DateTimeKind.Utc).AddTicks(2954), null, false, null, "Third Term" },
                    { new Guid("d52fee49-2afc-4d0c-aa80-8af8add7938f"), null, new DateTime(2024, 9, 13, 11, 33, 30, 554, DateTimeKind.Utc).AddTicks(2921), null, false, null, "First Term" },
                    { new Guid("e6b6a720-f6e4-42b6-be2f-a5cd0e73231b"), null, new DateTime(2024, 9, 13, 11, 33, 30, 554, DateTimeKind.Utc).AddTicks(2951), null, false, null, "Second Term" }
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
