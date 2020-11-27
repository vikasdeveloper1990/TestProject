using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Integration.Models;
using Service.Integration.Services;
using System.Collections.Generic;

namespace TacoLoco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckServiceController : ControllerBase
    {
        private readonly IService _service;
        private readonly IMapper _mapper;


        /// <summary>
        /// Controller Constructor method
        /// </summary>
        /// <param name="service">IService interface constructor injection.</param>
        /// <param name="mapper">IMapper interface constructor injection.</param>
        public TruckServiceController(IService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        /// <summary>
        /// Get list of all delivery Details.
        /// </summary>
        /// <returns>List of Delivery/Customer Details</returns>
        [HttpGet]
        public List<CustomerDto> GetAllDeliveryDetails()
        {
            var results = _service.GetDeliveryDetails();
            return _mapper.Map<List<CustomerDto>>(results);

        }


        /// <summary>
        /// Add new Delivery/Customer Details.
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <returns>List of Updated Delivery/Customer Details</returns>
        [HttpPost]
        [Route("AddDeliveryDetails")]
        public List<CustomerDto> AddDeliveryDetails([FromBody] Customer customer)
        {
            var results = _service.AddDeliveryDetails(customer);
            return _mapper.Map<List<CustomerDto>>(results);
        }


        /// <summary>
        /// Delete Existing Delivery/Customer Detail
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <returns>List of Updated Delivery/Customer Details after Deletion</returns>
        [HttpPost]
        [Route("DeleteDeliveryDetails")]
        public List<CustomerDto> DeleteDeliveryDetails([FromBody] Customer customer)
        {
            var results=  _service.DeleteDeliveryDetails(customer);
            return _mapper.Map<List<CustomerDto>>(results);
        }


        /// <summary>
        /// Updated Existing Delivery/Customer Detail
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <returns>List of Updated Delivery/Customer Details after Deletion</returns>
        [HttpPost]
        [Route("UpdateDeliveryDetails")]
        public List<CustomerDto> UpdateDeliveryDetails([FromBody] Customer customer)
        {
            var results = _service.UpdateDeliveryDetails(customer);
            return _mapper.Map<List<CustomerDto>>(results);
        }

    }
}
