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
    public class UnlockInstructionController : Controller
    {
        private readonly DataContext _context;

        public UnlockInstructionController(DataContext context)
        {
            _context = context;
        }

        // GET: UnlockInstruction
        public async Task<IActionResult> Index()
        {
            return View(await _context.UnlockInstructions.ToListAsync());
        }

        // GET: UnlockInstruction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unlockInstruction = await _context.UnlockInstructions
                .FirstOrDefaultAsync(m => m.UnlockInstructionID == id);
            if (unlockInstruction == null)
            {
                return NotFound();
            }

            return View(unlockInstruction);
        }

        // GET: UnlockInstruction/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnlockInstruction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnlockInstructionID,UnlockType,Instruction")] UnlockInstruction unlockInstruction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unlockInstruction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unlockInstruction);
        }

        // GET: UnlockInstruction/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unlockInstruction = await _context.UnlockInstructions.FindAsync(id);
            if (unlockInstruction == null)
            {
                return NotFound();
            }
            return View(unlockInstruction);
        }

        // POST: UnlockInstruction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UnlockInstructionID,UnlockType,Instruction")] UnlockInstruction unlockInstruction)
        {
            if (id != unlockInstruction.UnlockInstructionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unlockInstruction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnlockInstructionExists(unlockInstruction.UnlockInstructionID))
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
            return View(unlockInstruction);
        }

        // GET: UnlockInstruction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unlockInstruction = await _context.UnlockInstructions
                .FirstOrDefaultAsync(m => m.UnlockInstructionID == id);
            if (unlockInstruction == null)
            {
                return NotFound();
            }

            return View(unlockInstruction);
        }

        // POST: UnlockInstruction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unlockInstruction = await _context.UnlockInstructions.FindAsync(id);
            _context.UnlockInstructions.Remove(unlockInstruction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnlockInstructionExists(int id)
        {
            return _context.UnlockInstructions.Any(e => e.UnlockInstructionID == id);
        }
    }
}
