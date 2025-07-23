using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace _07PC_MVC.Controllers
{
    public class LanguageController : Controller
    {
        public ActionResult ChangeLanguage(string lang, string returnUrl)
        {
            if (!string.IsNullOrWhiteSpace(lang))
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

                HttpCookie cookie = new HttpCookie("lang", lang)
                {
                    Expires = DateTime.Now.AddYears(1)
                };

                Response.Cookies.Add(cookie);
            }

            return Redirect(returnUrl);
        }
    }
}