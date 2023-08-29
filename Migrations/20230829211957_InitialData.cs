using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace taskApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Importance", "Name", "TaskId" },
                values: new object[,]
                {
                    { new Guid("9472d245-d46c-4b17-9f4a-f3870d674b72"), "Home task of daily basis", 15, "Home", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("ed937cce-c11d-4aa1-a503-49bd5075ad23"), "SelfCare task to improve yourself", 20, "SelfCare", new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "Description", "EndDate", "StartDate", "TaskPriority", "Title" },
                values: new object[,]
                {
                    { new Guid("87be8727-3d2e-45e7-b686-0049301f1ba9"), new Guid("9472d245-d46c-4b17-9f4a-f3870d674b72"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 29, 15, 19, 56, 651, DateTimeKind.Local).AddTicks(8536), 1, "Wash the Dishes" },
                    { new Guid("a26e416a-7a3c-4caf-8613-45df7daf0908"), new Guid("ed937cce-c11d-4aa1-a503-49bd5075ad23"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 29, 15, 19, 56, 651, DateTimeKind.Local).AddTicks(8582), 1, "Meditate" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("87be8727-3d2e-45e7-b686-0049301f1ba9"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("a26e416a-7a3c-4caf-8613-45df7daf0908"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("9472d245-d46c-4b17-9f4a-f3870d674b72"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("ed937cce-c11d-4aa1-a503-49bd5075ad23"));
        }
    }
}
