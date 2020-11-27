using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Service.Integration.Models;

namespace Service.Integration.Queries
{
    public class GetCustomersQuery : IRequest<List<Customer>>
    {
    }
}
