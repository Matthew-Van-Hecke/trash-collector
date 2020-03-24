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
                Address = _context.Addresses.FirstOrDefault(a => a.Customer.IdentityUser_Id == this.User.FindFirstValue(ClaimTypes.NameIdentifier)),
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
        //localhost/Customers/SelectAPickup
        public ActionResult SelectAPickup()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Customer customer = _context.Customers.FirstOrDefault(c => c.IdentityUser_Id == userId);
            customer.Pickups = _context.Pickups.Include(c => c.Address).Include(p => p.Day).Where(p => p.Address.Customer_Id == customer.Id).ToList();
            return View(customer);
        }
        public ActionResult RequestOneTimeExtraPickup(int pickupId)
        {
            Pickup pickup = _context.Pickups.First(p => p.Id == pickupId);
            return View(pickup);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RequestOneTimeExtraPickup(Pickup pickup)
        {
            try
            {
                _context.Pickups.Update(pickup);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(pickup.Id);
            }
        }
        public ActionResult RequestTemporarySuspension(int pickupId)
        {
            Pickup pickup = _context.Pickups.First(p => p.Id == pickupId);
            return View(pickup);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RequestTemporarySuspension(Pickup pickup)
        {
            try
            {
                _context.Pickups.Update(pickup);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(pickup.Id);
            }
        }
        public ActionResult ChangePickupDay(int pickupId)
        {
            Pickup pickup = _context.Pickups.First(p => p.Id == pickupId);
            pickup.Days = _context.Days.ToList();
            return View(pickup);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePickupDay(Pickup pickup)
        {
            try
            {
                _context.Pickups.Update(pickup);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(pickup.Id);
            }
        }

        public ActionResult DeletePickup(int pickupId)
        {
            Pickup pickup = _context.Pickups.Where(p => p.Id == pickupId).Include(p => p.Address.Customer).Include(p => p.Address).Include(p => p.Day).FirstOrDefault();
            return View(pickup);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePickup(Pickup pickup)
        {
            try
            {
                _context.Pickups.Remove(pickup);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(pickup.Id);
            }
        }

    }
}