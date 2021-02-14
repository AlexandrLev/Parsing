using System;
using System.Collections.Generic;
using System.Linq;
using Parser.Core;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;
using Parsing.Core;

namespace Parser.Core.Habra
{
    class HabraParser : IParser
    {
        public List<ParseNews> Parse(IHtmlDocument document,int newsTag)
        {
            var list  = new List<ParseNews>();
            var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("post__title_link"));
            foreach (var item in items)
            {
                
                list.Add(new ParseNews { Title = item.TextContent , Url = item.GetAttribute("href"), NewsTag = newsTag });
            }

            return list;
        }
    }
}
