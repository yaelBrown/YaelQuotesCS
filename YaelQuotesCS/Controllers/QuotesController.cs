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
        private Random rnd = new Random();
        public string Get()
        {
            try
            {
                string json = ""; 
                
                // using (StreamReader r = new StreamReader(System.Web.Hosting.HostingEnvironment.MapPath("~/Content/JSON/quotes.json")))
                using (StreamReader r = new StreamReader(System.Web.Hosting.HostingEnvironment.MapPath("~/quotes.json")))
                {
                    json = r.ReadToEnd();
                }

                QuotesModel quotes = JsonConvert.DeserializeObject<QuotesModel>(json);

                int idx = rnd.Next(quotes.q.Count);

                return quotes.q[idx];
            }
            catch (Exception ex) 
            {
                var exceptionInfo = new { Type = ex.GetType().Name, Message = ex.Message, Full = ex.ToString() };
                
                return exceptionInfo.ToString();
            }
        }
    }
}
