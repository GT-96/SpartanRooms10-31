using System;
using System.Collections.Generic;
using System.Text;

namespace SpartanRoomsData.Models
{
    public class StudentCredentials
    {
        public int ID { get; set; }

        public string SJSUID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Student Student { get; set; }
    }
}
