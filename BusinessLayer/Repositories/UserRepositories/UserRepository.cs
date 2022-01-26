using BusinessLayer.Responses.UserResponse;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }



        public async Task<List<GetUserResponse>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            List<GetUserResponse> response = new List<GetUserResponse>();

            foreach (var user in users)
            {
                response.Add(new GetUserResponse
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                });
            }
            return response;


        }

    }
}
