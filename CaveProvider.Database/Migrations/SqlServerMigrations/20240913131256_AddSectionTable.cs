using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CaveProvider.Database.Migrations.SqlServerMigrations
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
                keyValue: new Guid("14821966-8d27-4a07-861d-babd2ac402df"));

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: new Guid("d52fee49-2afc-4d0c-aa80-8af8add7938f"));

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: new Guid("e6b6a720-f6e4-42b6-be2f-a5cd0e73231b"));

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    { new Guid("084ee7ca-6414-4202-b672-f96324b9b71d"), null, new DateTime(2024, 9, 13, 13, 12, 55, 749, DateTimeKind.Utc).AddTicks(1149), null, false, null, "Second Term" },
                    { new Guid("963eba32-e84b-430d-b531-5a689c25fdc8"), null, new DateTime(2024, 9, 13, 13, 12, 55, 749, DateTimeKind.Utc).AddTicks(1119), null, false, null, "First Term" },
                    { new Guid("ae6b83f9-e5fe-414f-b290-2743cff4f3d1"), null, new DateTime(2024, 9, 13, 13, 12, 55, 749, DateTimeKind.Utc).AddTicks(1151), null, false, null, "Third Term" }
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
                keyValue: new Guid("084ee7ca-6414-4202-b672-f96324b9b71d"));

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: new Guid("963eba32-e84b-430d-b531-5a689c25fdc8"));

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: new Guid("ae6b83f9-e5fe-414f-b290-2743cff4f3d1"));

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
    }
}
