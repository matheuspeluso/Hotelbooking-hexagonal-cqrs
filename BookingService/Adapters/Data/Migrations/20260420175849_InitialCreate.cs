using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GUEST",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SURNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GUEST", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ROOM",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LEVEL = table.Column<int>(type: "int", nullable: false),
                    IN_MAINTENANCE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROOM", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BOOKING",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PLACE_ADT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    START = table.Column<DateTime>(type: "datetime2", nullable: false),
                    END = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOOKING", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BOOKING_GUEST_GuestId",
                        column: x => x.GuestId,
                        principalTable: "GUEST",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BOOKING_ROOM_RoomId",
                        column: x => x.RoomId,
                        principalTable: "ROOM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BOOKING_GuestId",
                table: "BOOKING",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_BOOKING_RoomId",
                table: "BOOKING",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BOOKING");

            migrationBuilder.DropTable(
                name: "GUEST");

            migrationBuilder.DropTable(
                name: "ROOM");
        }
    }
}
