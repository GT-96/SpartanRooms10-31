using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpartanRooms10_31_19.Models;
using SpartanRoomsData;
using SpartanRoomsData.Models;

namespace SpartanRooms10_31_19.Controllers
{
    public class BookingContainerController : Controller
    {
        private readonly DataContext _context;

        public BookingContainerController(DataContext context)
        {
            _context = context;
        }

        // GET: BookingContainer
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookingContainers.ToListAsync());
        }

        // GET: BookingContainer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingContainer = await _context.BookingContainers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bookingContainer == null)
            {
                return NotFound();
            }

            return View(bookingContainer);
        }


        // GET: Reservations/Create
        public async Task<IActionResult> CreateReservation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.BookingContainers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (booking == null)
            {
                return NotFound();
            }
            var students = _context.Students.ToList();

            var CreateReservationsViewModel = new CreateReservationViewModel();


            //foreach(var student in students)
            //{
            //    CreateReservationsViewModel.Students.Add(student);

            //}
            CreateReservationsViewModel.BookingContainer = booking;
            CreateReservationsViewModel.Students = students;

            return View(CreateReservationsViewModel);
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReservation(int? id, CreateReservationViewModel viewModel)
        {

            if (id == null)
            {
                return NotFound();
            }

            BookingContainer bookingContainer = await _context.BookingContainers.FindAsync(id);
            if (bookingContainer == null)
            {
                return NotFound();
            }

            Reservation reservationContainer = new Reservation();
            //Student studentPostIform = values["Student"];
            if (ModelState.IsValid)
            {

                reservationContainer.Student = await _context.Students.FindAsync(viewModel.Student.ID);
                if (reservationContainer.Student == null)
                {
                    return NotFound();
                }
                bookingContainer.Reservations = new List<Reservation>();
                bookingContainer.Reservations.Add(reservationContainer);

                _context.Add(reservationContainer);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(bookingContainer);
        }




        // GET: BookingContainer/Create
        public IActionResult Create()
        {
            CreateBookingViewModel viewModel = new CreateBookingViewModel();

            viewModel.Rooms = _context.Rooms.ToList();

            return View(viewModel);
        }

        // POST: BookingContainer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookingViewModel viewModel)
        {
            //[Bind("ID,DateTime,isFull")]
        BookingContainer bookingContainer= new BookingContainer();

            if (ModelState.IsValid)
            {
                bookingContainer = viewModel.BookingContainer;
                Reservation firstReservation = new Reservation();
                firstReservation.ReservationString = "Initialized";
                bookingContainer.Reservations = new List<Reservation>();
                bookingContainer.Reservations.Add(firstReservation);

                _context.Add(bookingContainer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookingContainer);
        }

        // GET: BookingContainer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingContainer = await _context.BookingContainers.FindAsync(id);
            if (bookingContainer == null)
            {
                return NotFound();
            }
            return View(bookingContainer);
        }

        // POST: BookingContainer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DateTime,isFull")] BookingContainer bookingContainer)
        {
            if (id != bookingContainer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookingContainer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingContainerExists(bookingContainer.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bookingContainer);
        }

        // GET: BookingContainer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingContainer = await _context.BookingContainers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bookingContainer == null)
            {
                return NotFound();
            }

            return View(bookingContainer);
        }

        // POST: BookingContainer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookingContainer = await _context.BookingContainers.FindAsync(id);



            //var reservationsTable = await _context.Reservations.
            _context.BookingContainers.Remove(bookingContainer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingContainerExists(int id)
        {
            return _context.BookingContainers.Any(e => e.ID == id);
        }
    }
}
