using ObiletAssingment.Models;
using System;
using System.Threading.Tasks;

namespace ObiletAssingment.Services.Contract
{
    public interface IObiletServices
    {
       
        Task<IndexViewModel> Getbuslocations(DateTime date);
        Task<JourneysResponseModel> Getbusjourneys(DateTime date, DateTime departure_date, int destination_id, int origin_id);
    }
}
