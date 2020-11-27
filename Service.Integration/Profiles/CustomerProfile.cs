using AutoMapper;
using Service.Integration.Models;

namespace Service.Integration.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Address, AddressDto>();
            CreateMap<Customer, CustomerDto>();
        }
    }
}
