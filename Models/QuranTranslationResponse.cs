using System.Text.Json.Serialization;

namespace WebApplication5.Models
{
    public class QuranTranslationResponse
    {
        [JsonPropertyName("data")]
        public List<SurahDetails> Data { get; set; }
    }
}
