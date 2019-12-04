using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpartanRoomsData;
using SpartanRoomsData.Models;
namespace SpartanRooms10_31_19.Controllers
{
    public class SeedController : Controller
    {
        private readonly DataContext _context;

        public SeedController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Seed()
        {






            return View();
        }
    }
}