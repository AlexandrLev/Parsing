using System;
using System.Collections.Generic;
using System.Text;

namespace Parsing.Core
{
    //Класс новостей, в который парсятся новости
    class ParseNews
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public int NewsTag { get; set; }
        public DateTime Date { get; set; }

    }
}
