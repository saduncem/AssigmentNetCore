using Newtonsoft.Json;
using ObiletAssingment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using ObiletAssingment.Services.Contract;
using ObiletAssingment.Models.RequestModel;
using ObiletAssingment.Extensions;

namespace ObiletAssingment.Service
{
    public class ObiletServices : IObiletServices
    {
        private readonly ISesionService _sesionService;
        public ClientServices _clientServices { get; }
        public HttpClient Client { get; }

        public SessionResponseModel session { get; set; }
        public ObiletServices(ISesionService sesionService, ClientServices clientServices)
        {
            _sesionService = sesionService;
            _clientServices = clientServices;
           
            Client = _clientServices.GetClient();
        }

      
        public async Task<IndexViewModel> Getbuslocations(DateTime date)
        {
            session =  _sesionService.GetOrCreate();
            Client.DefaultRequestHeaders.Accept.Clear();
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/location/getbuslocations");
            var sessionPostData = new BuslocationsRequestModel();
            sessionPostData.device_session = new BuslocationsRequestModel.DeviceSession() {device_id = session.Data.DeviceId, session_id = session.Data.SessionId };

            sessionPostData.date = date.ObiletDateFormat();
            sessionPostData.language = "tr-TR";
            var payload = JsonConvert.SerializeObject(sessionPostData);

            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

            request.Content = content;
            var response = await Client.SendAsync(request);
            var resultContent = await response.Content.ReadAsStringAsync();
            IndexViewModel indexViewModel = new IndexViewModel();

            BuslocationsResponseModel buslocation = JsonConvert.DeserializeObject<BuslocationsResponseModel>(resultContent);
            indexViewModel.OutDestination = GetLocaitonOutDestination(buslocation);
            indexViewModel.InDestination = GetLocaitonInDestination(buslocation);
            return indexViewModel;

            
        }
        public async Task<JourneysResponseModel> Getbusjourneys(DateTime date ,DateTime departure_date, int destination_id, int origin_id)
        {
            session =  _sesionService.GetOrCreate();
            Client.DefaultRequestHeaders.Accept.Clear();
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/journey/getbusjourneys");

            var journeysRequestModel = new JourneysRequestModel();

            journeysRequestModel.device_session = new DeviceSession() {DeviceId = session.Data.DeviceId ,SessionId = session.Data.SessionId };
            journeysRequestModel.data = new Data() { departure_date = departure_date.ObiletDateFormat(), destination_id = destination_id ,origin_id = origin_id };
            journeysRequestModel.date = date.ObiletDateFormat();
            journeysRequestModel.language = "tr-TR";


            string body = JsonConvert.SerializeObject(journeysRequestModel);

            StringContent content = new StringContent(body);
            content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            try
            {
                var response = await Client.PostAsync("/api/journey/getbusjourneys", content).Result.Content.ReadAsStringAsync();
                JourneysResponseModel obje = JsonConvert.DeserializeObject<JourneysResponseModel>(response);

                return obje;
            }
            catch (Exception ex)
            {
                var hata = ex.ToString();
                return null;
            }


        }
        private IEnumerable<SelectListItem> GetLocaitonOutDestination(BuslocationsResponseModel data)
        {

            if (data.Data != null)
            {
                return data.Data.Select(s => new SelectListItem() { Text = s.Name, Value = s.Id.ToString(), Selected = s.Name.Contains("Avrupa") }).ToList();
            }
            else
            {
                return null;
            }

        }

        private IEnumerable<SelectListItem> GetLocaitonInDestination(BuslocationsResponseModel data)
        {

            if (data.Data != null)
            {

                return data.Data.Select(s => new SelectListItem() { Text = s.Name, Value = s.Id.ToString(), Selected = s.Name.Equals("Ankara") }).ToList();
            }
            else
            {
                return null;
            }

        }

    }

 
}
