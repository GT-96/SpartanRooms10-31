using System;
using System.Collections.Generic;
using System.Text;

namespace SpartanRoomsData.Models
{

    public enum RoomType
    {
        SilenStudy,GroupStudy,Event
    }
   public class Room
    {

        //public Room()
        //{
        //   set Students = new ICollection<Student>();
        //}
        public int ID { get; set; }
        public string? RoomName { get; set; }

        public virtual RoomType? Type { get; set; }

        public virtual ICollection<UnlockInstruction> UnlockInstructions { get; set; }
        //public virtual ICollection<Student>? HistoryOfStudents { get; set; }

        public virtual ICollection<Reservation>? HistoryOfReservations { get; set; }


        //public ICollection<Schedule> Schedules { get; set; }
        //public virtual ICollection<DateTime>? Availability { get; set; }

        public int Capacity { get; set; }

        public Schedule Schedule { get; set; }
        public virtual Department? department { get; set; }

    }
}
