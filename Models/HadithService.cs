using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using WebApplication5.Models;

namespace WebApplication5.Models
{
    public class HadithService
    {
        private readonly HttpClient _httpClient;

        public HadithService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Hadith>> GetAllHadithsAsync()
        {
            var response = await _httpClient.GetAsync("https://hadithapi.com/api/hadiths/?apiKey=$2y$10$0KsokUuNkmO6xXsXLWCjue6JEVE6olfFFO3wosGGeRUlNBOPsfW");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                Console.WriteLine("API Response: " + jsonData); 

                var result = JsonSerializer.Deserialize<HadithApiResponse>(jsonData,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return result?.Hadiths?.Data ?? new List<Hadith>();
            }

            Console.WriteLine("API call failed!");
            return new List<Hadith>();
        }
        public async Task<List<HadithBook>> GetAllBooksAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://hadithapi.com/api/books?apiKey=$2y$10$0KsokUuNkmO6xXsXLWCjue6JEVE6olfFFO3wosGGeRUlNBOPsfW");

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"API Request Failed: {response.StatusCode}");
                    return new List<HadithBook>();
                }

                var jsonData = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(jsonData))
                {
                    Console.WriteLine("API response is empty.");
                    return new List<HadithBook>();
                }

                Console.WriteLine("API Response: " + jsonData); 

            
                var result = JsonSerializer.Deserialize<HadithBooksResponse>(
                    jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (result == null)
                {
                    Console.WriteLine("Deserialization failed: result is null.");
                    return new List<HadithBook>();
                }

                if (result.Data == null || result.Data.Count == 0)
                {
                    Console.WriteLine("No Hadith books found in the response.");
                    return new List<HadithBook>();
                }

                return result.Data;
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"JSON Deserialization Error: {jsonEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
            }

            return new List<HadithBook>();
        }



        public async Task<List<Chapter>> GetChaptersAsync(string bookSlug)
        {
            var response = await _httpClient.GetAsync($"https://hadithapi.com/api/{bookSlug}/chapters?apiKey=$2y$10$0KsokUuNkmO6xXsXLWCjue6JEVE6olfFFO3wosGGeRUlNBOPsfW");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonData); 

                var result = JsonSerializer.Deserialize<HadithChaptersResponse>(jsonData,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return result?.Data ?? new List<Chapter>(); 
            }

            return new List<Chapter>(); 
        }
        public async Task<string> GetAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null;
        }
        public async Task<Hadith> GetHadithByIdAsync(int hadithId)
        {
            var response = await _httpClient.GetAsync($"https://hadithapi.com/api/hadiths/{hadithId}?apiKey=$2y$10$0KsokUuNkmO6xXsXLWCjue6JEVE6olfFFO3wosGGeRUlNBOPsfW");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Hadith>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return null;
        }


    }
}

