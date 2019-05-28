using Microsoft.AspNetCore.Http;
using ObiletAssingment.Models;
using System;
using System.Threading.Tasks;
using ObiletAssingment.Models.RequestModel;
using ObiletAssingment.Services.Contract;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using ObiletAssingment.UserAgentModel;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Text;

namespace ObiletAssingment.Service
{
    public class SesionService : ISesionService
    {
        private readonly HttpContext context;
        public ClientServices _clientServices { get; }
        private IMemoryCache _cache;
        private IHostingEnvironment env;
        SessionRequestModel requestModel;
        public HttpClient client { get; set; }

        public OBConfig _config { get; }
        public SesionService(OBConfig config,IHostingEnvironment _env, ClientServices clientServices, IMemoryCache memoryCache, IHttpContextAccessor httpContextAccessor)

        {
            env = _env;
            _config = config;
            context = httpContextAccessor.HttpContext;
            _cache = memoryCache;
            _clientServices = clientServices;

        }
        private IPAddress FindIpAddress()
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in hostEntry.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }


            return null;
        }


        public async Task<SessionResponseModel> CreateSesion()
        {
            client = _clientServices.GetClient();
            requestModel = new SessionRequestModel();

            string useragent = context.Request.Headers["User-Agent"];

            UserAgent ua = new UserAgent(useragent);

            requestModel.type = 1;
            requestModel.browser = new SessionRequestModel.Browser() { name = ua.Browser.Name, version = ua.Browser.Version };

            if (env.IsDevelopment())
            {
                requestModel.connection = new SessionRequestModel.Connection() { ip_address = "145.214.41.21", port = _config.Port };
            }
            else
            {
                requestModel.connection = new SessionRequestModel.Connection() { ip_address = FindIpAddress().ToString(), port = _config.Port };
            }

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/client/getsession");

            var payload = JsonConvert.SerializeObject(requestModel);

            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

            request.Content = content;

            var response = await client.SendAsync(request);

            var resultContent = await response.Content.ReadAsStringAsync();

            SessionResponseModel sessionResponseModel = JsonConvert.DeserializeObject<SessionResponseModel>(resultContent);

            return sessionResponseModel;

        }

        public SessionResponseModel GetOrCreate()
        {
            SessionResponseModel sesion = new SessionResponseModel();
            string SessionId = context.Session.GetString("SessionId");
            if (SessionId == null)
            {
                sesion = CreateSesion().Result;
                var item = _cache.GetOrCreate(sesion.Data.SessionId, cacheEntry =>
                {
                    cacheEntry.SlidingExpiration = TimeSpan.FromHours(1);
                    cacheEntry.Value = sesion;
                    return sesion;
                });
                context.Session.SetString("SessionId", sesion.Data.SessionId);
            }
            else
            {
                sesion = (SessionResponseModel)_cache.Get(SessionId);
                if (sesion == null)
                {
                    sesion = CreateSesion().Result;
                    var item = _cache.GetOrCreate(SessionId, cacheEntry =>
                    {
                        cacheEntry.SlidingExpiration = TimeSpan.FromHours(1);
                        cacheEntry.Value = sesion;
                        return sesion;
                    });
                    sesion = item;
                }
            }
            return sesion;
        }
    }
}
