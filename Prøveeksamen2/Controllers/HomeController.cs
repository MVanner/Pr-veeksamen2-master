    using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Entities;
using Entities.Data;
using Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Prøveeksamen2.Controllers
{
    [AutoValidateAntiforgeryToken] //prevents Cross site scripting
    public class HomeController : Controller
    {
        private readonly GiftDbContext _db;
        private readonly HttpClient _client;

        private Uri BaseEndPoint { get; set; }
        public HomeController(GiftDbContext db)
        {
            BaseEndPoint = new Uri("http://localhost:59330/api/Gift");
            _client = new HttpClient();
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync(BaseEndPoint, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return View(JsonConvert.DeserializeObject<List<Gift>>(data));
        }

        

        public async Task<IActionResult> Create(Gift gift1)
        {
            //gift.Title = "Banan";
            //gift.Description = "Gul";
            //gift.GirlGift = false;
            //gift.BoyGift = true;

            var response = await _client.PostAsJsonAsync(BaseEndPoint, gift1);

            //response.EnsureSuccessStatusCode();
            

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(gift1);
        }

        public async Task<IActionResult> GirlGifts()
        {
            var response = await _client.GetAsync(BaseEndPoint + "/false/true", HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return View(JsonConvert.DeserializeObject<List<Gift>>(data));
        }

        public async Task<IActionResult> Details(Guid Id)
        {
            var response = await _client.GetAsync(BaseEndPoint + "/" + Id.ToString(), HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return View(JsonConvert.DeserializeObject<Gift>(data));
        }

        //public async Task<IActionResult> Edit(Gift gift)
        //{
        //    //gift.Title = "Banan";
        //    //gift.Description = "Gul";
        //    //gift.GirlGift = false;
        //    //gift.BoyGift = true;
        //    Gift giftClone = new Gift();

        //    var response = await _client.PatchAsync(BaseEndPoint + "/" + gift.GiftNumber.ToString(), );

        //    //response.EnsureSuccessStatusCode();


        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    return View(giftClone);
        //}

        public async Task<IActionResult> Delete(Guid Id)
        {
            var response = await _client.DeleteAsync(BaseEndPoint + "/" + Id.ToString());
            //response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(JsonConvert.DeserializeObject<Gift>(data));
        }
    }
}