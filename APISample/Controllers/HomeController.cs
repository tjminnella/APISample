using APISample.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Web;
using APISample.ViewModels;
using System.Web;
using APISample.Utilities;
using System.Net.Http;
using Newtonsoft.Json;

namespace APISample.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepository _userRepository;

        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            //return _languageRepository.GetLanguage(1).Name;
            //return new ObjectResult(_languageRepository.GetAllLanguages());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HomeViewModel u)
        {
            User user = null;
            if (ModelState.IsValid)
            {
                user = _userRepository.GetUser(u.user.UserID.ToString(), u.user.UserPwd.ToString());
                if (user != null)
                {
                    HttpContext.Session.SetObjectAsJson("user", user);
                    return RedirectToAction("LanguageSearch");
                }
            }
            ViewBag.Message = "Failed to Login";
            return View("Index");
        }

        public ActionResult LanguageSearch()
        {
            var user = HttpContext.Session.GetObjectFromJson<User>("user");
            if(user == null)
            {
                ViewBag.Message = "You tried to go to the wrong page";
                return View("Index");
            }
            return View("LanguageSearch");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LanguageSearch(LanguageSearchViewModel l)
        {

            string apiUrl = "http://localhost:50656/Language/GetLanguagesByPurpose?purpose=" + l.purpose;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    List<Language> languages = JsonConvert.DeserializeObject<List<Language>>(data);
                    //var user = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    l.languages = languages;
                }
            }
            return View(l);
        }
    }
}
