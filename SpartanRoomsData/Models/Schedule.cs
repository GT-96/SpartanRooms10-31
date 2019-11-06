using System;
using System.Collections.Generic;
using System.Text;

namespace SpartanRoomsData.Models
{
   public class Schedule
    {
        public int ID { get; set; }

        public virtual ICollection<CallenderDate>? Dates  { get; set; }
    }
}
