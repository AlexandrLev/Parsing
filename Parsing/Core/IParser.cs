using AngleSharp.Html.Dom;
using Parsing.Core;
using System.Collections.Generic;

namespace Parser.Core
{
    // Интерфейс для парсеров
    interface IParser 
    {
        List<ParseNews> Parse(IHtmlDocument document, int NewsTag);
    }
}
