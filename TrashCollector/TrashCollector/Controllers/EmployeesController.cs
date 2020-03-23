using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index(int todayId = 0)
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Employee employee = _context.Employees.FirstOrDefault(e => e.IdentityUser_Id == currentUserId);
            employee.Days = _context.Days.ToList();
            DateTime today = DateTime.Now;
            employee.Pickups = new List<Pickup>();
            GetPickups(employee, today);
            if (todayId == 0)
            {
                employee.Pickups = employee.Pickups.Where(p => p.Day.Name == today.DayOfWeek.ToString()).ToList();
            }
            else if (todayId != 8)
            {
                employee.Pickups = employee.Pickups.Where(p => p.Day_Id == todayId).ToList();
            }
            return View(employee);
        }
        private void GetPickups(Employee employee, DateTime today)
        {
            employee.Pickups = _context.Pickups.Where(p => p.Address.Zip_Code == employee.ZipCode).Include(p => p.Address).ToList();
            AddRelevantOneTimePickups(employee, today);
            employee.Pickups.RemoveAll(p => today >= p.Start_Of_Pickup_Suspension && today <= p.End_Of_Pickup_Suspension);
        }
        private void AddRelevantOneTimePickups(Employee employee, DateTime today)
        {
            List<Pickup> OneTimePickups = _context.Pickups.Where(p => today.AddDays(7).Day > p.Date_Of_Extra_Pickup.Value.Day && today.Day <= p.Date_Of_Extra_Pickup.Value.Day && p.Address.Zip_Code == employee.ZipCode).Include(p => p.Address).ToList();
            List<Pickup> OneTimePickupsToAdd = new List<Pickup>();
            foreach (Pickup pickup in OneTimePickups)
            {
                Day pickupDay = _context.Days.FirstOrDefault(d => d.Name == pickup.Date_Of_Extra_Pickup.Value.DayOfWeek.ToString());
                Pickup toAdd = new Pickup()
                {
                    Address = pickup.Address,
                    Day = pickupDay,
                    Day_Id = pickupDay.Id
                };
                OneTimePickupsToAdd.Add(toAdd);
            }
            employee.Pickups.AddRange(OneTimePickupsToAdd);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            string idForNewEmployee = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Employee employee = new Employee()
            {
                IdentityUser_Id = idForNewEmployee
            };
            return View(employee);
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(employee);
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employees/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}