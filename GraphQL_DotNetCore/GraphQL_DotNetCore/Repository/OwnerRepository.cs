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

        public Owner CreateOwner(Owner owner)
        {
            owner.Id = Guid.NewGuid();
            _context.Owners.Add(owner);
            _context.SaveChanges();
            return owner;
        }

        public string DeleteOwner(Owner owner)
        {
            _context.Remove(owner);
            _context.SaveChanges();
            return "OK";
        }

        public List<Owner> GetAll() => _context.Owners.ToList();

        public Owner GetById(Guid id) => _context.Owners.SingleOrDefault(p => p.Id.Equals(id));

        public Owner UpdateOwner(Owner dbOwner, Owner owner)
        {
            dbOwner.Name = owner.Name;
            dbOwner.Address = owner.Address;
            _context.SaveChanges();
            return dbOwner;
        }
    }
}
