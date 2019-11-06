using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpartanRoomsData.Migrations
{
    public partial class _2ndmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScheduleID",
                table: "Rooms",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CallenderDate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(nullable: true),
                    dateTime = table.Column<DateTime>(nullable: false),
                    ScheduleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallenderDate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CallenderDate_Schedule_ScheduleID",
                        column: x => x.ScheduleID,
                        principalTable: "Schedule",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FreeHour",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hour = table.Column<string>(nullable: true),
                    DateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreeHour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FreeHour_CallenderDate_DateId",
                        column: x => x.DateId,
                        principalTable: "CallenderDate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ScheduleID",
                table: "Rooms",
                column: "ScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_CallenderDate_ScheduleID",
                table: "CallenderDate",
                column: "ScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_FreeHour_DateId",
                table: "FreeHour",
                column: "DateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Schedule_ScheduleID",
                table: "Rooms",
                column: "ScheduleID",
                principalTable: "Schedule",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Schedule_ScheduleID",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "FreeHour");

            migrationBuilder.DropTable(
                name: "CallenderDate");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_ScheduleID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ScheduleID",
                table: "Rooms");
        }
    }
}
