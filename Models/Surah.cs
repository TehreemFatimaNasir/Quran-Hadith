namespace WebApplication5.Models
{
    public class QuranResponse
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public List<Surah> Data { get; set; }
    }

    public class Surah
    {
        public int Number { get; set; }
        public string Name { get; set; }

        public string EnglishName { get; set; }
        public string EnglishNameTranslation { get; set; } 
        public int NumberOfAyahs { get; set; }
        public string RevelationType { get; set; }
    }

    public class SurahDetailsResponse
    {
        public SurahDetails Data { get; set; }
    }

    public class SurahDetails
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public string EnglishNameTranslation { get; set; }

        public string RevelationType { get; set; }
        public List<Ayah> Ayahs { get; set; }
    }

    public class Ayah
    {
        public int Number { get; set; }
        public string Text { get; set; }
        public string Audio { get; set; }
        public string Translation { get; set; } 
    }

    public class EditionResponse
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public List<Edition> Data { get; set; }
    }

    public class Edition
    {
        public string Identifier { get; set; }
        public string Language { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public string Format { get; set; }
        public string Type { get; set; }
    }
    public class LanguageResponse
    {
        public List<string> Data { get; set; }
    }
}
