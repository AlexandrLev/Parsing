using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core
{
    // Интерфейс для настроек парсера
    interface IParserSettings
    {
        // основная часть адреса
        string BaseUrl { get; set; }

        // часть адреса с обозначением номера страницы
        string PagePrefix { get; set; }

        // часть адреса, в которой определяется тематика запроса
        string TagPrefix { get; set; }

        //номер начальной страницы
        int StartPoint { get; set; }

        //номер конечной страницы
        int EndPoint { get; set; }
    }
}
