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
        public ActionResult Index()
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Employee employee = _context.Employees.FirstOrDefault(e => e.IdentityUser_Id == currentUserId);
            DayOfWeek today = DateTime.Now.DayOfWeek;
            employee.Pickups = _context.Pickups.Where(p => p.Address.Zip_Code == employee.ZipCode && p.Day.Name == today.ToString()).Include(p => p.Address).ToList();

            //DateTime.Now

            return View(employee);
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