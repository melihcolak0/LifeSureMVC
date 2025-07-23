using _07PC_MVC.Models.DataModels;
using _07PC_MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace _07PC_MVC.Controllers
{
    public class FaqController : Controller
    {
        private readonly Entities _context;

        public FaqController()
        {
            _context = new Entities();
        }

        public ActionResult Index()
        {
            var values = _context.Faqs.ToList();
            return View(values);
        }

        public ActionResult DeleteFaq(int id)
        {
            var faq = _context.Faqs.FirstOrDefault(x => x.FaqId == id);
            _context.Faqs.Remove(faq);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }        

        [HttpGet]
        public ActionResult UpdateFaq(int id)
        {
            var faq = _context.Faqs.FirstOrDefault(x => x.FaqId == id);
            return View(faq);
        }

        [HttpPost]
        public ActionResult UpdateFaq(Faqs faq)
        {
            var value = _context.Faqs.FirstOrDefault(x => x.FaqId == faq.FaqId);

            value.QuestionPrompt = faq.QuestionPrompt;
            value.Question = faq.Question;
            value.Answer = faq.Answer;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateFaq()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateFaq(FaqViewModel model, string QuestionPrompt, string action)
        {
            if (action == "generateQuestion")
            {
                string prompt = string.IsNullOrEmpty(QuestionPrompt)
                    ? "Write a frequently asked question."
                    : QuestionPrompt;

                try
                {
                    var question = await CallChatGptApi(prompt + " Just question not answer with and in Turkish.");
                    if (!string.IsNullOrWhiteSpace(question))
                    {
                        model.Question = question;
                        ModelState.Remove(nameof(model.Question)); // <<< EKLE
                        ViewBag.ApiMessage = "Soru başarıyla oluşturuldu.";
                        ViewBag.IsError = false;
                    }
                    else
                    {
                        ViewBag.ApiMessage = "API'den geçerli bir soru alınamadı.";
                        ViewBag.IsError = true;
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ApiMessage = "Soru oluşturulurken hata oluştu: " + ex.Message;
                    ViewBag.IsError = true;
                }

                ViewBag.QuestionPrompt = QuestionPrompt;
                return View(model);
            }
            else if (action == "generateAnswer")
            {
                if (!string.IsNullOrEmpty(model.Question))
                {
                    try
                    {
                        var answer = await CallChatGptApi(model.Question + " Write a clear and helpful answer in Turkish.");
                        if (!string.IsNullOrWhiteSpace(answer))
                        {
                            model.Answer = answer;
                            ModelState.Remove(nameof(model.Answer));
                            ViewBag.ApiMessage = "Cevap başarıyla oluşturuldu.";
                            ViewBag.IsError = false;
                        }
                        else
                        {
                            ViewBag.ApiMessage = "API'den geçerli bir cevap alınamadı.";
                            ViewBag.IsError = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.ApiMessage = "Cevap oluşturulurken hata oluştu: " + ex.Message;
                        ViewBag.IsError = true;
                    }
                }
                else
                {
                    ViewBag.ApiMessage = "Cevap oluşturmak için önce bir soru girilmelidir.";
                    ViewBag.IsError = true;
                }

                return View(model);
            }
            else if (action == "save")
            {
                if (ModelState.IsValid)
                {
                    var entity = new Faqs
                    {
                        QuestionPrompt = model.QuestionPrompt,
                        Question = model.Question,
                        Answer = model.Answer
                    };

                    _context.Faqs.Add(entity);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }


        private async Task<string> CallChatGptApi(string prompt)
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://chatgpt-42.p.rapidapi.com/chatgpt"),
                    Headers =
            {
                { "x-rapidapi-key", "my_rapid_api_key" },
                { "x-rapidapi-host", "chatgpt-42.p.rapidapi.com" }
            },
                    Content = new StringContent($"{{\"messages\":[{{\"role\":\"user\",\"content\":\"{prompt}\"}}],\"web_access\":false}}", Encoding.UTF8, "application/json")
                };

                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = Newtonsoft.Json.Linq.JObject.Parse(json);
                    return result["result"]?.ToString();
                }
            }
            return null;
        }
    }
}