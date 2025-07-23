using _07PC_MVC.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _07PC_MVC.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly Entities _context;

        public TestimonialController()
        {
            _context = new Entities();
        }

        public ActionResult Index()
        {
            var values = _context.Testimonials.ToList();
            return View(values);
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var testimonial = _context.Testimonials.FirstOrDefault(x => x.TestimonialId == id);
            _context.Testimonials.Remove(testimonial);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTestimonial(Testimonials testimonial)
        {
            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var testimonial = _context.Testimonials.FirstOrDefault(x => x.TestimonialId == id);
            return View(testimonial);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonials testimonial)
        {
            var value = _context.Testimonials.FirstOrDefault(x => x.TestimonialId == testimonial.TestimonialId);

            value.NameSurname = testimonial.NameSurname;
            value.Description = testimonial.Description;
            value.Profession = testimonial.Profession;
            value.ImageUrl = testimonial.ImageUrl;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}