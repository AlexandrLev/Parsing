using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core
{
    interface IParserSettings
    {
        string BaseUrl { get; set; }

        string PagePrefix { get; set; }

        string TagPrefix { get; set; }

        int StartPoint { get; set; }

        int EndPoint { get; set; }
    }
}
