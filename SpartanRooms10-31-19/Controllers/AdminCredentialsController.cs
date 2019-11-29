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
    public class AdminCredentialsController : Controller
    {
        private readonly DataContext _context;

        public AdminCredentialsController(DataContext context)
        {
            _context = context;
        }

        // GET: AdminCredentials
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdminCredentials.ToListAsync());
        }

        // GET: AdminCredentials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminCredentials = await _context.AdminCredentials
                .FirstOrDefaultAsync(m => m.ID == id);
            if (adminCredentials == null)
            {
                return NotFound();
            }

            return View(adminCredentials);
        }

        // GET: AdminCredentials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminCredentials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Username,Password")] AdminCredentials adminCredentials)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminCredentials);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminCredentials);
        }

        // GET: AdminCredentials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminCredentials = await _context.AdminCredentials.FindAsync(id);
            if (adminCredentials == null)
            {
                return NotFound();
            }
            return View(adminCredentials);
        }

        // POST: AdminCredentials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Username,Password")] AdminCredentials adminCredentials)
        {
            if (id != adminCredentials.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminCredentials);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminCredentialsExists(adminCredentials.ID))
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
            return View(adminCredentials);
        }

        // GET: AdminCredentials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminCredentials = await _context.AdminCredentials
                .FirstOrDefaultAsync(m => m.ID == id);
            if (adminCredentials == null)
            {
                return NotFound();
            }

            return View(adminCredentials);
        }

        // POST: AdminCredentials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adminCredentials = await _context.AdminCredentials.FindAsync(id);
            _context.AdminCredentials.Remove(adminCredentials);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminCredentialsExists(int id)
        {
            return _context.AdminCredentials.Any(e => e.ID == id);
        }
    }
}
