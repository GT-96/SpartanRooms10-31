using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpartanRoomsData.Models;
namespace SpartanRooms10_31_19.Models
{
    public class DisplayRoomsViewModel
    {
        public List<BookingContainer> BookingContainerList { get; set; }
        public BookingContainer BookingContainer { get; set; }

        public List<DateTime> timeArray = new List<DateTime>();
         public List<Room> Rooms { get; set; }
        public string[] alreadyRenderedRooms { get; set; }
        public List<string> alreadyCompletedRender { get; set; }

        public Dictionary<int, int> countOfRooms { get; set; }
        public void initTimeArray()
        {
            for (int i = 0; i < 24; i++)
            {
                timeArray.Add(new DateTime(2019, 1, 1, i, 0, 0));
            }
        }
    }
}
