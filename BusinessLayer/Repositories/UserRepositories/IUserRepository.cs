using BusinessLayer.Responses.UserResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories.UserRepositories
{
    public interface IUserRepository
    {
        Task<List<GetUserResponse>> GetUsers();
        
    }
}
