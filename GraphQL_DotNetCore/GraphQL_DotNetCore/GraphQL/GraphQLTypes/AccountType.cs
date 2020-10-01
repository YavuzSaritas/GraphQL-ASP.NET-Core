﻿using GraphQL.Types;
using GraphQL_DotNetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_DotNetCore.GraphQL.GraphQLTypes
{
    public class AccountType : ObjectGraphType<Account>
    {
        public AccountType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the account object.");
            Field(x => x.Description).Description("Description property from the account object.");
            Field(x => x.OwnerId, type: typeof(IdGraphType)).Description("OwnerId property from the account object.");
            Field<AccountTypeEnumType>("Type", "Enumeration for the account type object.");
        }
    }
}