namespace Service.Integration.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerMailId { get; set; }
        public Address Address { get; set; }

    }

}
