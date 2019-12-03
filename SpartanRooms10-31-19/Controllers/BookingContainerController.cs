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

        public IActionResult CalView()
        {
            return View();
        }

        // GET: BookingContainer
        public async Task<IActionResult> Index()
        {
            DisplayRoomsViewModel returnToView = new DisplayRoomsViewModel();
            returnToView.BookingContainerList = new List<BookingContainer>();
            returnToView.countOfRooms = new Dictionary<int, int>();

            returnToView.Rooms = new List<Room>();
            returnToView.initTimeArray();
            var bookingContainers = await _context.BookingContainers.ToListAsync();
            returnToView.Rooms = await _context.Rooms.ToListAsync();
            foreach(var booking in bookingContainers)
            {
                var result = (from a in _context.BookingContainers
                              where a.ID == booking.ID
                              select new BookingContainer { ID = a.ID, RoomID = a.RoomID, Reservations=a.Reservations, Room=a.Room, DateTime=a.DateTime }).ToList();

                if (result[0].Reservations.Count-1>= result[0].Room.Capacity)
                {
                    result[0].isFull = true;
                }

                returnToView.BookingContainerList.Add(result[0]);


                //Turns out I dont need to do this. 
                //" select new BookingContainer { ID = a.ID, RoomID = a.RoomID, Reservations=a.Reservations, Room=a.Room } finds all the related objects for me 0.0
                ////ADD ROOMS TO BOOKIINGCONTAINER
                ////add all returned booking containers into returnToViewList
                ////Should only be one though. booking.ID is unique primary key
                //foreach(var r in result)
                //{
                //    //finds all the Room objects with the same ID as r ( should only be 1 room obj)
                //    var rooms= (from a in _context.Rooms
                //                where a.ID == r.RoomID
                //                select new Room { ID = a.ID, RoomName =a.RoomName, Type=a.Type }).ToList();


                //    //var reservations = (from a in _context.Reservations
                //    //                    where a.)

                //    //should only run once since room.ID is unique
                //    foreach(var s in rooms)
                //    {
                //        //sets booking objects rooms to the related entries in database
                //        r.Room = s;
                //    }

                //    returnToView.Add(r);
                //}
                ////END OF ADD ROOMS TO BOOKING CONTAINER




                //var roomID = _context.BookingContainers.Include(i => i.RoomID).Where(r => r.ID == booking.ID);
                //booking.Room.ID= _context.BookingContainers.Find()
            }


            returnToView.BookingContainerList.Sort((x, y) => DateTime.Compare(x.DateTime, y.DateTime));

            var copyOfReturnToView = returnToView;
            copyOfReturnToView.BookingContainerList.Sort((x, y) => string.Compare(x.Room.RoomName.ToLower(), y.Room.RoomName.ToLower()));

            //string current="init";
            //string previous="init";
            //int count = 0;
            int[] countArray = new int[copyOfReturnToView.Rooms.Count];
            int countArrayIndex = 0;
            foreach(var item in returnToView.BookingContainerList)
            {
                countArrayIndex = 0;
                foreach (var room in copyOfReturnToView.Rooms)
                {
                    if (item.Room.ID == room.ID)
                    {
                        //copyOfReturnToView.BookingContainerList.Remove(item);
                        countArray[countArrayIndex]++;

                    }
                    countArrayIndex++;
                }

            }

            countArrayIndex = 0;

            foreach (var room in returnToView.Rooms)
            {
                returnToView.countOfRooms.Add(room.ID, countArray[countArrayIndex]);
                countArrayIndex++;
            }
            
            var dummy = 1;
            returnToView.alreadyRenderedRooms = new string[bookingContainers.Count];
            returnToView.alreadyCompletedRender = new List<string>();
            return View(returnToView);

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

            viewModel.RoomIDs = viewModel.Rooms.ConvertAll(a=>
            {
                return new SelectListItem()
                {
                    Text = a.RoomName.ToString(),
                    Value = a.ID.ToString(),
                    Selected = false
                };
            }
                );


            //foreach(var room in viewModel.Rooms)
            //{
            //    viewModel.RoomIDs.Add(room.ID.ToSele)

            //}
            viewModel.RoomIDs.Sort((x, y) => string.Compare(x.Text, y.Text));
            return View(viewModel);
        }


        // POST: BookingContainer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookingViewModel viewModel, List<CreateBookingViewModel> viewModelList)
        {
            //[Bind("ID,DateTime,isFull")]
        BookingContainer bookingContainer= new BookingContainer();
            int bookingContainersSize = viewModel.PostedIDs.Count;
            BookingContainer[] bookingContainers = new BookingContainer[bookingContainersSize]; ;

            if (ModelState.IsValid)
            {
                int i = 0;
                foreach(var entry in viewModel.PostedIDs)
                {
                    bookingContainers[i] = new BookingContainer();
                    bookingContainers[i].DateTime = viewModel.BookingContainer.DateTime;
                    var ID = Convert.ToInt32(viewModel.PostedIDs[i]);
                    bookingContainers[i].Room = _context.Rooms.Find(ID);


                    Reservation initReservation = new Reservation();
                    initReservation.ReservationString = "Initialized";
                    bookingContainers[i].Reservations = new List<Reservation>();
                    bookingContainers[i].Reservations.Add(initReservation);

                    _context.Add(bookingContainers[i]);
                    await _context.SaveChangesAsync();
                    i++;
                }
                //bookingContainer = viewModel.BookingContainer;
                //Reservation firstReservation = new Reservation();
                //firstReservation.ReservationString = "Initialized";
                //bookingContainer.Reservations = new List<Reservation>();
                //bookingContainer.Reservations.Add(firstReservation);

                //_context.Add(bookingContainer);
                //await _context.SaveChangesAsync();


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
