using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace GraphQL_DotNetCore.Entities
{
    public class AccountContextConfiguration : IEntityTypeConfiguration<Account>
    {
        private Guid[] _ids;
        public AccountContextConfiguration(Guid[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasData(
                new Account
                {
                    Id = Guid.NewGuid(),
                    Type = TypeOfAccount.Cash,
                    Description = "Cash Account for our users",
                    OwnerId = _ids[0]
                },
                  new Account
                  {
                      Id = Guid.NewGuid(),
                      Type = TypeOfAccount.Saving,
                      Description = "Saving Account for our users",
                      OwnerId = _ids[1]
                  },
                     new Account
                     {
                         Id = Guid.NewGuid(),
                         Type = TypeOfAccount.Income,
                         Description = "Cash Account for our users",
                         OwnerId = _ids[1]
                     }
                );

        }
    }
}
