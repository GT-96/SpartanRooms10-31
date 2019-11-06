using System;
using System.Collections.Generic;
using System.Text;

namespace SpartanRoomsData.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public string ReservationString { get; set; }
        public virtual DateTime DateTime { get; set; }
        public virtual Room Room { get; set; }
        public virtual Student Student { get; set; }
    }
}
