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
    public class K_OperatorsController : Controller
    {
        private readonly StackItContext _context;

        public K_OperatorsController(StackItContext context)
        {
            _context = context;
        }

        // GET: K_Operators
        public async Task<IActionResult> Index()
        {
            var stackItContext = _context.K_Operator.Include(k => k.Company);
            return View(await stackItContext.ToListAsync());
        }

        // GET: K_Operators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var k_Operator = await _context.K_Operator
                .Include(k => k.Company)
                .FirstOrDefaultAsync(m => m.K_OperatorId == id);
            if (k_Operator == null)
            {
                return NotFound();
            }

            return View(k_Operator);
        }

        // GET: K_Operators/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CompanyName");
            return View();
        }

        // POST: K_Operators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("K_OperatorId,CustomerId,FirstName,LastName,PhoneNo,Email")] K_Operator k_Operator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(k_Operator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CompanyName", k_Operator.CustomerId);
            return View(k_Operator);
        }

        // GET: K_Operators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var k_Operator = await _context.K_Operator.FindAsync(id);
            if (k_Operator == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CompanyName", k_Operator.CustomerId);
            return View(k_Operator);
        }

        // POST: K_Operators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("K_OperatorId,CustomerId,FirstName,LastName,PhoneNo,Email")] K_Operator k_Operator)
        {
            if (id != k_Operator.K_OperatorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(k_Operator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!K_OperatorExists(k_Operator.K_OperatorId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CompanyName", k_Operator.CustomerId);
            return View(k_Operator);
        }

        // GET: K_Operators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var k_Operator = await _context.K_Operator
                .Include(k => k.Company)
                .FirstOrDefaultAsync(m => m.K_OperatorId == id);
            if (k_Operator == null)
            {
                return NotFound();
            }

            return View(k_Operator);
        }

        // POST: K_Operators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var k_Operator = await _context.K_Operator.FindAsync(id);
            _context.K_Operator.Remove(k_Operator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool K_OperatorExists(int id)
        {
            return _context.K_Operator.Any(e => e.K_OperatorId == id);
        }
    }
}
