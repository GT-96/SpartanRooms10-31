using Microsoft.EntityFrameworkCore;
using SpartanRoomsData.Models;
namespace SpartanRoomsData
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<CallenderDate> CallenderDates { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<FreeHour> FreeHours { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<UnlockInstruction> UnlockInstructions { get; set; }

        //public DbSet<RoomStudent> RoomStudents { get; set; }




    }
}
