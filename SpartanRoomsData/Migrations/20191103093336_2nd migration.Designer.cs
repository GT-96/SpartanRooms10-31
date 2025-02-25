﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpartanRoomsData;

namespace SpartanRoomsData.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191103093336_2nd migration")]
    partial class _2ndmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SpartanRoomsData.Models.CallenderDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ScheduleID")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleID");

                    b.ToTable("CallenderDate");
                });

            modelBuilder.Entity("SpartanRoomsData.Models.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("SpartanRoomsData.Models.FreeHour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DateId")
                        .HasColumnType("int");

                    b.Property<string>("Hour")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DateId");

                    b.ToTable("FreeHour");
                });

            modelBuilder.Entity("SpartanRoomsData.Models.Reservation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReservationString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoomID")
                        .HasColumnType("int");

                    b.Property<int?>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RoomID");

                    b.HasIndex("StudentID");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("SpartanRoomsData.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("RoomName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ScheduleID")
                        .HasColumnType("int");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.Property<int?>("departmentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ScheduleID");

                    b.HasIndex("departmentID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("SpartanRoomsData.Models.Schedule", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("ID");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("SpartanRoomsData.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoomID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RoomID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("SpartanRoomsData.Models.UnlockInstruction", b =>
                {
                    b.Property<int>("UnlockInstructionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Instruction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoomID")
                        .HasColumnType("int");

                    b.Property<int>("UnlockType")
                        .HasColumnType("int");

                    b.HasKey("UnlockInstructionID");

                    b.HasIndex("RoomID");

                    b.ToTable("UnlockInstruction");
                });

            modelBuilder.Entity("SpartanRoomsData.Models.CallenderDate", b =>
                {
                    b.HasOne("SpartanRoomsData.Models.Schedule", null)
                        .WithMany("Dates")
                        .HasForeignKey("ScheduleID");
                });

            modelBuilder.Entity("SpartanRoomsData.Models.FreeHour", b =>
                {
                    b.HasOne("SpartanRoomsData.Models.CallenderDate", "Date")
                        .WithMany("FreeHours")
                        .HasForeignKey("DateId");
                });

            modelBuilder.Entity("SpartanRoomsData.Models.Reservation", b =>
                {
                    b.HasOne("SpartanRoomsData.Models.Room", "Room")
                        .WithMany("Reservations")
                        .HasForeignKey("RoomID");

                    b.HasOne("SpartanRoomsData.Models.Student", "Student")
                        .WithMany("Reservations")
                        .HasForeignKey("StudentID");
                });

            modelBuilder.Entity("SpartanRoomsData.Models.Room", b =>
                {
                    b.HasOne("SpartanRoomsData.Models.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleID");

                    b.HasOne("SpartanRoomsData.Models.Department", "department")
                        .WithMany("Rooms")
                        .HasForeignKey("departmentID");
                });

            modelBuilder.Entity("SpartanRoomsData.Models.Student", b =>
                {
                    b.HasOne("SpartanRoomsData.Models.Room", null)
                        .WithMany("Students")
                        .HasForeignKey("RoomID");
                });

            modelBuilder.Entity("SpartanRoomsData.Models.UnlockInstruction", b =>
                {
                    b.HasOne("SpartanRoomsData.Models.Room", null)
                        .WithMany("UnlockInstructions")
                        .HasForeignKey("RoomID");
                });
#pragma warning restore 612, 618
        }
    }
}
