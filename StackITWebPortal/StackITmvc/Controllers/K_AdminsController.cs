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
    public class K_AdminsController : Controller
    {
        private readonly StackItContext _context;

        public K_AdminsController(StackItContext context)
        {
            _context = context;
        }

        // GET: K_Admins
        public async Task<IActionResult> Index()
        {
            var stackItContext = _context.K_Admin.Include(k => k.Company);
            return View(await stackItContext.ToListAsync());
        }

        // GET: K_Admins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var k_Admin = await _context.K_Admin
                .Include(k => k.Company)
                .FirstOrDefaultAsync(m => m.K_AdminId == id);
            if (k_Admin == null)
            {
                return NotFound();
            }

            return View(k_Admin);
        }

        // GET: K_Admins/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CompanyName");
            return View();
        }

        // POST: K_Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("K_AdminId,CustomerId,FirstName,LastName,PhoneNo,Email")] K_Admin k_Admin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(k_Admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CompanyName", k_Admin.CustomerId);
            return View(k_Admin);
        }

        // GET: K_Admins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var k_Admin = await _context.K_Admin.FindAsync(id);
            if (k_Admin == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CompanyName", k_Admin.CustomerId);
            return View(k_Admin);
        }

        // POST: K_Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("K_AdminId,CustomerId,FirstName,LastName,PhoneNo,Email")] K_Admin k_Admin)
        {
            if (id != k_Admin.K_AdminId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(k_Admin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!K_AdminExists(k_Admin.K_AdminId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CompanyName", k_Admin.CustomerId);
            return View(k_Admin);
        }

        // GET: K_Admins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var k_Admin = await _context.K_Admin
                .Include(k => k.Company)
                .FirstOrDefaultAsync(m => m.K_AdminId == id);
            if (k_Admin == null)
            {
                return NotFound();
            }

            return View(k_Admin);
        }

        // POST: K_Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var k_Admin = await _context.K_Admin.FindAsync(id);
            _context.K_Admin.Remove(k_Admin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool K_AdminExists(int id)
        {
            return _context.K_Admin.Any(e => e.K_AdminId == id);
        }
    }
}
