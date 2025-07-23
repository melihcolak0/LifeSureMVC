using _07PC_MVC.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _07PC_MVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly Entities _context;

        public ContactController()
        {
            _context = new Entities();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var value = _context.Contacts.FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public ActionResult Index(Contacts contact)
        {
            var value = _context.Contacts.FirstOrDefault();
            if (value != null)
            {
                value.Address = contact.Address;
                value.Email = contact.Email;
                value.Telephone = contact.Telephone;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}