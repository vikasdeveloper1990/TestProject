using Service.Integration.Models;
using System.Collections.Generic;

namespace Service.Integration.Services
{
    public interface IService
    {
        List<Customer> GetDeliveryDetails();
        List<Customer> AddDeliveryDetails(Customer customer);
        List<Customer> DeleteDeliveryDetails(Customer customer);
        List<Customer> UpdateDeliveryDetails(Customer customer);
    }
}
