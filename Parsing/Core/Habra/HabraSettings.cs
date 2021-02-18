
namespace Parser.Core.Habra
{
    // класс настроек для ХабраХабр
    class HabraSettings : IParserSettings
    {
        public HabraSettings(int start, int end, string TagPrefix)
        {
            StartPoint = start;
            EndPoint = end;
            this.TagPrefix = TagPrefix;
        }

        public string BaseUrl { get; set; } = "https://habr.com/ru/search";

        public string PagePrefix { get; set; } = "page{CurrentId}";

        public string TagPrefix { get; set; }

        public int StartPoint { get; set; }

        public int EndPoint { get; set; }
    }
}
