using AngleSharp;
using Parser.Core;
using Parser.Core.Habra;
using System;
using System.Linq;

using AngleSharp.Html.Dom;
using System.Collections.Generic;
using AngleSharp.Dom;
using Parsing.Core;

namespace Parsing
{
    class Program
    {
        static void Main(string[] args)
        {
            Ver2();
        }

        static  void Ver1()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var address = "https://habr.com/ru/search/?q=%5Bc%23%5D&target_type=posts";
            var document =  BrowsingContext.New(config).OpenAsync(address);
            var parsedHtml = document.Result; 

            // Находим блоки <div class="gitem">
            var grupAuto = parsedHtml.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("post__title_link"));

            Console.WriteLine("Выберите группу!");
            var i = 0;
            foreach (var q in grupAuto)
            {
                i++;
                Console.WriteLine(i + ": " + q.TextContent +" - "+ q.BaseUri);
            }

            Console.WriteLine("Готово!");
            Console.ReadLine();
        }

        static void Ver2()
        {
            string tagPrefix = "?q=[c%23]&target_type=posts";
            int newsTag = 1;

            var parser = new ParserWorker(
                    new HabraParser()
                );
            parser.Settings = new HabraSettings(1, 2, tagPrefix);
            parser.Worker(newsTag);
            
            
        }
    }
}
