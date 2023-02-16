using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;
using YaelQuotesCS.Models;
using Microsoft.AspNetCore.Http.Internal;
using System.Security.Cryptography.X509Certificates;

namespace YaelQuotesCS.Controllers
{
    [Produces("application/json")]
    public class QuotesController : ApiController
    {
        public string Get()
        {
            StreamReader r = new StreamReader(HttpContext.Current.Server.MapPath("/Content/JSON/quotes.json"));
            string json = r.ReadToEnd();

            Console.WriteLine(json);
            QuotesModel quotes = JsonConvert.DeserializeObject<QuotesModel>(json);

            Random rnd = new Random();
            int idx = rnd.Next(quotes.q.Count);

            return quotes.q[idx];
        }
    }
}
