using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace taskApp.Migrations
{
    /// <inheritdoc />
    public partial class SomeFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Category");

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("87be8727-3d2e-45e7-b686-0049301f1ba9"),
                column: "StartDate",
                value: new DateTime(2023, 8, 29, 15, 59, 24, 657, DateTimeKind.Local).AddTicks(8830));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("a26e416a-7a3c-4caf-8613-45df7daf0908"),
                column: "StartDate",
                value: new DateTime(2023, 8, 29, 15, 59, 24, 657, DateTimeKind.Local).AddTicks(8872));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TaskId",
                table: "Category",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("9472d245-d46c-4b17-9f4a-f3870d674b72"),
                column: "TaskId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("ed937cce-c11d-4aa1-a503-49bd5075ad23"),
                column: "TaskId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("87be8727-3d2e-45e7-b686-0049301f1ba9"),
                column: "StartDate",
                value: new DateTime(2023, 8, 29, 15, 19, 56, 651, DateTimeKind.Local).AddTicks(8536));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("a26e416a-7a3c-4caf-8613-45df7daf0908"),
                column: "StartDate",
                value: new DateTime(2023, 8, 29, 15, 19, 56, 651, DateTimeKind.Local).AddTicks(8582));
        }
    }
}
