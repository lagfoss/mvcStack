using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StackITmvc.Data;
using StackITmvc.Models;
using StackITmvc.Models.StackItViewModels;

namespace StackITmvc.Controllers
{
    public class SubscriptionsController : Controller
    {
        private readonly StackItContext _context;

        public SubscriptionsController(StackItContext context)
        {
            _context = context;
        }

        // GET: Subscriptions
        public async Task<IActionResult> Index()
        {
            var stackItContext = _context.Subscription
                .Include(s => s.Company)
                .Include(s => s.K_AdminSubscriptions)
                    .ThenInclude(s => s.K_Admin)
                .Include(s => s.Hardware)
                .Include(s => s.SubscriptionJobs)
                    .ThenInclude(s => s.Job);

            return View(await stackItContext.ToListAsync());
        }

        // GET: Subscriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscription
                .Include(s => s.Company)
                .Include(s => s.K_AdminSubscriptions)
                    .ThenInclude(s => s.K_Admin)
                .Include(s => s.Hardware)
                .Include(s => s.SubscriptionJobs)
                    .ThenInclude(s => s.Job)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.SubscriptionId == id);
            if (subscription == null)
            {
                return NotFound();
            }

            return View(subscription);
        }

        // GET: Subscriptions/Create
        public IActionResult Create()
        {
            //ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CompanyName");
            //ViewData["HardwareId"] = new SelectList(_context.Hardware, "HardwareId", "HardwareName");
            PopulateCompanyDropDownList();
            PopulateHardwareDropDownList();
            var subscription = new Subscription
            {
                K_AdminSubscriptions = new List<K_AdminSubscriptions>(),
                SubscriptionJobs = new List<SubscriptionJobs>()
            };
            PopulateAssignedK_AdminData(subscription);
            PopulateAssignedJobData(subscription);
            return View();
        }

        // POST: Subscriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubscriptionId,SubscriptionName,CustomerId,HardwareId")] Subscription subscription, string[] selectedK_Admins, string[] selectedJobs)
        {
            if (selectedK_Admins != null)
            {
                subscription.K_AdminSubscriptions = new List<K_AdminSubscriptions>();
                foreach (var k_admin in selectedK_Admins)
                {
                    var k_adminToAdd = new K_AdminSubscriptions { SubscriptionId = subscription.SubscriptionId, K_AdminId = int.Parse(k_admin) };
                    subscription.K_AdminSubscriptions.Add(k_adminToAdd);
                }
            }
            if (selectedJobs != null)
            {
                subscription.SubscriptionJobs = new List<SubscriptionJobs>();
                foreach (var job in selectedJobs)
                {
                    var jobToAdd = new SubscriptionJobs { SubscriptionId = subscription.SubscriptionId, JobId = int.Parse(job) };
                    subscription.SubscriptionJobs.Add(jobToAdd);
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(subscription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CompanyName", subscription.CustomerId);
            //ViewData["HardwareId"] = new SelectList(_context.Hardware, "HardwareId", "HardwareName", subscription.HardwareId);
            PopulateCompanyDropDownList(subscription.CustomerId);
            PopulateHardwareDropDownList(subscription.HardwareId);
            PopulateAssignedK_AdminData(subscription);
            PopulateAssignedJobData(subscription);
            return View(subscription);
        }

        // GET: Subscriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscription
                .Include(i => i.K_AdminSubscriptions).ThenInclude(i => i.K_Admin)
                .Include(i => i.SubscriptionJobs).ThenInclude(i => i.Job)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.SubscriptionId == id);
            if (subscription == null)
            {
                return NotFound();
            }
            //ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CompanyName", subscription.CustomerId);
            //ViewData["HardwareId"] = new SelectList(_context.Hardware, "HardwareId", "HardwareName", subscription.HardwareId);
            PopulateCompanyDropDownList(subscription.CustomerId);
            PopulateHardwareDropDownList(subscription.HardwareId);
            PopulateAssignedK_AdminData(subscription);
            PopulateAssignedJobData(subscription);
            return View(subscription);
        }

        private void PopulateAssignedK_AdminData(Subscription subscription)
        {
            var allK_Admins = _context.K_Admin;
            var subscriptionK_Admins = new HashSet<int>(subscription.K_AdminSubscriptions.Select(k => k.K_AdminId));
            var viewModel = new List<AssignedK_AdminData>();
            foreach (var k_admin in allK_Admins)
            {
                viewModel.Add(new AssignedK_AdminData
                {
                    K_AdminId = k_admin.K_AdminId,
                    K_AdminName = k_admin.FullName,
                    Assigned = subscriptionK_Admins.Contains(k_admin.K_AdminId)
                });
            }
            ViewData["K_Admins"] = viewModel;
        }

        private void PopulateAssignedJobData(Subscription subscription)
        {
            var allJobs = _context.Job;
            var subscriptionJobs = new HashSet<int>(subscription.SubscriptionJobs.Select(j => j.JobId));
            var viewModel = new List<AssignedJobData>();
            foreach (var job in allJobs)
            {
                viewModel.Add(new AssignedJobData
                {
                    JobId = job.JobId,
                    JobName = job.JobName,
                    Assigned = subscriptionJobs.Contains(job.JobId)
                });
            }
            ViewData["Jobs"] = viewModel;
        }

        // POST: Subscriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string[] selectedK_Admins, string[] selectedJobs)
        {
            if (id == null)
            {
                return NotFound();
            }
            var subscriptionToUpdate = await _context.Subscription
                .Include(i => i.K_AdminSubscriptions)
                    .ThenInclude(i => i.K_Admin)
                .Include(i => i.SubscriptionJobs)
                    .ThenInclude(i => i.Job)
                .FirstOrDefaultAsync(s => s.SubscriptionId == id);

            if (await TryUpdateModelAsync<Subscription>(subscriptionToUpdate,
                "",
                s => s.SubscriptionName, s => s.CustomerId, s => s.HardwareId))
            {
                UpdateK_AdminSubscriptions(selectedK_Admins, subscriptionToUpdate);
                UpdateSubscriptionJobs(selectedJobs, subscriptionToUpdate);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateCompanyDropDownList(subscriptionToUpdate.CustomerId);
            PopulateHardwareDropDownList(subscriptionToUpdate.HardwareId);
            UpdateK_AdminSubscriptions(selectedK_Admins, subscriptionToUpdate);
            PopulateAssignedK_AdminData(subscriptionToUpdate);
            UpdateSubscriptionJobs(selectedJobs, subscriptionToUpdate);
            PopulateAssignedJobData(subscriptionToUpdate);
            return View(subscriptionToUpdate);
        }
        private void PopulateCompanyDropDownList(object selectedCompany = null)
        {
            var companysQuery = from s in _context.Customer
                                   orderby s.CompanyName
                                   select s;
            ViewBag.CustomerId = new SelectList(companysQuery.AsNoTracking(), "CustomerId", "CompanyName", selectedCompany);
        }

        private void PopulateHardwareDropDownList(object selectedHardware = null)
        {
            var hardwaresQuery = from h in _context.Hardware
                                orderby h.HardwareName
                                select h;
            ViewBag.HardwareId = new SelectList(hardwaresQuery.AsNoTracking(), "HardwareId", "HardwareName", selectedHardware);
        }

        private void UpdateK_AdminSubscriptions(string[] selectedK_Admins, Subscription subscriptionToUpdate)
        {
            if (selectedK_Admins == null)
            {
                subscriptionToUpdate.K_AdminSubscriptions = new List<K_AdminSubscriptions>();
                return;
            }

            var selectedK_AdminsHS = new HashSet<string>(selectedK_Admins);
            var subscriptionK_Admins = new HashSet<int>
                (subscriptionToUpdate.K_AdminSubscriptions.Select(k => k.K_Admin.K_AdminId));
            foreach (var k_admin in _context.K_Admin)
            {
                if (selectedK_AdminsHS.Contains(k_admin.K_AdminId.ToString()))
                {
                    if (!subscriptionK_Admins.Contains(k_admin.K_AdminId))
                    {
                        subscriptionToUpdate.K_AdminSubscriptions.Add(new K_AdminSubscriptions { SubscriptionId = subscriptionToUpdate.SubscriptionId, K_AdminId = k_admin.K_AdminId });
                    }
                }
                else
                {
                    if (subscriptionK_Admins.Contains(k_admin.K_AdminId))
                    {
                        K_AdminSubscriptions k_adminToRemove = subscriptionToUpdate.K_AdminSubscriptions.FirstOrDefault(i => i.K_AdminId == k_admin.K_AdminId);
                        _context.Remove(k_adminToRemove);
                    }
                }
            }
        }

        private void UpdateSubscriptionJobs(string[] selectedJobs, Subscription subscriptionToUpdate)
        {
            if (selectedJobs == null)
            {
                subscriptionToUpdate.SubscriptionJobs = new List<SubscriptionJobs>();
                return;
            }

            var selectedJobsHS = new HashSet<string>(selectedJobs);
            var subscriptionJobs = new HashSet<int>
                (subscriptionToUpdate.SubscriptionJobs.Select(j => j.Job.JobId));
            foreach (var job in _context.Job)
            {
                if (selectedJobsHS.Contains(job.JobId.ToString()))
                {
                    if (!subscriptionJobs.Contains(job.JobId))
                    {
                        subscriptionToUpdate.SubscriptionJobs.Add(new SubscriptionJobs { SubscriptionId = subscriptionToUpdate.SubscriptionId, JobId = job.JobId });
                    }
                }
                else
                {
                    if (subscriptionJobs.Contains(job.JobId))
                    {
                        SubscriptionJobs jobToRemove = subscriptionToUpdate.SubscriptionJobs.FirstOrDefault(i => i.JobId == job.JobId);
                        _context.Remove(jobToRemove);
                    }
                }
            }
        }
        /*public async Task<IActionResult> Edit(int id, [Bind("SubscriptionId,SubscriptionName,CustomerId,HardwareId")] Subscription subscription)
        {
            if (id != subscription.SubscriptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subscription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubscriptionExists(subscription.SubscriptionId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CompanyName", subscription.CustomerId);
            ViewData["HardwareId"] = new SelectList(_context.Hardware, "HardwareId", "HardwareName", subscription.HardwareId);
            return View(subscription);
        }*/

        // GET: Subscriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscription
                .Include(s => s.Company)
                .Include(s => s.Hardware)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.SubscriptionId == id);
            if (subscription == null)
            {
                return NotFound();
            }

            return View(subscription);
        }

        // POST: Subscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subscription = await _context.Subscription.FindAsync(id);
            _context.Subscription.Remove(subscription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubscriptionExists(int id)
        {
            return _context.Subscription.Any(e => e.SubscriptionId == id);
        }
    }
}
