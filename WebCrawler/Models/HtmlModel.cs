using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCrawler.Models
{
    public class HtmlModel
    {
        public HtmlModel()
        {
            this.ResultList = new List<string>();
        }
        public string Keyword { get; set; }
        public string url { get; set; }
        public string Result { get; set; }
        public string Filter { get; set; }
        public string Regex { get; set; }
        public List<string> ResultList { get; set; }
    }
}