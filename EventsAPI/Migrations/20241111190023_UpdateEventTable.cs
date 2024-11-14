﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventsAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEventTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    time = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    location = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    max_capacity = table.Column<int>(type: "int", nullable: false),
                    availableSpots = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    image_url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    role = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    event_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.id);
                    table.ForeignKey(
                        name: "FK_reservations_events_event_id",
                        column: x => x.event_id,
                        principalTable: "events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservations_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "events",
                columns: new[] { "id", "availableSpots", "date", "description", "image_url", "location", "max_capacity", "name", "status", "time" },
                values: new object[,]
                {
                    { 1, 500, new DateOnly(2024, 12, 11), "live music concert with local bands", "https://example.com/concert.jpg", "downtown arena", 500, "concert", "active", new TimeOnly(19, 0, 0) },
                    { 2, 50, new DateOnly(2024, 11, 21), "workshop on web development using .net", "https://example.com/workshop.jpg", "tech hub", 50, "workshop", "active", new TimeOnly(9, 0, 0) },
                    { 3, 1000, new DateOnly(2025, 1, 10), "annual tech conference featuring keynote speakers", "https://example.com/conference.jpg", "grand hall", 1000, "conference", "active", new TimeOnly(8, 0, 0) },
                    { 4, 200, new DateOnly(2024, 12, 1), "networking event for professionals in tech", "https://example.com/networking.jpg", "city center", 200, "networking event", "active", new TimeOnly(18, 0, 0) },
                    { 5, 300, new DateOnly(2024, 11, 26), "a celebration of food from around the world", "https://example.com/foodfestival.jpg", "city park", 300, "food festival", "active", new TimeOnly(12, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "address", "name", "password", "role" },
                values: new object[,]
                {
                    { 1, "juan.perez@email.com", "juan perez", "$2a$11$Caei.g4htap7bMWnfq0ikekY16095NN1uYvzwXKpZqrW8cFfWalca", true },
                    { 2, "maria.lopez@email.com", "maria lopez", "$2a$11$tpyUl2n/YeiCm0uY9dO8k.BVcX2Tc6XkLuGuzPXRK1nOUdeRyzbxe", false },
                    { 3, "carlos.gomez@email.com", "carlos gomez", "$2a$11$NiFgYVlsID9zwMYCoCzwEOfS4OKS96FGRrZzPKGoorUlj8bKdUuDK", true },
                    { 4, "ana.fernandez@email.com", "ana fernandez", "$2a$11$fehsfIYj2x3bKj4zcz0yYukX8dr5njCA71p2XxdDao1KU/f2R2Zgi", false },
                    { 5, "luis.torres@email.com", "luis torres", "$2a$11$3betGoIupZVS4lAllhZ4b.6ayZ4PI5w66lgrYomkdcWY.VtNpkI7K", true }
                });

            migrationBuilder.InsertData(
                table: "reservations",
                columns: new[] { "id", "event_id", "status", "user_id" },
                values: new object[,]
                {
                    { 1, 1, "confirmed", 1 },
                    { 2, 2, "confirmed", 2 },
                    { 3, 3, "pending", 3 },
                    { 4, 4, "confirmed", 4 },
                    { 5, 5, "cancelled", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_reservations_event_id",
                table: "reservations",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_user_id",
                table: "reservations",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservations");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}