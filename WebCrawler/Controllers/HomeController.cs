using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebCrawler.Models;

namespace WebCrawler.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            HtmlModel html = new HtmlModel();
            html.url = "https://www.google.com.au/search";
            return View(html);
        }

        [HttpPost]
        public ActionResult Index(HtmlModel html)
        {
            WebClient wc = new WebClient();
            NameValueCollection nameValue = new NameValueCollection();
            //nameValue.Add("wd", html.Keyword);
            nameValue.Add("q", html.Keyword);
            wc.QueryString.Add(nameValue);
            html.Result = wc.DownloadString(html.url);

            List<string> resultList = new List<string>();
            string regex = @"(<a\s.*?>)(.*?)(<\/a>)";
            string hrefRegex = @"href=""([^ ""]*)""";
            Regex reg = new Regex(regex, RegexOptions.IgnoreCase);

            Match match = reg.Match(html.Result);

            KeyValue keyValue = new KeyValue();
            while (match.Success)
            {
                Regex hrefReg = new Regex(hrefRegex, RegexOptions.IgnoreCase);
                keyValue.Key = match.Groups[2].Value;
                keyValue.Value = hrefReg.Match(match.Groups[1].Value).Groups[1].Value;
                if (keyValue.Value[0] == '/')
                {
                    keyValue.Value = "https://www.google.com.au" + keyValue.Value;
                }
                html.ValuePair.Add(keyValue);
                match = match.NextMatch();
            }

            return View("Result", html);
        }

        [HttpGet]
        public ActionResult Result(HtmlModel html)
        {
            return View(html);
        }
    }
}