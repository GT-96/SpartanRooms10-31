using System;
using System.Collections.Generic;
using System.Text;

namespace SpartanRoomsData.Models
{
    public class BookingContainer
    {
        public int ID { get; set; }

        public Room? Room { get; set; }

        public DateTime DateTime { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
        public bool isFull { get; set; }

        public int RoomID { get; set; }

    }
}
