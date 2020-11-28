using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.Integration.DataServices;
using Service.Integration.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Integration.Services
{
    /// <summary>
    /// Service class basically performs all the operations that are asked for in the requirement.
    /// </summary>
    public class Service: IService
    {
        private readonly CustomerContext _context;
        private readonly ILogger _logger;

       /// <summary>
       /// This class performs all teh CRUD operations on delivery details.
       /// </summary>
       /// <param name="logger">Logging</param>
       /// <param name="context">Db Context</param>
        public Service(ILogger<Service> logger, CustomerContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Returns List of customers available in DB
        /// </summary>
        /// <returns>Returns List of customers</returns>
        public async Task<List<Customer>> GetDeliveryDetails()
        {
            _context.Database.EnsureCreated();
            _logger.LogInformation("Requested for customer details.");
            var results = _context.Customers.Include(x => x.Address).ToList();

            return await Task.FromResult(results).ConfigureAwait(false);
        }

        /// <summary>
        /// Adding New Customer.
        /// </summary>
        /// <param name="customer"> Customer object as input to Ef for insertion</param>
        /// <returns>Returns List of Updated customers</returns>
        public async Task<List<Customer>> AddDeliveryDetails(Customer customer)
        {
            _context.Attach(customer);
            _context.SaveChanges();

            _logger.LogInformation("Delivery details have been successfully Added.");
            return await Task.FromResult(_context.Customers.Include(x => x.Address).ToList()).ConfigureAwait(false);
            
        }

        /// <summary>
        /// Delete existing Customer.
        /// </summary>
        /// <param name="customer">Customer object</param>
        /// <returns>Returns List of Updated customers</returns>
        public async Task<List<Customer>> DeleteDeliveryDetails(Customer customer)
        {
            var customers = _context.Customers.Include(x => x.Address).ToList();
            var customerToDelete = customers.FirstOrDefault(x => (x.CustomerFirstName == customer.CustomerFirstName && x.CustomerLastName==customer.CustomerLastName &&
                                                                  (x.Address.Address1 == customer.Address.Address1 &&
                                                                   x.Address.City == customer.Address.City
                                                                   && x.Address.PostalCode ==
                                                                   customer.Address.PostalCode)));
            if (customerToDelete != null)
            {
                _context.Addresses.Remove(customerToDelete.Address);
                _context.Customers.Remove(customerToDelete);
                _context.SaveChanges();
                _logger.LogInformation("Delivery details have been successfully deleted.");
            }
            else
            {
                _logger.LogInformation("No data is available with information provided, so cant Delete data.");

                throw new Exception("No records to be Deleted with provided details.");
            }
            
            return await Task.FromResult(_context.Customers.Include(x => x.Address).ToList()).ConfigureAwait(false);
        }

        /// <summary>
        /// Update Existing Customer.
        /// </summary>
        /// <param name="customer">Customer object</param>
        /// <returns>Returns List of Updated customers</returns>
        public async Task<List<Customer>> UpdateDeliveryDetails(Customer customer)
        {
            var customers = _context.Customers.Include(x => x.Address).ToList();

            var identifiedCustomerWithName = customers.FirstOrDefault(x => (x.CustomerFirstName == customer.CustomerFirstName &&
                                                                            x.CustomerLastName == customer.CustomerLastName &&
                                                                            x.CustomerMailId == customer.CustomerMailId));

            var identifiedCustomerWithAddress = customers.FirstOrDefault(x =>
                (x.Address.Address1 == customer.Address.Address1 &&
                 x.Address.City == customer.Address.City
                 && x.Address.Country == customer.Address.Country
                 && x.Address.PostalCode == customer.Address.PostalCode));
            if (identifiedCustomerWithName != null)
            {
                var addressToBeModified = identifiedCustomerWithName.Address;

                addressToBeModified.Address1 = customer.Address.Address1;
                addressToBeModified.Address2 = customer.Address.Address2;
                addressToBeModified.City = customer.Address.City;
                addressToBeModified.State = customer.Address.State;
                addressToBeModified.Country = customer.Address.Country;
                addressToBeModified.PostalCode = customer.Address.PostalCode;

                _context.Entry(addressToBeModified).State = EntityState.Modified;
                _context.SaveChanges();

                _logger.LogInformation("Delivery Address details have been successfully updated.");

            }
            else if (identifiedCustomerWithAddress != null)
            {
                identifiedCustomerWithAddress.CustomerFirstName = customer.CustomerFirstName;
                identifiedCustomerWithAddress.CustomerLastName = customer.CustomerLastName;
                identifiedCustomerWithAddress.CustomerMailId = customer.CustomerMailId;
                _context.SaveChanges();

                _logger.LogInformation("Delivery Customer details have been successfully updated");
      
            }
            else
            {
                _logger.LogInformation("No data is available with information provided, so cant update data.");

                throw new Exception("No records to be Updated with provided details.");
            }
            return await Task.FromResult(_context.Customers.Include(x => x.Address).ToList()).ConfigureAwait(false);

        }
    }
}
