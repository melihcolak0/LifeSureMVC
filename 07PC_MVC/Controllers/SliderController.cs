using _07PC_MVC.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _07PC_MVC.Controllers
{
    public class SliderController : Controller
    {
        private readonly Entities _context;

        public SliderController()
        {
            _context = new Entities();
        }

        public ActionResult Index()
        {
            var values = _context.Sliders.ToList();
            return View(values);
        }

        public ActionResult DeleteSlider(int id)
        {
            var slider = _context.Sliders.FirstOrDefault(x => x.SliderId == id);
            _context.Sliders.Remove(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateSlider()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSlider(Sliders slider)
        {
            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSlider(int id)
        {
            var slider = _context.Sliders.FirstOrDefault(x => x.SliderId == id);
            return View(slider);
        }

        [HttpPost]
        public ActionResult UpdateSlider(Sliders slider)
        {
            var value = _context.Sliders.FirstOrDefault(x => x.SliderId == slider.SliderId);

            value.Title = slider.Title;
            value.SubTitle = slider.SubTitle;
            value.Description = slider.Description;
            value.SliderImageUrl = slider.SliderImageUrl;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}