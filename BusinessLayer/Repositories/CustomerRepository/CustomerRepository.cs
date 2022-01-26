using BusinessLayer.Requests.CustomerRequest;
using BusinessLayer.Responses.CustomerResponse;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories.CustomerRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<List<GetCustomersResponse>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();

            List<GetCustomersResponse> response = new List<GetCustomersResponse>();

            foreach( var customer in customers)
            {
                response.Add(new GetCustomersResponse
                {
                    Id = customer.Id,
                    Code = customer.Code,
                    Name = customer.Name
                });
            }

            return response;

            
        }

        public async Task <GetCustomerByIdResponse> GetCustomerById(int id)
        {
            try
            {
                var customer = await _context.Customers.Where(c => c.Id == id).SingleOrDefaultAsync();

                GetCustomerByIdResponse response = new GetCustomerByIdResponse()
                {
                    Id = customer.Id,
                    Name = customer.Name
                };
                return response;
            } catch (Exception)
            {
                return null;
            }
        }

        public async Task <PostCustomerResponse> PostCustomer(PostCustomerRequest postCustomerRequest)
        {
            var customerMap = new Customer()
            {
                Name = postCustomerRequest.Name
            };
            await _context.Customers.AddAsync(customerMap);

            try
            {
                await _context.SaveChangesAsync();
                PostCustomerResponse response = new PostCustomerResponse()
                {
                    Id = customerMap.Id,
                    Name = customerMap.Name
                };
                return response;
            } catch (Exception)
            {
                return null;
            }
        }
    }
}
