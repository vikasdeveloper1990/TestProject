using System.Collections.Generic;

namespace Service.Integration.Models
{
    public class CustomerCollection
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();

        public string ErrorMessage { get; set; }
    }
}
