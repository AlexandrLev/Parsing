using AngleSharp.Html.Dom;
using Parsing.Core;
using System.Collections.Generic;

namespace Parser.Core
{
    interface IParser 
    {
        List<ParseNews> Parse(IHtmlDocument document, int NewsTag);
    }
}
