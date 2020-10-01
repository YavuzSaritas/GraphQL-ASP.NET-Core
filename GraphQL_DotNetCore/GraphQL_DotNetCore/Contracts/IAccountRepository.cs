using GraphQL_DotNetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_DotNetCore.Contracts
{
    public interface IAccountRepository
    {
        List<Account> GetAllAccountsPerOwner(Guid ownerId);
        //Owner'ın sahip olduğu Accountları alırken hepsi için ayrı ayrı istek atmasını engeller. Hepsi için Tek istek atar
        Task<ILookup<Guid, Account>> GetAccountsByOwnerIds(IEnumerable<Guid> ownerIds); 
    }
}
