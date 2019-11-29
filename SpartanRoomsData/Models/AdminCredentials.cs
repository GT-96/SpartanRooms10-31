using System;
using System.Collections.Generic;
using System.Text;

namespace SpartanRoomsData.Models
{
    public class AdminCredentials
    {
        public int ID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public Admin Admin { get; set; }
    }
}
