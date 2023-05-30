using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 5, 30, 13, 39, 35, 826, DateTimeKind.Utc).AddTicks(9817), new DateTime(2023, 5, 30, 13, 39, 35, 826, DateTimeKind.Utc).AddTicks(9818) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 5, 30, 13, 39, 35, 826, DateTimeKind.Utc).AddTicks(9820), new DateTime(2023, 5, 30, 13, 39, 35, 826, DateTimeKind.Utc).AddTicks(9820) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 5, 30, 13, 39, 35, 826, DateTimeKind.Utc).AddTicks(9821), new DateTime(2023, 5, 30, 13, 39, 35, 826, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 5, 30, 13, 39, 35, 826, DateTimeKind.Utc).AddTicks(9934), new DateTime(2023, 5, 30, 13, 39, 35, 826, DateTimeKind.Utc).AddTicks(9934) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 5, 30, 13, 39, 35, 826, DateTimeKind.Utc).AddTicks(9936), new DateTime(2023, 5, 30, 13, 39, 35, 826, DateTimeKind.Utc).AddTicks(9937) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 5, 30, 13, 39, 35, 826, DateTimeKind.Utc).AddTicks(9938), new DateTime(2023, 5, 30, 13, 39, 35, 826, DateTimeKind.Utc).AddTicks(9938) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 5, 30, 13, 36, 54, 197, DateTimeKind.Utc).AddTicks(3633), new DateTime(2023, 5, 30, 13, 36, 54, 197, DateTimeKind.Utc).AddTicks(3635) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 5, 30, 13, 36, 54, 197, DateTimeKind.Utc).AddTicks(3637), new DateTime(2023, 5, 30, 13, 36, 54, 197, DateTimeKind.Utc).AddTicks(3637) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 5, 30, 13, 36, 54, 197, DateTimeKind.Utc).AddTicks(3638), new DateTime(2023, 5, 30, 13, 36, 54, 197, DateTimeKind.Utc).AddTicks(3639) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 5, 30, 13, 36, 54, 197, DateTimeKind.Utc).AddTicks(3757), new DateTime(2023, 5, 30, 13, 36, 54, 197, DateTimeKind.Utc).AddTicks(3757) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 5, 30, 13, 36, 54, 197, DateTimeKind.Utc).AddTicks(3760), new DateTime(2023, 5, 30, 13, 36, 54, 197, DateTimeKind.Utc).AddTicks(3760) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 5, 30, 13, 36, 54, 197, DateTimeKind.Utc).AddTicks(3761), new DateTime(2023, 5, 30, 13, 36, 54, 197, DateTimeKind.Utc).AddTicks(3761) });
        }
    }
}
