using System.Text.Json.Serialization;

namespace WebApplication5.Models
{
    public class HadithApiResponse
    {
        [JsonPropertyName("hadiths")]
        public HadithData Hadiths { get; set; }
    }

    public class HadithData
    {
        [JsonPropertyName("data")]
        public List<Hadith> Data { get; set; }
    }
    public class Hadith
    {
        public string HadithNumber { get; set; }
        public string EnglishNarrator { get; set; }
        public string HadithEnglish { get; set; }
        public string HadithUrdu { get; set; }
        public string HadithArabic { get; set; }
        public string HeadingEnglish { get; set; }

        public Book Book { get; set; }
        public Chapter Chapter { get; set; }
    }

    public class HadithBooksResponse
    {
        [JsonPropertyName("books")]
        public List<Book> Books { get; set; }
    }

    public class HadithBooksData
    {
        public List<Book> Books { get; set; }
    }

    public class Book
    {
        public string BookName { get; set; }
        public string WriterName { get; set; }
        public string BookSlug { get; set; }
    }

    public class HadithChaptersResponse
    {
        [JsonPropertyName("chapters")]
        public List<Chapter> Chapters { get; set; }
    }

    public class Chapter
    {
        [JsonPropertyName("chapter_id")]
        public int ChapterId { get; set; }

        [JsonPropertyName("chapter_number")]
        public string ChapterNumber { get; set; }

        [JsonPropertyName("chapter_english")]
        public string ChapterEnglish { get; set; }

        [JsonPropertyName("chapter_arabic")]
        public string ChapterArabic { get; set; }

        [JsonPropertyName("book_slug")]
        public string BookSlug { get; set; }
    }
}