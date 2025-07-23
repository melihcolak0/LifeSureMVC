using _07PC_MVC.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _07PC_MVC.Controllers
{
    public class MemberController : Controller
    {
        private readonly Entities _context;

        public MemberController()
        {
            _context = new Entities();
        }

        public ActionResult Index()
        {
            var values = _context.Members.ToList();
            return View(values);
        }

        public ActionResult DeleteMember(int id)
        {
            var member = _context.Members.FirstOrDefault(x => x.MemberId == id);
            _context.Members.Remove(member);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateMember()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateMember(Members member)
        {
            _context.Members.Add(member);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateMember(int id)
        {
            var member = _context.Members.FirstOrDefault(x => x.MemberId == id);
            return View(member);
        }

        [HttpPost]
        public ActionResult UpdateMember(Members member)
        {
            var value = _context.Members.FirstOrDefault(x => x.MemberId == member.MemberId);

            value.NameSurname = member.NameSurname;
            value.Profession = member.Profession;
            value.TwitterUrl = member.TwitterUrl;
            value.LinkedinUrl = member.LinkedinUrl;
            value.ImageUrl = member.ImageUrl;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}