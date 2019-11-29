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

        public DbSet<BookingContainer> BookingContainers { get; set; }

        public DbSet<StudentCredentials> StudentCredentials { get; set; }

        public DbSet<AdminCredentials> AdminCredentials { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasOne<BookingContainer>(b => b.BookingContainer)
                .WithMany(r => r.Reservations)
                .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<BookingContainer>()
            //    .HasMany<Reservation>(m => m.Reservations)
            //    .WithOne(b => b.BookingContainer)
            //    .HasForeignKey(k => k.BookingContainer)
            //    .OnDelete(DeleteBehavior.Cascade);
            ////.HasOptional(o => o.Room)
            ////.WithMany(m => m.Reservations)
            ////.HasForeignKey(k => k.BookingContainer)
            ////.WillCascadeOnDelete(true);
        }

    }
}
