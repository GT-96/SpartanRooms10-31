using System;
using System.Collections.Generic;
using System.Text;

namespace SpartanRoomsData.Models
{
   public class Department
    {
        public int ID { get; set; }

        public string DepartmentName { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
