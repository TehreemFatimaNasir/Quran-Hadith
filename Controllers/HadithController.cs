using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HadithController : Controller
    {
        private readonly HadithService _hadithService;

        public HadithController(HadithService hadithService)
        {
            _hadithService = hadithService;
        }

        public async Task<IActionResult> Index()
        {
            var Hadiths = await _hadithService.GetAllHadithsAsync();
            return View(Hadiths);
        }
        public async Task<IActionResult> Books()
        {
            var books = await _hadithService.GetAllBooksAsync();
            return View(books);
        }


        public async Task<IActionResult> Chapters(string bookSlug)
        {
            var result = await _hadithService.GetChaptersAsync(bookSlug);

            if (result != null)
            {
                return View(result); 
            }

            return View(new List<Chapter>());
        }

        [HttpGet("HadithDetails/{chapterId}")]
        public async Task<IActionResult> HadithDetails(int chapterId)

        {
            var url = $"https://hadithapi.com/api/hadiths/{chapterId}?apiKey=$2y$10$0KsokUuNkmO6xXsXLWCjue6JEVE6olfFFO3wosGGeRUlNBOPsfW";

            var jsonData = await _hadithService.GetAsync(url);

            if (!string.IsNullOrEmpty(jsonData))
            {
                var result = JsonSerializer.Deserialize<Hadith>(jsonData,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return View(result);
            }

            return View(new Hadith());
        }

    }
}
