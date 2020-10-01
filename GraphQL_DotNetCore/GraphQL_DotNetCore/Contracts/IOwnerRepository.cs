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
        Owner GetById(Guid id);
        Owner CreateOwner(Owner owner);
        Owner UpdateOwner(Owner dbOwner, Owner owner);
        string DeleteOwner(Owner owner);
    }
}
