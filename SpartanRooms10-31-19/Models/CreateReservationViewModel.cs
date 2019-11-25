using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpartanRoomsData;
using SpartanRoomsData.Models;

namespace SpartanRooms10_31_19.Models
{
    public class CreateReservationViewModel
    {
        public BookingContainer BookingContainer { get; set; }
        public List<Student> Students { get; set; }

        public Student Student { get; set; }

        //BookingContainer ID
        public int ID { get; set; }

        public Reservation Reservation { get; set; }

        //public Room? Room { get; set; }

        //public DateTime DateTime { get; set; }

        //public ICollection<Reservation> Reservations { get; set; }
        //public bool isFull { get; set; }
        //--------------------------------------------------

        //public int StudentID { get; set; }

        //public string StudentName { get; set; }


    }
}
