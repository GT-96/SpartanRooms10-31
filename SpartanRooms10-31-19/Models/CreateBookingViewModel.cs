using Microsoft.AspNetCore.Mvc.Rendering;
using SpartanRoomsData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanRooms10_31_19.Models
{
    public class CreateBookingViewModel
    {
        public BookingContainer BookingContainer { get; set; }

        public Room Room { get; set; }

        public List<Room> Rooms { get; set; }

        public List <SelectListItem> RoomIDs { get; set; }

        public List<string> PostedIDs { get; set; }

    }
}
