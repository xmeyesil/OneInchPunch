using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Requests;
using BusinessLayer.Responses;
using DataLayer;
using DataLayer.Entities;
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


        public async Task<List<GetDeparmentResponse>> GetDeparment()
        {
            var deparments = await _context.Deparments.ToListAsync();

            List<GetDeparmentResponse> response = new List<GetDeparmentResponse>();

            foreach (var departmant in deparments)
            {
                response.Add(new GetDeparmentResponse
                {
                    Id = departmant.Id,
                    Name = departmant.Name
                });
            }

            return response;
        }

        public async Task<GetDeparmentByIdWithUserResponse> GetDeparmentByIdWithUser(int id)
        {
            try
            {
                var deparment = await _context.Deparments
                    .Include(d => d.Users)
                    .ThenInclude(u => u.Role)
                    .Where(d => d.Id == id).SingleOrDefaultAsync();

                GetDeparmentByIdWithUserResponse response = new GetDeparmentByIdWithUserResponse()
                {
                    Id = deparment.Id,
                    Name = deparment.Name,
                    Users = deparment.Users
                };
                return response;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<PostDeparmentResponse> PostDepartment(PostDeparmentRequest postDeparmentRequest)
        {


            Role role = new Role();
            role.Code = "asdas";
            role.Name = "12312";

            var deparmentMap = new Deparment()
            {
                Name = postDeparmentRequest.Name
            };
            await _context.Roles.AddAsync(role);
            //var addEntity = _context.Entry(deparmentMap);
            //addEntity.State = EntityState.Added;

            try
            {
                await _context.SaveChangesAsync();
                PostDeparmentResponse response = new PostDeparmentResponse()
                {
                    //Name = "123",
                    Id = 123,
                    Name = "123123"
                };
                return response;
            }
            catch (Exception e)
            {
                PostDeparmentResponse response = new PostDeparmentResponse()
                {
                    //Name = "123",
                    Id = 112,
                    Name = "asd"
                };

                return response;
            }

        }
    }
}