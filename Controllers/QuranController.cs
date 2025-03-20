using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication5.Controllers
{
    public class QuranController : Controller
    {
        private readonly QuranService _quranService;

        public QuranController(QuranService quranService)
        {
            _quranService = quranService;
        }

        // ✅ Fetch all Surahs
        public async Task<IActionResult> Index()
        {
            var surahs = await _quranService.GetAllSurahsAsync();
            var languages = await _quranService.GetAvailableLanguagesAsync(); 
            ViewBag.Languages = languages;
            return View(surahs);
        }

        public async Task<IActionResult> Read(int id, string language = "en.asad")
        {
            var surah = await _quranService.GetSurahTranslationAsync(id, language);
            var languages = await _quranService.GetAvailableLanguagesAsync();

            ViewBag.Languages = languages ?? new List<string> { "en.asad", "ur.junagarhi", "fr.hamidullah" };
            ViewBag.SelectedLanguage = language;

            return View(surah);
        }

       
        public async Task<IActionResult> SurahAudio(int id)
        {
            var surahAudio = await _quranService.GetSurahAudioAsync(id);
            if (surahAudio == null)
            {
                return NotFound();
            }
            return View(surahAudio);
        }
    }
}
