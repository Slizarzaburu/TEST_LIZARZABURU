using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace ApiKey
{
    public class Client
    {
        public HttpClient GetClient()
        {
            var apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri("https://localhost:44375/");
            //apiClient.BaseAddress = new Uri("http://apischooladl-001-site1.ftempurl.com/");
            return apiClient;
        }
    }   
}
