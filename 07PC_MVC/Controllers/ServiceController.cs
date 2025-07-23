using _07PC_MVC.Models.DataModels;
using _07PC_MVC.Models.ViewModels;
using Antlr.Runtime.Misc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace _07PC_MVC.Controllers
{
    public class ServiceController : Controller
    {
        private readonly Entities _context;

        public ServiceController()
        {
            _context = new Entities();
        }

        public ActionResult Index()
        {
            var values = _context.Services.ToList();
            return View(values);
        }

        public ActionResult DeleteService(int id)
        {
            var service = _context.Services.FirstOrDefault(x => x.ServiceId == id);
            _context.Services.Remove(service);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }       

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var service = _context.Services.FirstOrDefault(x => x.ServiceId == id);
            return View(service);
        }

        [HttpPost]
        public ActionResult UpdateService(Services service)
        {
            var value = _context.Services.FirstOrDefault(x => x.ServiceId == service.ServiceId);

            value.Title = service.Title;
            value.Description = service.Description;
            value.Icon = service.Icon;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }      

        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateService(ServiceViewModel model, string action)
        {
            if (action == "generate")
            {
                string prompt = $"{model.Title}";
                string fileName = "AIImage_" + Guid.NewGuid().ToString() + ".png";
                string folderPath = Server.MapPath("~/Content/ServiceImagesWithAI/");
                string savePath = Path.Combine(folderPath, fileName);

                try
                {
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", "my_hugging_face_api_key");

                        var requestBody = new { inputs = prompt };
                        var content = new StringContent(
                            Newtonsoft.Json.JsonConvert.SerializeObject(requestBody),
                            Encoding.UTF8,
                            "application/json"
                        );

                        var response = await client.PostAsync("https://api-inference.huggingface.co/models/black-forest-labs/FLUX.1-dev", content);

                        if (!response.IsSuccessStatusCode)
                        {
                            ViewBag.ApiError = $"API Hatası: {response.StatusCode}<br/>Mesaj: {await response.Content.ReadAsStringAsync()}";
                            return View(model);
                        }

                        var imageBytes = await response.Content.ReadAsByteArrayAsync();

                        if (imageBytes == null || imageBytes.Length == 0)
                        {
                            ViewBag.ApiError = "Resim verisi boş döndü.";
                            return View(model);
                        }

                        if (!Directory.Exists(folderPath))
                            Directory.CreateDirectory(folderPath);

                        System.IO.File.WriteAllBytes(savePath, imageBytes);

                        string relativePath = "/Content/ServiceImagesWithAI/" + fileName;
                        model.ImageUrl = relativePath;
                        ModelState.Remove(nameof(model.ImageUrl)); // <-- Bu satır önemli
                        ViewBag.SuccessMessage = "Görsel başarıyla oluşturuldu.";
                        return View(model);
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ApiError = "Bir hata oluştu: " + ex.Message;
                    return View(model);
                }
            }
            else if (action == "save")
            {
                if (ModelState.IsValid)
                {
                    var service = new Services()
                    {
                        Title = model.Title,
                        Description = model.Description,
                        ImageUrl = model.ImageUrl,
                        Icon = model.Icon
                    };

                    _context.Services.Add(service);
                    _context.SaveChanges();

                    TempData["SuccessMessage"] = "Hizmet başarıyla eklendi.";
                    return RedirectToAction("Index");
                }

                return View(model);
            }

            return View(model);
        }
    }
}