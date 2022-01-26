using BusinessLayer.Requests.CustomerRequest;
using BusinessLayer.Responses.CustomerResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories.CustomerRepository
{
    public interface ICustomerRepository
    {
        Task<List<GetCustomersResponse>> GetCustomers();
        Task<GetCustomerByIdResponse> GetCustomerById(int id);
        Task<PostCustomerResponse> PostCustomer(PostCustomerRequest postCustomerRequest);
        



    }
}
