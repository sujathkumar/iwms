using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IWMS.Solutions.Server.SuggestionServiceProvider.Models;
using SuggestionService = IWMS.Solutions.Server.SuggestionServiceProvider;

namespace ManagementService.Controllers
{
    public class SuggestionController : ApiController
    {
        public string GetSuggestion(string key)
        {
            var values = key.Split('|');

            if (values.Length > 0)
            {
                SuggestionService.Provider provider = new SuggestionService.Provider();

                string method = values[0].ToLower();
            }

            return "Error, Not Found!";
        }

        public string Post([FromBody]SuggestionPoint data)
        {
            SuggestionService.Provider provider = new SuggestionService.Provider();

            switch (data.SuggestionType)
            {
                case "0": return provider.InsertComplaint(data.Key, data.Subject, data.Description).ToString();
                case "1": return provider.InsertSuggestion(data.Key, data.Subject, data.Description).ToString();
            }

            return "success";
        }
    }
}
