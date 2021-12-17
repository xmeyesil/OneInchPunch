using System.Threading.Tasks;
using BusinessLayer.Responses;

namespace BusinessLayer.Repositories.DeparmentRepositories
{
    public interface IDeparmentRepository
    {
        Task<GetDeparmentResponse> GetDeparment();
    }
}