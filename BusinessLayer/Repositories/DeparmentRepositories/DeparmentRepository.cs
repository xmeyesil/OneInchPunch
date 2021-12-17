using System.Threading.Tasks;
using BusinessLayer.Responses;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repositories.DeparmentRepositories
{
    public class DeparmentRepository : IDeparmentRepository
    {
        private readonly DataContext _context;

        public DeparmentRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<GetDeparmentResponse> GetDeparment()
        {
            var deparments = await _context.Deparments.Include(d => d.Users).ThenInclude(d => d.Role).FirstOrDefaultAsync();

            GetDeparmentResponse response = new GetDeparmentResponse()
            {
                Id = deparments.Id,
                Name = deparments.Name,
                User = deparments.Users,
            };
            
            return response;
        }
    }
}