using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Integration.Models
{
    public class CustomerResults
    {
        public List<CustomerDto> Customers { get; set; } = new List<CustomerDto>();

        public string ErrorMessage { get; set; }
    }
}
