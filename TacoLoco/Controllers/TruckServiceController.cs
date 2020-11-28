using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Integration.Models;
using Service.Integration.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<List<CustomerDto>> GetAllDeliveryDetails()
        {
            var results =await _service.GetDeliveryDetails().ConfigureAwait(false);
            return _mapper.Map<List<CustomerDto>>(results);

        }


        /// <summary>
        /// Add new Delivery/Customer Details.
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <returns>List of Updated Delivery/Customer Details</returns>
        [HttpPost]
        [Route("AddDeliveryDetails")]
        public async Task<List<CustomerDto>> AddDeliveryDetails([FromBody] Customer customer)
        {
            var results = await _service.AddDeliveryDetails(customer).ConfigureAwait(false);
            return _mapper.Map<List<CustomerDto>>(results);
        }


        /// <summary>
        /// Delete Existing Delivery/Customer Detail
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <returns>List of Updated Delivery/Customer Details after Deletion</returns>
        [HttpPost]
        [Route("DeleteDeliveryDetails")]
        public async Task<List<CustomerDto>> DeleteDeliveryDetails([FromBody] Customer customer)
        {
            var results= await  _service.DeleteDeliveryDetails(customer).ConfigureAwait(false);
            return _mapper.Map<List<CustomerDto>>(results);
        }


        /// <summary>
        /// Updated Existing Delivery/Customer Detail
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <returns>List of Updated Delivery/Customer Details after Deletion</returns>
        [HttpPost]
        [Route("UpdateDeliveryDetails")]
        public async Task<List<CustomerDto>> UpdateDeliveryDetails([FromBody] Customer customer)
        {
            var results = await _service.UpdateDeliveryDetails(customer).ConfigureAwait(false);
            return _mapper.Map<List<CustomerDto>>(results);
        }

    }
}
