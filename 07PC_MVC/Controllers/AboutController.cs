using _07PC_MVC.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _07PC_MVC.Controllers
{
    public class AboutController : Controller
    {
        private readonly Entities _context;

        public AboutController()
        {
            _context = new Entities();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var value = _context.Abouts.FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public ActionResult Index(Abouts about)
        {
            var value = _context.Abouts.FirstOrDefault();
            if (value != null)
            {
                value.Description = about.Description;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}