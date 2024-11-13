using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsAPI.Migrations
{
    /// <inheritdoc />
    public partial class CambioRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "users",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "id",
                keyValue: 1,
                column: "date",
                value: new DateOnly(2024, 12, 13));

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "id",
                keyValue: 2,
                column: "date",
                value: new DateOnly(2024, 11, 23));

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "id",
                keyValue: 3,
                column: "date",
                value: new DateOnly(2025, 1, 12));

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "id",
                keyValue: 4,
                column: "date",
                value: new DateOnly(2024, 12, 3));

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "id",
                keyValue: 5,
                column: "date",
                value: new DateOnly(2024, 11, 28));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "password", "role" },
                values: new object[] { "$2a$11$v3sV1Zc/leutNNZwvSt0z.3vXrCTTGo4Q2pJ1HuwAaCXp8DkTLv.O", "Admin" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "password", "role" },
                values: new object[] { "$2a$11$GU3pmeAKYlWQ8bFtdbPCZ./ephi3GpLWvh5rp8xNYLxm9vk7VnzVC", "User" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "password", "role" },
                values: new object[] { "$2a$11$fC98T2K9Gp3/swox2N9GL.SY0QvhHdfmjMc6HK0..HX5e4aLki1l6", "Admin" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "password", "role" },
                values: new object[] { "$2a$11$yHIgknMRVV5JAvSEk2JQUuK/lwV4sIUXNN.t3YYxb6RtEOsPcUU3G", "User" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "password", "role" },
                values: new object[] { "$2a$11$4z279pBUfpM5DWpx/wOofetcr2U8dshmGBjt8dBwTNliKFJFA4Znq", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "role",
                table: "users",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "id",
                keyValue: 1,
                column: "date",
                value: new DateOnly(2024, 12, 11));

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "id",
                keyValue: 2,
                column: "date",
                value: new DateOnly(2024, 11, 21));

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "id",
                keyValue: 3,
                column: "date",
                value: new DateOnly(2025, 1, 10));

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "id",
                keyValue: 4,
                column: "date",
                value: new DateOnly(2024, 12, 1));

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "id",
                keyValue: 5,
                column: "date",
                value: new DateOnly(2024, 11, 26));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "password", "role" },
                values: new object[] { "$2a$11$Caei.g4htap7bMWnfq0ikekY16095NN1uYvzwXKpZqrW8cFfWalca", true });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "password", "role" },
                values: new object[] { "$2a$11$tpyUl2n/YeiCm0uY9dO8k.BVcX2Tc6XkLuGuzPXRK1nOUdeRyzbxe", false });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "password", "role" },
                values: new object[] { "$2a$11$NiFgYVlsID9zwMYCoCzwEOfS4OKS96FGRrZzPKGoorUlj8bKdUuDK", true });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "password", "role" },
                values: new object[] { "$2a$11$fehsfIYj2x3bKj4zcz0yYukX8dr5njCA71p2XxdDao1KU/f2R2Zgi", false });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "password", "role" },
                values: new object[] { "$2a$11$3betGoIupZVS4lAllhZ4b.6ayZ4PI5w66lgrYomkdcWY.VtNpkI7K", true });
        }
    }
}
