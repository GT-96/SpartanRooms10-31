using System;
using System.Collections.Generic;
using System.Text;

namespace SpartanRoomsData.Models
{
   public class FreeHour
    {
        public int Id { get; set; }

        public string Hour { get; set; }

        public CallenderDate Date { get; set; }
    }
}
