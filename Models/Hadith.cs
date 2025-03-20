using System.Text.Json.Serialization;

namespace WebApplication5.Models
{
    public class HadithApiResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public HadithData Hadiths { get; set; }
    }

    public class HadithData
    {
        public int CurrentPage { get; set; }
        public List<Hadith> Data { get; set; }
    }

    public class Hadith
    {
        public int Id { get; set; }
        public string HadithNumber { get; set; }
        public string EnglishNarrator { get; set; }
        public string HadithEnglish { get; set; }
        public string HadithUrdu { get; set; }
        public string HadithArabic { get; set; }
        public string HeadingEnglish { get; set; }
        public string HeadingArabic { get; set; }
        public Book Book { get; set; }
        public Chapter Chapter { get; set; }
    }

    public class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string WriterName { get; set; }
        public string BookSlug { get; set; }
    }

    public class Chapter
    {
        public int Id { get; set; }
        public string ChapterNumber { get; set; }
        public string ChapterEnglish { get; set; }
        public string ChapterArabic { get; set; }
        public string BookSlug { get; set; }
    }

    public class HadithBook
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string WriterName { get; set; }
        public string BookSlug { get; set; }
        public string Volume { get; set; }
        public string Status { get; set; }
    }

    // ✅ Response model for fetching all Hadith books
    public class HadithBooksResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }

        [JsonPropertyName("books")] // ✅ Match API key name
        public List<HadithBook> Data { get; set; }
    }

    // ✅ Response model for fetching all Hadith chapters
    public class HadithChaptersResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }

        [JsonPropertyName("chapters")] // ✅ Match API key name
        public List<Chapter> Data { get; set; }
    }
}
