using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RenomeandoCamposFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOOKING_GUEST_GuestId",
                table: "BOOKING");

            migrationBuilder.DropForeignKey(
                name: "FK_BOOKING_ROOM_RoomId",
                table: "BOOKING");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "BOOKING",
                newName: "ROOM_ID");

            migrationBuilder.RenameColumn(
                name: "GuestId",
                table: "BOOKING",
                newName: "GUEST_ID");

            migrationBuilder.RenameIndex(
                name: "IX_BOOKING_RoomId",
                table: "BOOKING",
                newName: "IX_BOOKING_ROOM_ID");

            migrationBuilder.RenameIndex(
                name: "IX_BOOKING_GuestId",
                table: "BOOKING",
                newName: "IX_BOOKING_GUEST_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BOOKING_GUEST_GUEST_ID",
                table: "BOOKING",
                column: "GUEST_ID",
                principalTable: "GUEST",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BOOKING_ROOM_ROOM_ID",
                table: "BOOKING",
                column: "ROOM_ID",
                principalTable: "ROOM",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOOKING_GUEST_GUEST_ID",
                table: "BOOKING");

            migrationBuilder.DropForeignKey(
                name: "FK_BOOKING_ROOM_ROOM_ID",
                table: "BOOKING");

            migrationBuilder.RenameColumn(
                name: "ROOM_ID",
                table: "BOOKING",
                newName: "RoomId");

            migrationBuilder.RenameColumn(
                name: "GUEST_ID",
                table: "BOOKING",
                newName: "GuestId");

            migrationBuilder.RenameIndex(
                name: "IX_BOOKING_ROOM_ID",
                table: "BOOKING",
                newName: "IX_BOOKING_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_BOOKING_GUEST_ID",
                table: "BOOKING",
                newName: "IX_BOOKING_GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_BOOKING_GUEST_GuestId",
                table: "BOOKING",
                column: "GuestId",
                principalTable: "GUEST",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BOOKING_ROOM_RoomId",
                table: "BOOKING",
                column: "RoomId",
                principalTable: "ROOM",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
