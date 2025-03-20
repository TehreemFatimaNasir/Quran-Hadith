using System.Text.Json.Serialization;

namespace WebApplication5.Models
{
    public class AyahResponse
    {
        [JsonPropertyName("data")]
        public List<Ayah> Ayahs { get; set; }
    }
}
