using GraphQL_DotNetCore.Contracts;
using GraphQL_DotNetCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_DotNetCore.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationContext _context;
        public AccountRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ILookup<Guid, Account>> GetAccountsByOwnerIds(IEnumerable<Guid> ownerIds)
        {
            var accounts = await _context.Accounts.Where(p => ownerIds.Contains(p.OwnerId)).ToListAsync();
            return accounts.ToLookup(x => x.OwnerId);
        }

        public List<Account> GetAllAccountsPerOwner(Guid ownerId) => _context.Accounts.Where(p => p.OwnerId.Equals(ownerId)).ToList();
    }
}
