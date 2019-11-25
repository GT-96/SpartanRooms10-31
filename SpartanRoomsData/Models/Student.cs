using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Primitives;

namespace SpartanRoomsData.Models
{
    public class Student
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Reservation>? Reservations { get; set; }

        public static implicit operator Student(StringValues v)
        {
            throw new NotImplementedException();
        }
    }
}
