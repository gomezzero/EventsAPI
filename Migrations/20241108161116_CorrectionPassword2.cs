using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventsAPI.Migrations
{
    /// <inheritdoc />
    public partial class CorrectionPassword2 : Migration
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
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    time = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                    { 1, 500, new DateTime(2024, 12, 8, 11, 11, 15, 757, DateTimeKind.Local).AddTicks(8886), "Live music concert with local bands", "https://example.com/concert.jpg", "Downtown Arena", 500, "Concert", "active", "19:00" },
                    { 2, 50, new DateTime(2024, 11, 18, 11, 11, 15, 757, DateTimeKind.Local).AddTicks(8915), "Workshop on web development using .NET", "https://example.com/workshop.jpg", "Tech Hub", 50, "Workshop", "active", "09:00" },
                    { 3, 1000, new DateTime(2025, 1, 7, 11, 11, 15, 757, DateTimeKind.Local).AddTicks(8919), "Annual tech conference featuring keynote speakers", "https://example.com/conference.jpg", "Grand Hall", 1000, "Conference", "active", "08:00" },
                    { 4, 200, new DateTime(2024, 11, 28, 11, 11, 15, 757, DateTimeKind.Local).AddTicks(8924), "Networking event for professionals in tech", "https://example.com/networking.jpg", "City Center", 200, "Networking Event", "active", "18:00" },
                    { 5, 300, new DateTime(2024, 11, 23, 11, 11, 15, 757, DateTimeKind.Local).AddTicks(8928), "A celebration of food from around the world", "https://example.com/foodfestival.jpg", "City Park", 300, "Food Festival", "active", "12:00" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "address", "name", "password", "role" },
                values: new object[,]
                {
                    { 1, "juan.perez@email.com", "jaun", "$2a$11$NCRdO6kYqO/zfiXkvVJWTeqUP9HIVRogg9gAgFI3TP6NFjUGbGDVu", true },
                    { 2, "maria.lopez@email.com", "Maria Lopez", "$2a$11$bUMS8gviI1PnVKFMoyZ0ruHTRAoP2t6qA0QvJp0x5reOqr3Q2wnb.", false },
                    { 3, "carlos.gomez@email.com", "Carlos Gomez", "$2a$11$nziVYwEKiGqXph5uxqm.cuVJuyhenu/r0dwYZI8j21xC1H6Wit8oK", true },
                    { 4, "ana.fernandez@email.com", "Ana Fernandez", "$2a$11$HJyEcQZB6lzepbhsBsxn4OylBKFtTrcWlrR4K9RIBw3i7EUc.xrHy", true },
                    { 5, "luis.torres@email.com", "Luis Torres", "$2a$11$RFENmIm0sB6BVYZnwBLwweOKvAE8auV9ao8ys/0DGFW7VvMNzWo6W", false }
                });

            migrationBuilder.InsertData(
                table: "reservations",
                columns: new[] { "id", "event_id", "status", "user_id" },
                values: new object[,]
                {
                    { 1, 1, "confirmed", 1 },
                    { 2, 2, "confirmed", 2 },
                    { 3, 3, "confirmed", 3 },
                    { 4, 4, "confirmed", 4 },
                    { 5, 5, "confirmed", 5 }
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
