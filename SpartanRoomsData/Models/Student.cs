using System;
using System.Collections.Generic;
using System.Text;

namespace SpartanRoomsData.Models
{
    public class Student
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Reservation>? Reservations { get; set; }
    }
}
