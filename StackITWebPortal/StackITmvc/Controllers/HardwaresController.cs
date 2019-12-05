using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StackITmvc.Data;
using StackITmvc.Models;

namespace StackITmvc.Controllers
{
    public class HardwaresController : Controller
    {
        private readonly StackItContext _context;

        public HardwaresController(StackItContext context)
        {
            _context = context;
        }

        // GET: Hardwares
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hardware.ToListAsync());
        }

        // GET: Hardwares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardware = await _context.Hardware
                .FirstOrDefaultAsync(m => m.HardwareId == id);
            if (hardware == null)
            {
                return NotFound();
            }

            return View(hardware);
        }

        // GET: Hardwares/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hardwares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HardwareId,HardwareName")] Hardware hardware)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hardware);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hardware);
        }

        // GET: Hardwares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardware = await _context.Hardware.FindAsync(id);
            if (hardware == null)
            {
                return NotFound();
            }
            return View(hardware);
        }

        // POST: Hardwares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HardwareId,HardwareName")] Hardware hardware)
        {
            if (id != hardware.HardwareId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hardware);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HardwareExists(hardware.HardwareId))
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
            return View(hardware);
        }

        // GET: Hardwares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardware = await _context.Hardware
                .FirstOrDefaultAsync(m => m.HardwareId == id);
            if (hardware == null)
            {
                return NotFound();
            }

            return View(hardware);
        }

        // POST: Hardwares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hardware = await _context.Hardware.FindAsync(id);
            _context.Hardware.Remove(hardware);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HardwareExists(int id)
        {
            return _context.Hardware.Any(e => e.HardwareId == id);
        }
    }
}
