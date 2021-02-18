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
    // класс парсера для ХабраХабр
    class HabraParser : IParser
    {
        private static Dictionary<int, string> months = new Dictionary<int, string>()
        {
            {1,"января" },
            {2,"февраля" },
            {3,"марта" },
            {4,"апреля" },
            {5,"мая" },
            {6,"июня" },
            {7,"июля" },
            {8,"августа" },
            {9,"сентября" },
            {10,"октября" },
            {11,"ноября" },
            {12,"декабря" }
        };
        //парсер, который возвращает список новостей с тегом из полученного документа
        public List<ParseNews> Parse(IHtmlDocument document,int newsTag)
        {
            var list  = new List<ParseNews>();
            //var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("post__title_link"));
            var items = document.QuerySelectorAll("li").Where(item => item.ClassName != null && item.ClassName.Contains("content-list__item_post") 
                && item.ClassName.Contains("content-list__item") && item.ClassName.Contains("shortcuts_item"));
            foreach (var item in items)
            {
                var a = item.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("post__title_link")).FirstOrDefault();
                var s = item.QuerySelectorAll("span").Where(item => item.ClassName != null && item.ClassName.Contains("post__time")).FirstOrDefault();
                var date = GetDate(s.TextContent);
                //list.Add(new ParseNews { Title = item.TextContent , Url = item.GetAttribute("href"), NewsTag = newsTag });

                list.Add(new ParseNews { Title = a.TextContent, Url = a.GetAttribute("href"), NewsTag = newsTag, Date = date });
                
            }
            return list;
        }
        //метод генерирует дату из строки
        private DateTime GetDate(string strDate)
        {
            DateTime date;
            string[] strDateParts = strDate.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (strDateParts[0] == "сегодня") { date = DateTime.Today; }
            else if (strDateParts[0] == "вчера") { date = DateTime.Today.AddDays(-1); }
            else
            {
                int m = months.Where(x => x.Value == strDateParts[1]).FirstOrDefault().Key;
                int y, d;
                if (IsDigitsOnly(strDateParts[2])) {  y = Convert.ToInt32(strDateParts[2]); } else {  y = DateTime.Today.Year; }
                if (IsDigitsOnly(strDateParts[0])) {  d = Convert.ToInt32(strDateParts[0]); } else {  d = DateTime.Today.Day; }
                //y = Convert.ToInt32(strDateParts[2]);
                //d = Convert.ToInt32(strDateParts[0]);
                if (y < 2000 || y > DateTime.Today.AddDays(1).Year) {return date = DateTime.Today; }
                if (m<=0 || m>12){ return date = DateTime.Today; }
                if (d<=0 || d>31){ return date = DateTime.Today; }

                date = new DateTime(y, m, d);
            }
            return date;
        }

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if ((c < '0' || c > '9'))
                    return false;
            }

            return true;
        }
    }
}
