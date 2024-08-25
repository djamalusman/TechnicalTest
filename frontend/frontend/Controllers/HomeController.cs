using frontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Layout = "_LoginLayout";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Layout = "_LoginLayout";
                return View(model);
            }

            var client = _clientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7090/loginUser", content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var getdata = JsonConvert.DeserializeObject<ApiResponse>(result);

                if (getdata != null && getdata.status == "OK")
                {
                    // Simpan data ke sesi
                    HttpContext.Session.SetString("UserName", getdata.result.user_name);
                    HttpContext.Session.SetInt32("UserId", (int)getdata.result.user_id);

                    ViewBag.Layout = "_Layout";
                    return Redirect("~/Bpkb/Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, getdata?.message ?? "Invalid login attempt.");
                    ViewBag.Layout = "_LoginLayout";
                    return View(model);
                }
            }
            else
            {
                ViewBag.Layout = "_LoginLayout";
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("JWToken"); // Menghapus token dari session
            return RedirectToAction("Login");
        }

        public IActionResult Index()
        {
            ViewBag.Layout = "_Layout";
            return View();
        }

       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
