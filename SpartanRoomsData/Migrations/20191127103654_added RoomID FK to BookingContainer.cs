using Microsoft.EntityFrameworkCore.Migrations;

namespace SpartanRoomsData.Migrations
{
    public partial class addedRoomIDFKtoBookingContainer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingContainers_Rooms_RoomID",
                table: "BookingContainers");

            migrationBuilder.AlterColumn<int>(
                name: "RoomID",
                table: "BookingContainers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingContainers_Rooms_RoomID",
                table: "BookingContainers",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingContainers_Rooms_RoomID",
                table: "BookingContainers");

            migrationBuilder.AlterColumn<int>(
                name: "RoomID",
                table: "BookingContainers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BookingContainers_Rooms_RoomID",
                table: "BookingContainers",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
