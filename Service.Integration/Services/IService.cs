using Service.Integration.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Integration.Services
{
    public interface IService
    {
        Task<List<Customer>> GetDeliveryDetails();
        Task<List<Customer>> AddDeliveryDetails(Customer customer);
        Task<List<Customer>> DeleteDeliveryDetails(Customer customer);
        Task<List<Customer>> UpdateDeliveryDetails(Customer customer);
    }
}
