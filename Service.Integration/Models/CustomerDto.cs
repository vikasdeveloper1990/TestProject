namespace Service.Integration.Models
{
    public class CustomerDto
    {
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerMailId { get; set; }
        public AddressDto Address { get; set; }
    }
}
