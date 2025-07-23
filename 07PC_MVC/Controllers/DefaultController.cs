using _07PC_MVC.Models.DataModels;
using _07PC_MVC.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace _07PC_MVC.Controllers
{
    public class DefaultController : Controller
    {
        private readonly Entities _context;

        public DefaultController()
        {
            _context = new Entities();
        }

        public ActionResult Index()
        {

            return View();
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }

        public PartialViewResult SliderPartial()
        {
            var values = _context.Sliders.ToList();
            return PartialView(values);
        }

        public PartialViewResult FeaturePartial()
        {
            var values = _context.Features.ToList();
            return PartialView(values);
        }

        public PartialViewResult AboutPartial()
        {
            var value = _context.Abouts.FirstOrDefault();
            return PartialView(value);
        }

        public PartialViewResult ServicePartial()
        {
            var values = _context.Services.ToList();
            return PartialView(values);
        }

        public PartialViewResult FaqPartial()
        {
            var values = _context.Faqs.ToList();
            return PartialView(values);
        }

        public PartialViewResult MemberPartial()
        {
            var values = _context.Members.ToList();
            return PartialView(values);
        }

        public PartialViewResult TestimonialPartial()
        {
            var values = _context.Testimonials.ToList();
            return PartialView(values);
        }

        public PartialViewResult FooterPartial()
        {
            var value = _context.Contacts.FirstOrDefault();
            return PartialView(value);
        }               

        public PartialViewResult TopbarPartial()
        {
            var model = new LinkedinViewModel();

            var client = new HttpClient();

            //------------------ LinkedIn API ---------------------------------------------------------------------------------------------
            try
            {
                string companyUrl = "https://www.linkedin.com/company/lifesure-group-ltd/";
                string encodedUrl = Uri.EscapeDataString(companyUrl);

                var linkedinRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://linkedin-data-scraper-api1.p.rapidapi.com/companies/detail?identifier={encodedUrl}"),
                    Headers =
            {
                { "x-rapidapi-key", "my_rapid_api_key" },
                { "x-rapidapi-host", "linkedin-data-scraper-api1.p.rapidapi.com" },
            }
                };

                var linkedinResponse = client.SendAsync(linkedinRequest).GetAwaiter().GetResult();
                linkedinResponse.EnsureSuccessStatusCode();

                var linkedinJson = linkedinResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                var doc = JsonDocument.Parse(linkedinJson);
                var root = doc.RootElement;

                if (root.TryGetProperty("success", out var successProp) && successProp.GetBoolean())
                {
                    var data = root.GetProperty("data");
                    var basicInfo = data.GetProperty("basic_info");
                    var stats = data.GetProperty("stats");
                    var media = data.GetProperty("media");

                    model.Name = basicInfo.GetProperty("name").GetString();
                    var desc = basicInfo.GetProperty("description").GetString();
                    model.Description = !string.IsNullOrEmpty(desc) && desc.Length > 100 ? desc.Substring(0, 100) + "..." : desc;
                    model.Website = basicInfo.GetProperty("website").GetString();
                    model.Industries = basicInfo.GetProperty("industries").EnumerateArray().Select(x => x.GetString()).ToList();
                    model.FoundedYear = basicInfo.TryGetProperty("founded_info", out var foundedInfo) && foundedInfo.TryGetProperty("year", out var yearProp) ? (int?)yearProp.GetInt32() : null;
                    model.EmployeeCount = stats.GetProperty("employee_count").GetInt32();
                    model.FollowerCount = stats.GetProperty("follower_count").GetInt32();
                    model.LogoUrl = media.GetProperty("logo_url").GetString();
                }
            }
            catch
            {
                // Loglama yapabilirsin, boş geçiyoruz
            }

            //------------------ Twitter API ---------------------------------------------------------------------------------------------
            try
            {
                var twitterRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://twitter241.p.rapidapi.com/user?username=anadolu_sigorta"),
                    Headers =
            {
                { "x-rapidapi-key", "my_rapid_api_key" },
                { "x-rapidapi-host", "twitter241.p.rapidapi.com" },
            }
                };

                var twitterResponse = client.SendAsync(twitterRequest).GetAwaiter().GetResult();
                twitterResponse.EnsureSuccessStatusCode();

                var twitterJson = twitterResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                var twitterDoc = JsonDocument.Parse(twitterJson);
                var twitterRoot = twitterDoc.RootElement;

                if (twitterRoot.TryGetProperty("result", out var result) &&
                    result.TryGetProperty("data", out var data) &&
                    data.TryGetProperty("user", out var user) &&
                    user.TryGetProperty("result", out var userResult))
                {
                    var core = userResult.GetProperty("core");
                    var legacy = userResult.GetProperty("legacy");

                    model.TwitterName = core.GetProperty("name").GetString();

                    var twDesc = legacy.GetProperty("description").GetString();
                    model.TwitterDescription = !string.IsNullOrEmpty(twDesc) && twDesc.Length > 100 ? twDesc.Substring(0, 100) + "..." : twDesc;

                    model.TwitterFollowersCount = legacy.GetProperty("followers_count").GetInt32();
                    model.TwitterFriendsCount = legacy.GetProperty("friends_count").GetInt32();
                    model.TwitterMediaCount = legacy.GetProperty("media_count").GetInt32();

                    model.TwitterAvatarUrl = userResult.GetProperty("avatar").GetProperty("image_url").GetString();
                    model.TwitterScreenName = core.GetProperty("screen_name").GetString();
                }
            }
            catch
            {                
                // Loglama yapabilirsin, boş geçiyoruz
            }

            return PartialView(model);
        }
    }
}