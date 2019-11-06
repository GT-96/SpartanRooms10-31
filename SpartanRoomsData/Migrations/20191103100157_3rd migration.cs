using Microsoft.EntityFrameworkCore.Migrations;

namespace SpartanRoomsData.Migrations
{
    public partial class _3rdmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CallenderDate_Schedule_ScheduleID",
                table: "CallenderDate");

            migrationBuilder.DropForeignKey(
                name: "FK_FreeHour_CallenderDate_DateId",
                table: "FreeHour");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Rooms_RoomID",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Student_StudentID",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Schedule_ScheduleID",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Department_departmentID",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Rooms_RoomID",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_UnlockInstruction_Rooms_RoomID",
                table: "UnlockInstruction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnlockInstruction",
                table: "UnlockInstruction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FreeHour",
                table: "FreeHour");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CallenderDate",
                table: "CallenderDate");

            migrationBuilder.RenameTable(
                name: "UnlockInstruction",
                newName: "UnlockInstructions");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Schedule",
                newName: "Schedules");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "Reservations");

            migrationBuilder.RenameTable(
                name: "FreeHour",
                newName: "FreeHours");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameTable(
                name: "CallenderDate",
                newName: "CallenderDates");

            migrationBuilder.RenameIndex(
                name: "IX_UnlockInstruction_RoomID",
                table: "UnlockInstructions",
                newName: "IX_UnlockInstructions_RoomID");

            migrationBuilder.RenameIndex(
                name: "IX_Student_RoomID",
                table: "Students",
                newName: "IX_Students_RoomID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_StudentID",
                table: "Reservations",
                newName: "IX_Reservations_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_RoomID",
                table: "Reservations",
                newName: "IX_Reservations_RoomID");

            migrationBuilder.RenameIndex(
                name: "IX_FreeHour_DateId",
                table: "FreeHours",
                newName: "IX_FreeHours_DateId");

            migrationBuilder.RenameIndex(
                name: "IX_CallenderDate_ScheduleID",
                table: "CallenderDates",
                newName: "IX_CallenderDates_ScheduleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnlockInstructions",
                table: "UnlockInstructions",
                column: "UnlockInstructionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FreeHours",
                table: "FreeHours",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CallenderDates",
                table: "CallenderDates",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CallenderDates_Schedules_ScheduleID",
                table: "CallenderDates",
                column: "ScheduleID",
                principalTable: "Schedules",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FreeHours_CallenderDates_DateId",
                table: "FreeHours",
                column: "DateId",
                principalTable: "CallenderDates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Rooms_RoomID",
                table: "Reservations",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Students_StudentID",
                table: "Reservations",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Schedules_ScheduleID",
                table: "Rooms",
                column: "ScheduleID",
                principalTable: "Schedules",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Departments_departmentID",
                table: "Rooms",
                column: "departmentID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Rooms_RoomID",
                table: "Students",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UnlockInstructions_Rooms_RoomID",
                table: "UnlockInstructions",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CallenderDates_Schedules_ScheduleID",
                table: "CallenderDates");

            migrationBuilder.DropForeignKey(
                name: "FK_FreeHours_CallenderDates_DateId",
                table: "FreeHours");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Rooms_RoomID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Students_StudentID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Schedules_ScheduleID",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Departments_departmentID",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Rooms_RoomID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_UnlockInstructions_Rooms_RoomID",
                table: "UnlockInstructions");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnlockInstructions",
                table: "UnlockInstructions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FreeHours",
                table: "FreeHours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CallenderDates",
                table: "CallenderDates");

            migrationBuilder.RenameTable(
                name: "UnlockInstructions",
                newName: "UnlockInstruction");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "Schedules",
                newName: "Schedule");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservation");

            migrationBuilder.RenameTable(
                name: "FreeHours",
                newName: "FreeHour");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameTable(
                name: "CallenderDates",
                newName: "CallenderDate");

            migrationBuilder.RenameIndex(
                name: "IX_UnlockInstructions_RoomID",
                table: "UnlockInstruction",
                newName: "IX_UnlockInstruction_RoomID");

            migrationBuilder.RenameIndex(
                name: "IX_Students_RoomID",
                table: "Student",
                newName: "IX_Student_RoomID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_StudentID",
                table: "Reservation",
                newName: "IX_Reservation_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_RoomID",
                table: "Reservation",
                newName: "IX_Reservation_RoomID");

            migrationBuilder.RenameIndex(
                name: "IX_FreeHours_DateId",
                table: "FreeHour",
                newName: "IX_FreeHour_DateId");

            migrationBuilder.RenameIndex(
                name: "IX_CallenderDates_ScheduleID",
                table: "CallenderDate",
                newName: "IX_CallenderDate_ScheduleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnlockInstruction",
                table: "UnlockInstruction",
                column: "UnlockInstructionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FreeHour",
                table: "FreeHour",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CallenderDate",
                table: "CallenderDate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CallenderDate_Schedule_ScheduleID",
                table: "CallenderDate",
                column: "ScheduleID",
                principalTable: "Schedule",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FreeHour_CallenderDate_DateId",
                table: "FreeHour",
                column: "DateId",
                principalTable: "CallenderDate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Rooms_RoomID",
                table: "Reservation",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Student_StudentID",
                table: "Reservation",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Schedule_ScheduleID",
                table: "Rooms",
                column: "ScheduleID",
                principalTable: "Schedule",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Department_departmentID",
                table: "Rooms",
                column: "departmentID",
                principalTable: "Department",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Rooms_RoomID",
                table: "Student",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UnlockInstruction_Rooms_RoomID",
                table: "UnlockInstruction",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
