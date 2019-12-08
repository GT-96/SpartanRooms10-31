using NUnit.Framework;
using SpartanRoomsData.Models;
using System.Collections.Generic;
namespace TestCases1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RoomTest()
        {
            //Room get set ID Test
            Room Room = new Room();
            Room.ID = 5;
            var ID = Room.ID;
            Assert.AreEqual(ID, 5);

            //Room get set RoomName
            Room.RoomName = "Engr 101";
            string roomName = Room.RoomName;
            Assert.AreEqual(roomName, "Engr 101");

            //Room get set Type
            Room.Type = RoomType.GroupStudy;
            RoomType roomType = RoomType.GroupStudy;
            Assert.AreEqual(roomType, Room.Type);

            //Room get set UnlockInstruction
            UnlockInstruction unloackInstruction = new UnlockInstruction();
            unloackInstruction.Instruction = "get key from the front desk";
            unloackInstruction.UnlockInstructionID = 2;
            unloackInstruction.UnlockType = unlockType.key;
            var instructions = new List<UnlockInstruction> { unloackInstruction };
            Room.UnlockInstructions = instructions;
            var testInstruction = instructions;
            Assert.AreEqual(testInstruction, Room.UnlockInstructions);

            //Room get set Resrvation
           
            Reservation reservation = new Reservation();
            reservation.ID = 10;
            reservation.ReservationString = "Study for CMPE133";
            reservation.Room = Room;
            Student s = new Student();
            s.ID = 1;
            s.Name = "s";
            var sReserveList = new List<Reservation>();
            sReserveList.Add(reservation);
            reservation.Student = s;
            reservation.DateTime = new System.DateTime(2019, 12, 1);
            reservation.BookingContainer = new BookingContainer();

            var reservationHistory = new List<Reservation>();
            reservationHistory.Add(reservation);
                        //set reservation to Room
            Room.HistoryOfReservations = reservationHistory;
                        //get reservation from Room
            var RoomReservationHistroy = Room.HistoryOfReservations;
            Assert.AreEqual(RoomReservationHistroy, Room.HistoryOfReservations);

            //Room get set capacity
            Room.Capacity = 35;
            var cap = Room.Capacity;
            Assert.AreEqual(cap, Room.Capacity);

            //Room get set Schedule
            Room.Schedule = new Schedule();
            var schedule = Room.Schedule;
            Assert.AreEqual(Room.Schedule, schedule);

            //Room get set Department
            Room.department = new Department();
            var dp = Room.department;
            Assert.AreEqual(Room.department, dp);
        }
        [Test]
        public void ReservationTest()
        {
            Reservation reservation = new Reservation();

            //Reservation get set ID
            reservation.ID = 5;
            var id = reservation.ID;
            Assert.AreEqual(reservation.ID, id);

            //Reservation get set Room
            reservation.Room = new Room();
            var room = reservation.Room;
            Assert.AreEqual(reservation.Room, room);

            //Reservation get set Student
            reservation.Student = new Student();
            reservation.Student.ID = 5;
            reservation.Student.Name = "John";
            var student = reservation.Student;
            Assert.AreEqual(student, reservation.Student);

            //Resrevation get set Reservation String
            reservation.ReservationString = "Study CMPE133";
            var str = reservation.ReservationString;
            Assert.AreEqual(reservation.ReservationString, str);
        }

        [Test]
        public void AdminTest()
        {
            //Admin get set ID
            Admin admin = new Admin();
            admin.AdminID = 78;
            var id = admin.AdminID;
            Assert.AreEqual(id, admin.AdminID);

            //Admin get set Name
            admin.Name = "John Doe";
            var name = admin.Name;
            Assert.AreEqual(name, admin.Name);
        }

        [Test]
        public void UnlockInstructionTest()
        {
            UnlockInstruction instruction = new UnlockInstruction();

            //UnloackInstruction get set ID
            instruction.UnlockInstructionID = 34;
            var instrID = instruction.UnlockInstructionID;
            Assert.AreEqual(instruction.UnlockInstructionID, instrID);

            //UnloackInstruction get set UnlockType
            instruction.UnlockType = unlockType.code;
            unlockType type = instruction.UnlockType;
            Assert.AreEqual(instruction.UnlockType, type);

            //UloackInstruction get set Instruction
            instruction.Instruction = "Enter the Code";
            string InstructionToUnloack = instruction.Instruction;
            Assert.AreEqual(InstructionToUnloack, instruction.Instruction);
        }

        [Test]
        public void StudentTest()
        {
            Student student = new Student();

            //Student get set ID
            student.ID = 12;
            var id = student.ID;
            Assert.AreEqual(id, student.ID);

            //Student get set Name
            student.Name = "Bob";
            string name = student.Name;
            Assert.AreEqual(name, student.Name);

            //Student get set Reservation
            Reservation reservation = new Reservation();
            reservation.ID = 10;
            reservation.ReservationString = "Study for CMPE133";
            reservation.Room = new Room();

            student.Reservations = new List<Reservation>();
            student.Reservations.Add(reservation);
            var reservationList = student.Reservations;
            Assert.AreEqual(reservationList, student.Reservations);
        }

        [Test]
        public void ScheduleTest()
        {
            Schedule schedule = new Schedule();

            //Schedule get set ID
            schedule.ID = 10;
            var id = schedule.ID;
            Assert.AreEqual(schedule.ID, id);

            //Schedule get set DateTime
            schedule.Dates = new List<CallenderDate>();
            CallenderDate date = new CallenderDate();
            date.Id = 5;
            date.dateTime = new System.DateTime(2019, 12, 25);
            date.Date = "12/25/2019";
            schedule.Dates.Add(date);
            var calendardate = schedule.Dates;
            Assert.AreEqual(schedule.Dates, calendardate);
        }

        [Test]
        public void DepartmentTest()
        {
            Department department = new Department();

            //Deparment get set ID
            department.ID = 10;
            var id = department.ID;
            Assert.AreEqual(id, department.ID);

            //Department get set name
            department.DepartmentName = "Engineering";
            string dptname = department.DepartmentName;
            Assert.AreEqual(dptname, department.DepartmentName);

            //Department get set Room
            Room room1 = new Room();
            Room room2 = new Room();
            department.Rooms = new List<Room>();
            department.Rooms.Add(room1);
            department.Rooms.Add(room2);
            var dptRooms = department.Rooms;
            Assert.AreEqual(dptRooms, department.Rooms);
        }
    }
}