using System;
using System.Collections.Generic;
using System.Text;

namespace SpartanRoomsData.Models
{
    public class RoomStudent
    {
        public ICollection<Student> Students { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
