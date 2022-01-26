using BusinessLayer.Repositories.CustomerRepository;
using BusinessLayer.Requests.CustomerRequest;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController: ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        //Get api/<CustomerController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _customerRepository.GetCustomers();
            if(response == null)
            {
                return NotFound("Bulunamadı");
            }
            return Ok(response);
        }

        [HttpGet("/getById/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var response = await _customerRepository.GetCustomerById(id);
            if (response == null)
            {
                return NotFound("Bulunamadı");
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer(PostCustomerRequest postCustomerRequest)
        {
            var response = await _customerRepository.PostCustomer(postCustomerRequest);
            if (response == null)
            {
                return NotFound("Hata oluştu");
            }
            return Created(response.Name.ToString(), response);
        }
    }
}
