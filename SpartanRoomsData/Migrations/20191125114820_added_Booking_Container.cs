using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpartanRoomsData.Migrations
{
    public partial class added_Booking_Container : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Rooms_RoomID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_RoomID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RoomID",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "BookingContainerID",
                table: "Reservations",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookingContainers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomID = table.Column<int>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    isFull = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingContainers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BookingContainers_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BookingContainerID",
                table: "Reservations",
                column: "BookingContainerID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingContainers_RoomID",
                table: "BookingContainers",
                column: "RoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_BookingContainers_BookingContainerID",
                table: "Reservations",
                column: "BookingContainerID",
                principalTable: "BookingContainers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_BookingContainers_BookingContainerID",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "BookingContainers");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_BookingContainerID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "BookingContainerID",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "RoomID",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_RoomID",
                table: "Students",
                column: "RoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Rooms_RoomID",
                table: "Students",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
