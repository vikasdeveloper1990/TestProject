using Alba;
using Service.Integration.Models;
using Xunit;

namespace TacoLocoIntegrationTest
{
    public class TacoLocoDeliveryTest :  BaseApplicationStartup 
    {
        private const string AddDetailsUrl = "/api/TruckService/AddDeliveryDetails";
        private Customer CustomerDetails()
        {
            var customer = new Customer()
            {
                CustomerFirstName = "Labs",
                Address = new Address()
                {
                    Address1 = "15180 Old hickory",
                    City = "Nashville",
                    State = "TN",
                    PostalCode = "37211",
                }
            };

            return customer;
        }

        [Fact]
        public void Should_Add_deliveryDetails()
        {
            var deliveryDetails = CustomerDetails();
            WebApp.Scenario(_ =>
            {
                _.Post.Json(deliveryDetails);
                _.Post.Url($"{AddDetailsUrl}");
                _.StatusCodeShouldBeOk();
            });
        }
    }
}
