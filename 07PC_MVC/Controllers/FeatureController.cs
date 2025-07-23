using _07PC_MVC.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _07PC_MVC.Controllers
{
    public class FeatureController : Controller
    {
        private readonly Entities _context;

        public FeatureController()
        {
            _context = new Entities();
        }

        public ActionResult Index()
        {
            var values = _context.Features.ToList();
            return View(values);
        }

        public ActionResult DeleteFeature(int id)
        {
            var feature = _context.Features.FirstOrDefault(x => x.FeatureId == id);
            _context.Features.Remove(feature);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateFeature(Features feature)
        {
            _context.Features.Add(feature);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateFeature(int id) 
        {
            var feature = _context.Features.FirstOrDefault(x => x.FeatureId == id);
            return View(feature);
        }

        [HttpPost]
        public ActionResult UpdateFeature(Features feature)
        {
            var value = _context.Features.FirstOrDefault(x => x.FeatureId == feature.FeatureId);

            value.Title = feature.Title;
            value.Description = feature.Description;    
            value.IconUrl = feature.IconUrl;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}