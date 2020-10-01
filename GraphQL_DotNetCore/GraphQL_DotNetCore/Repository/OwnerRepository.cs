using GraphQL_DotNetCore.Contracts;
using GraphQL_DotNetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_DotNetCore.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationContext _context;
        public OwnerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<Owner> GetAll() => _context.Owners.ToList();

        public Owner GetById(Guid id) => _context.Owners.SingleOrDefault(p => p.Id.Equals(id));
    }
}
