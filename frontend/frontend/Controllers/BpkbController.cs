using frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace frontend.Controllers
{
    public class BpkbController : Controller
    {
        private readonly ILogger<BpkbController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public BpkbController(ILogger<BpkbController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Username = HttpContext.Session.GetString("UserName");
            ViewBag.Layout = "_Layout";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7090/getdatalocation");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var locations = JsonConvert.DeserializeObject<ApiResponseModel<List<LocationModel>>>(result);

                // Periksa apakah `locations` dan `locations.result` bukan null
                if (locations != null && locations.result != null)
                {
                    return Json(locations.result); // Mengembalikan data dalam format JSON
                }
            }

            return BadRequest("Failed to load locations");
        }


        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7090/getdatabpkb");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                
                var deserializedData = JsonConvert.DeserializeObject<ApiResponseModel<List<Bpkbstore>>>(result);
                if (deserializedData != null && deserializedData.result != null)
                {
                    return Json(deserializedData.result); // Mengembalikan data dalam format JSON
                }
            }

            return StatusCode((int)response.StatusCode, "Error retrieving data from API");
        }

        [HttpGet]
        public async Task<IActionResult> GetById(string id)
        {
            byId getid = new byId();
            getid.id = id;
            var client = _clientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(getid), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7090/GetByIdbpkb", content);
            //var response = await client.GetAsync("https://localhost:7090/GetByIdbpkb",content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                var deserializedData = JsonConvert.DeserializeObject<ApiResponseModel<List<Bpkbstore>>>(result);
                if (deserializedData != null && deserializedData.result != null)
                {
                    return Json(deserializedData.result); // Mengembalikan data dalam format JSON
                }
            }

            return StatusCode((int)response.StatusCode, "Error retrieving data from API");
        }

        [HttpPost]
        public async Task<IActionResult> Store(Bpkbstore pr)
        {
            Bpkbstore bpkb = new Bpkbstore();
            var username = HttpContext.Session.GetString("UserName");
            bpkb.created_by = username;
            if (!ModelState.IsValid)
            {
                ViewBag.Layout = "_LoginLayout";
                return View(pr);
            }

           

            var client = _clientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(pr), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7090/StoreBpkb", content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var getdata = JsonConvert.DeserializeObject<ApiResponse>(result);

                if (getdata != null && getdata.status == "OK")
                {
                    // Simpan data ke sesi

                    ViewBag.Layout = "_Layout";
                    return Redirect("~/Bpkb/Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, getdata?.message ?? "Invalid login attempt.");
                    ViewBag.Layout = "_LoginLayout";
                    return View(pr);
                }
            }
            else
            {
                ViewBag.Layout = "_LoginLayout";
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(pr);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Update(Bpkbstore pr)
        {
            
            if (!ModelState.IsValid)
            {
                ViewBag.Layout = "_LoginLayout";
                return View(pr);
            }



            var client = _clientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(pr), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7090/Update", content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var getdata = JsonConvert.DeserializeObject<ApiResponse>(result);

                if (getdata != null && getdata.status == "OK")
                {
                    // Simpan data ke sesi

                    ViewBag.Layout = "_Layout";
                    return Redirect("~/Bpkb/Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, getdata?.message ?? "Invalid login attempt.");
                    ViewBag.Layout = "_LoginLayout";
                    return View(pr);
                }
            }
            else
            {
                ViewBag.Layout = "_LoginLayout";
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(pr);
            }
        }


    }
}
