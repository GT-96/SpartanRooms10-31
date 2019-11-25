using Microsoft.EntityFrameworkCore.Migrations;

namespace SpartanRoomsData.Migrations
{
    public partial class possiblyAddedCascadeDeleteforBookingContainer2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_BookingContainers_BookingContainerID",
                table: "Reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_BookingContainers_BookingContainerID",
                table: "Reservations",
                column: "BookingContainerID",
                principalTable: "BookingContainers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_BookingContainers_BookingContainerID",
                table: "Reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_BookingContainers_BookingContainerID",
                table: "Reservations",
                column: "BookingContainerID",
                principalTable: "BookingContainers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
