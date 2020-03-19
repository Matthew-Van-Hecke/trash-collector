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
            return View();
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult CreateAddress()
        {
            List<USState> uSStates = _context.USStates.ToList();
            var currentUser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customerId = _context.Customers.FirstOrDefault(c => c.IdentityUser.Equals(currentUser)).Id;
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