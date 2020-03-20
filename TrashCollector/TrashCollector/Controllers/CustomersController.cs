using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Customers
        public ActionResult Index()
        {
            Customer customer = _context.Customers.FirstOrDefault(c => c.IdentityUser_Id == this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(customer);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Create()
        {
            var identityUserID = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Customer customer = new Customer()
            {
                IdentityUser_Id = identityUserID
            };
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(new Customer());
            }
        }

        public ActionResult CreateAddress()
        {
            List<USState> uSStates = _context.USStates.ToList();
            string currentUser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customerId = _context.Customers.FirstOrDefault(c => c.IdentityUser.Id.Equals(currentUser)).Id;
            Address address = new Address()
            {
                USStates = uSStates,
                Customer_Id = customerId
            };
            return View(address);
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAddress(Address address)
        {
            try
            {
                _context.Addresses.Add(address);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(new Address());
            }
        }
        public ActionResult CreatePickup()
        {
            string identityUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            IEnumerable<Day> days = _context.Days;
            IEnumerable<Address> addresses = _context.Addresses.Where(a => a.Customer_Id == _context.Customers.FirstOrDefault(c => c.IdentityUser_Id == identityUserId).Id);
            foreach (Address address in addresses)
            {
                address.Single_Line_Address = address.Street_Number_and_Name + ", " + address.City + ", " + _context.USStates.FirstOrDefault(s => s.Id == address.USStateId).Name + ", " + address.Zip_Code;
            }
            Pickup pickup = new Pickup()
            {
                Customer_Id = _context.Customers.FirstOrDefault(c => c.IdentityUser_Id == this.User.FindFirstValue(ClaimTypes.NameIdentifier)).Id,
                Days = days,
                Addresses = addresses
            };
            return View(pickup);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePickup(Pickup pickup)
        {
            try
            {
                _context.Pickups.Add(pickup);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(pickup);
            }
        }
        public ActionResult RequestOneTimeExtraPickup(int pickupId)
        {
            Pickup pickup = _context.Pickups.FirstOrDefault(p => p.Id == pickupId);
            return View(pickup);
        }

        // GET: Customers/Edit/5
        public ActionResult EditUserInformation(int id)
        {
            return View();
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserInformation(int id, IFormCollection collection)
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

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customers/Delete/5
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