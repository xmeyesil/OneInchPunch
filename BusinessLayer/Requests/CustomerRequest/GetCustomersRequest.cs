using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Requests.CustomerRequest
{
    public class GetCustomersRequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
