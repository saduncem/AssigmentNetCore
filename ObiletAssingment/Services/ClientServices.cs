using ObiletAssingment.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ObiletAssingment.Service
{
    public class ClientServices 
    {
        
        public HttpClient Client { get; }
        public OBConfig  _config { get; }

        public ClientServices(HttpClient client, OBConfig config)
        {
          
            Client = client;
            _config = config;
        }

      
        public HttpClient GetClient()
        {
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.BaseAddress = new Uri(_config.apiURi);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Add("Authorization", _config.Authorization);
            return Client;
        }

    }

 
}
