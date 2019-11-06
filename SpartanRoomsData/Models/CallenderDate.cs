using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpartanRoomsData.Models
{
    public class CallenderDate
    {
        public int Id { get; set; }
        public string Date { get; set; }

        public DateTime dateTime { get; set; }

        //public Date DateOnly { get; set; }

        public virtual ICollection<FreeHour> FreeHours { get; set; }
    }
}
