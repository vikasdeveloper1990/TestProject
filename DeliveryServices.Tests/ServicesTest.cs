using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Service.Integration.DataServices;
using Service.Integration.Models;
using Service.Integration.Services;
using System;
using Xunit;

namespace DeliveryServices.Tests
{
    public class ServicesTest:IDisposable
    {
        private readonly CustomerContext _context;
        private readonly IService _service;
        private readonly Mock<ILogger<Service.Integration.Services.Service>> _loggerMock= new Mock<ILogger<Service.Integration.Services.Service>>();

        public ServicesTest()
        {
            var options = new DbContextOptionsBuilder<CustomerContext>().
                UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _context = new CustomerContext(options);
            _context.Database.EnsureCreated();
            _service = new Service.Integration.Services.Service(_loggerMock.Object, _context);
        }

        [Fact]
        public async void Can_Get_DeliveryDetails()
        {
          var result =  await _service.GetDeliveryDetails().ConfigureAwait(false);

            Assert.Empty(result);
        }

        [Fact]
        public async void Can_Insert_DeliveryDetails()
        {
            var result = await _service.AddDeliveryDetails(CustomerDetails()).ConfigureAwait(false);

            Assert.Single(result);
        }

        [Fact]
        public async void Can_Update_DeliveryDetails()
        {
            var result = await _service.UpdateDeliveryDetails(CustomerDetails()).ConfigureAwait(false);

            Assert.Empty(result);
        }

        [Fact]
        public async void Can_Delete_DeliveryDetails()
        {
            var result =await  _service.DeleteDeliveryDetails(CustomerDetails()).ConfigureAwait(false);

            Assert.Empty(result);
        }

        private Customer CustomerDetails()
        {
            var customer = new Customer()
            {
                CustomerFirstName = "Detroit",
                CustomerLastName = "Labs",
                CustomerMailId = "Labs@test.com",
                Address = new Address()
                {
                    Address1 = "15180 Old hickory",
                    City ="Nashville",
                    State = "TN",
                    PostalCode = "37211",
                }
            };

            return customer;
        }
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
