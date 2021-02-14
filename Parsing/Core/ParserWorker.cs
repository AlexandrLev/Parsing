using AngleSharp.Html.Parser;
using Parsing.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core
{
    class ParserWorker
    {
        IParser parser;
        IParserSettings parserSettings;

        public HtmlLoader loader;

        public List<ParseNews> resultAll { get; set; }
        public IParser Parser
        {
            get
            {
                return parser;
            }
            set
            {
                parser = value;
            }
        }

        public IParserSettings Settings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }

        public ParserWorker(IParser parser)
        {
            this.parser = parser;
        }

        public ParserWorker(IParser parser, IParserSettings parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;
        }

        public void Start()
        {
            
        }

        

        public async void Worker(int NewsTag)
        {
            List<ParseNews> resultAl = null;
            for (int i = parserSettings.StartPoint; i <= parserSettings.EndPoint; i++)
            {
                var source = await loader.GetSourceByPageId(i);
                var domParser = new HtmlParser();
                var document = await domParser.ParseDocumentAsync(source);
                var res = parser.Parse(document, NewsTag);
                if (resultAl == null) { resultAl = res; } else {
                    for (int j = 0; j < res.Count; j++)
                    {
                        resultAl.Add(res[j]);
                    }
                 }
            }
            resultAll = resultAl;
        }


    }
}
