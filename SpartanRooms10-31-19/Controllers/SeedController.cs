using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpartanRoomsData;
using SpartanRoomsData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace SpartanRooms10_31_19.Controllers
{
    public class SeedController : Controller
    {
        private readonly DataContext _context;

        public SeedController(DataContext context)
        {
            _context = context;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
        public IActionResult index()
        {
            var x = _context.BookingContainers.ToList();
            if ( x.Count!= 0)
            {
                return View();
            }
            for (int i = 20; i>0; i--)
            {
                Student s = new Student();
                s.Name = "Student " + i;
                _context.Add(s);
            }



            for (int i = 20; i>0; i--)
            {
                Room r = new Room();
                r.RoomName = "Room " + i;
                RoomType type = RoomType.SilenStudy;
                if (i % 3 == 0)
                {
                    type = RoomType.SilenStudy;
                }
                if (i % 3 == 1)
                {
                    type = RoomType.GroupStudy;
                }
                if (i % 3 == 2)
                {
                    type = RoomType.Event;
                }
                r.Type = type;
                r.Capacity = 5;
                _context.Add(r);
            }
            _context.SaveChanges();



            for (int i=1; i<30;i++)
            {
                BookingContainer b = new BookingContainer();
                var day = ((4 + i) % 30)+1;
                var hour = ((i + 1) % 23)+1;
                b.DateTime = new DateTime(2019, 12, day,hour,1,1);
                b.DateTime.AddHours(i);

                List<Room> rooms = _context.Rooms.ToList();
                b.Room = rooms.ElementAt(i % rooms.Count());
                b.RoomID = b.Room.ID;


                Reservation initReservation = new Reservation();
                initReservation.ReservationString = "Initialized";
                b.Reservations = new List<Reservation>();
                b.Reservations.Add(initReservation);
                _context.Add(b);
            }
            _context.SaveChanges();





            return View();
        }
    }
}