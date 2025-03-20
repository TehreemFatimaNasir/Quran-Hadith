using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using WebApplication5.Models;

public class QuranService
{
    private readonly HttpClient _httpClient;

    public QuranService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Surah>> GetAllSurahsAsync()
    {
        var response = await _httpClient.GetAsync("https://api.alquran.cloud/v1/surah");
        if (!response.IsSuccessStatusCode) return new List<Surah>();

        var jsonData = await response.Content.ReadAsStringAsync();
        var result = System.Text.Json.JsonSerializer.Deserialize<QuranResponse>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return result?.Data ?? new List<Surah>();
    }

    // ✅ Fetch Surah with Translation
    public async Task<SurahDetails> GetSurahTranslationAsync(int id, string language = "en.asad")
    {
        string arabicUrl = $"https://api.alquran.cloud/v1/surah/{id}";
        string translationUrl = $"https://api.alquran.cloud/v1/surah/{id}/{language}";

        // Fetch Arabic Surah Details
        var responseArabic = await _httpClient.GetStringAsync(arabicUrl);
        var arabicData = JsonConvert.DeserializeObject<SurahDetailsResponse>(responseArabic);

        // Fetch Translation
        var responseTranslation = await _httpClient.GetStringAsync(translationUrl);
        var translationData = JsonConvert.DeserializeObject<SurahDetailsResponse>(responseTranslation);

        if (arabicData?.Data?.Ayahs != null && translationData?.Data?.Ayahs != null)
        {
            for (int i = 0; i < arabicData.Data.Ayahs.Count; i++)
            {
                arabicData.Data.Ayahs[i].Translation = translationData.Data.Ayahs[i].Text ?? "Translation not available";
            }
        }

        return arabicData?.Data;
    }

    // ✅ Fetch available translation languages
    public async Task<List<string>> GetAvailableLanguagesAsync()
    {
        string url = "https://api.alquran.cloud/v1/edition/type/translation";
        var response = await _httpClient.GetStringAsync(url);
        var editionResponse = JsonConvert.DeserializeObject<EditionResponse>(response);

        if (editionResponse?.Data != null)
        {
            return editionResponse.Data.Select(e => e.Identifier).ToList();
        }

        return new List<string> { "en.asad", "ur.junagarhi", "fr.hamidullah" };
    }


    public async Task<SurahDetails> GetSurahAudioAsync(int surahNumber)
    {
        var response = await _httpClient.GetAsync($"https://api.alquran.cloud/v1/surah/{surahNumber}/ar.alafasy");

        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var result = System.Text.Json.JsonSerializer.Deserialize<SurahDetailsResponse>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return result?.Data;
        }

        return null;
    }



}
