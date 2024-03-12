using APISample.Models;
using APISample.ViewModels;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace APISample.Utilities
{
    public static class Utility
    {

        static HttpClient client = new HttpClient();

        
        public static List<Language> GetJsonLanguages(string jsonString)
        {
            List<Language> root = JsonConvert.DeserializeObject<List<Language>>(jsonString);
            return root;
        }

        public static User GetJsonUser(string jsonString)
        {
            User root = JsonConvert.DeserializeObject<User>(jsonString);
            return root;
        }
    }
}
