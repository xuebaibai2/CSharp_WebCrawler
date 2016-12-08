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
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            HtmlModel html = new HtmlModel();
            return View(html);
        }

        [HttpPost]
        public ActionResult Index(HtmlModel html)
        {
            //html.Keyword = "thankq";
            //html.url = "https://www.google.com.au/search";

            WebClient wc = new WebClient();
            NameValueCollection nameValue = new NameValueCollection();
            nameValue.Add("q", html.Keyword);
            wc.QueryString.Add(nameValue);
            html.Result = wc.DownloadString(html.url);

            List<string> resultList = new List<string>();
            string regex = @"<a\s.*?>.*?</a>";
            //string regex = @"(<a\s+\w>)(\w*\W*\s*\S*\d*\D*)(</a>)";
            //string regex = @"<a\s+(?:[^>]*?\s+)?href=""([^ ""]*)";

            Regex reg = new Regex(regex, RegexOptions.IgnoreCase);

            Match match = reg.Match(html.Result);
            while (match.Success)
            {
                html.ResultList.Add(match.ToString());
                match = match.NextMatch();
            }

            return View("Result",html);
        }

        public ActionResult Result(HtmlModel html)
        {
            List<string> resultList = new List<string>();
            //string regex = @"(<a\s+\w>)(\w*\W*\s*\S*\d*\D*)(</a>)";
            string regex = @"<a\s+(?:[^>]*?\s+)?href=""([^ ""]*)";

            Regex reg = new Regex(regex, RegexOptions.IgnoreCase);

            Match match = reg.Match(html.Result);
            while (match.Success)
            {
                html.ResultList.Add(match.ToString());
                match = match.NextMatch();
            }
            
            return View(html);
        }
    }
}