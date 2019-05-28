using System.Threading.Tasks;
using ObiletAssingment.Models;

namespace ObiletAssingment.Services.Contract
{
    public interface ISesionService
    {

        Task<SessionResponseModel> CreateSesion();
        SessionResponseModel GetOrCreate();
    }
}
