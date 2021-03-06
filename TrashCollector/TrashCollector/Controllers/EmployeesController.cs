﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
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
            string myKey = new GoogleAPIKey().Key;
            ViewBag.Key = "https://maps.googleapis.com/maps/api/js?key=" + myKey + "&callback=initMap";
            employee.Days = _context.Days.ToList();
            DateTime today = DateTime.Now;
            SetAllPickupsThatAreNotForTodayToNotPickedUp(today);
            employee.Pickups = new List<Pickup>();
            GetPickups(employee, today);
            employee.Pickups = employee.Pickups.Where(p => p.PickedUp == null).OrderBy(p => p.Day_Id).ToList();
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
        private void SetAllPickupsThatAreNotForTodayToNotPickedUp(DateTime today)
        {
            List<Pickup> allPickups = _context.Pickups.ToList();
            foreach (Pickup pickup in allPickups)
            {
                if (pickup.Day.Name != today.DayOfWeek.ToString())
                {
                    pickup.PickedUp = null;
                }
            }
            _context.SaveChanges();
        }
        private void GetPickups(Employee employee, DateTime today)
        {
            employee.Pickups = _context.Pickups.Where(p => p.Address.Zip_Code == employee.ZipCode).Include(p => p.Address).Include(p => p.Address.Customer).ToList();
            AddRelevantOneTimePickups(employee, today);
            employee.Pickups.RemoveAll(p => today >= p.Start_Of_Pickup_Suspension && today <= p.End_Of_Pickup_Suspension);
            _context.SaveChanges();
        }
        private void AddRelevantOneTimePickups(Employee employee, DateTime today)
        {
            List<Pickup> OneTimePickups = _context.Pickups.Where(p => today.AddDays(7).Date > p.Date_Of_Extra_Pickup.Value.Date && today.Date <= p.Date_Of_Extra_Pickup.Value.Date && p.Address.Zip_Code == employee.ZipCode).Include(p => p.Address).Include(p => p.Address.Customer).ToList();
            List<Pickup> OneTimePickupsToAdd = new List<Pickup>();
            foreach (Pickup pickup in OneTimePickups)
            {
                Day pickupDay = _context.Days.FirstOrDefault(d => d.Name == pickup.Date_Of_Extra_Pickup.Value.DayOfWeek.ToString());
                Pickup toAdd = new Pickup()
                {
                    Id = pickup.Id,
                    Address_Id = pickup.Address_Id,
                    Address = pickup.Address,
                    Day = pickupDay,
                    Day_Id = pickupDay.Id,
                    PickedUp = null
                };
                OneTimePickupsToAdd.Add(toAdd);
            }
            employee.Pickups.AddRange(OneTimePickupsToAdd);
            _context.SaveChanges();
        }
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
        public ActionResult MarkComplete (int id, string day)
        {
            string today = DateTime.Now.DayOfWeek.ToString();
            if (today != day)
            {
                return RedirectToAction(nameof(Index));
            }
            Pickup pickup = _context.Pickups.Include(p => p.Address.Customer).Include(p => p.Day).FirstOrDefault(p => p.Id == id);
            if (pickup.Day.Name == day)
            {
                pickup.PickedUp = true;
            }
            else
            {
                pickup.Date_Of_Extra_Pickup = null;
            };
            pickup.Address.Customer.Balance_Due += 20;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult DisplayCustomerDetails(int id)
        {
            GoogleAPIKey keyClass = new GoogleAPIKey();
            string myKey = keyClass.Key;
            string identityUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            int employeeZipCode = _context.Employees.FirstOrDefault(e => e.IdentityUser_Id == identityUserId).ZipCode;
            List<Address> addresses = _context.Addresses.Where(a => a.Customer_Id == id && a.Zip_Code == employeeZipCode).Include(a => a.Customer).ToList();
            addresses[0].APIKey = "https://maps.googleapis.com/maps/api/js?key=" + myKey + "&callback=initMap";
            return View(addresses);
        }

    }
}