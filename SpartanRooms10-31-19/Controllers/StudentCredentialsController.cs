using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpartanRoomsData;
using SpartanRoomsData.Models;

namespace SpartanRooms10_31_19.Controllers
{
    public class StudentCredentialsController : Controller
    {
        private readonly DataContext _context;

        public StudentCredentialsController(DataContext context)
        {
            _context = context;
        }

        // GET: StudentCredentials
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentCredentials.ToListAsync());
        }

        // GET: StudentCredentials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCredentials = await _context.StudentCredentials
                .FirstOrDefaultAsync(m => m.ID == id);
            if (studentCredentials == null)
            {
                return NotFound();
            }

            return View(studentCredentials);
        }

        // GET: StudentCredentials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentCredentials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SJSUID,Name,Username,Password")] StudentCredentials studentCredentials)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentCredentials);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentCredentials);
        }

        // GET: StudentCredentials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCredentials = await _context.StudentCredentials.FindAsync(id);
            if (studentCredentials == null)
            {
                return NotFound();
            }
            return View(studentCredentials);
        }

        // POST: StudentCredentials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SJSUID,Name,Username,Password")] StudentCredentials studentCredentials)
        {
            if (id != studentCredentials.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentCredentials);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentCredentialsExists(studentCredentials.ID))
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
            return View(studentCredentials);
        }

        // GET: StudentCredentials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCredentials = await _context.StudentCredentials
                .FirstOrDefaultAsync(m => m.ID == id);
            if (studentCredentials == null)
            {
                return NotFound();
            }

            return View(studentCredentials);
        }

        // POST: StudentCredentials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentCredentials = await _context.StudentCredentials.FindAsync(id);
            _context.StudentCredentials.Remove(studentCredentials);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentCredentialsExists(int id)
        {
            return _context.StudentCredentials.Any(e => e.ID == id);
        }
    }
}
