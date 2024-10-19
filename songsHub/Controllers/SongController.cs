using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using songsHub.Models;
using System.Text;

namespace songsHub.Controllers
{
    public class SongController : Controller
    {
        // GET: SongController
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://localhost:7168/api/songs";

            List<Song> songs = new List<Song>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var result = await response.Content.ReadAsStringAsync();
                songs = JsonConvert.DeserializeObject<List<Song>>(result);
            }

            return View(songs);
        }

        // GET: SongController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SongController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SongController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Song song)
        {
            string apiUrl = "https://localhost:7168/api/songs";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(song), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(song);
        }

        // GET: SongController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SongController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SongController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SongController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
