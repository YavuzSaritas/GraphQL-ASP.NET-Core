using GraphQL_DotNetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_DotNetCore.Contracts
{
    public interface IOwnerRepository
    {
        List<Owner> GetAll();
    }
}
