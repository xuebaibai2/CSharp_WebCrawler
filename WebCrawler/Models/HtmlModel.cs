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
            this.First = new List<string>();
            this.Second = new List<string>();
            this.Third = new List<string>();
            this.HrefLink = new List<string>();
            this.ValuePair = new List<KeyValue>();
        }
        public string Keyword { get; set; }
        public string url { get; set; }
        public string Result { get; set; }
        public string Filter { get; set; }
        public string Regex { get; set; }

        public List<string> First { get; set; }
        public List<string> Second { get; set; }
        public List<string> Third{ get; set; }
        public List<string> HrefLink { get; set; }

        public List<KeyValue> ValuePair { get; set; }
        public List<string> ResultList { get; set; }
    }
}