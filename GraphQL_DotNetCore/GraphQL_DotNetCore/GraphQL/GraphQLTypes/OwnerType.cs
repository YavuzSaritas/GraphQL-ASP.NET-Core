using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQL_DotNetCore.Contracts;
using GraphQL_DotNetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_DotNetCore.GraphQL.GraphQLTypes
{
    public class OwnerType : ObjectGraphType<Owner>
    {
        public OwnerType(IAccountRepository repository,IDataLoaderContextAccessor dataLoader)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the owner object.");
            Field(x => x.Name).Description("Name property from the owner object.");
            Field(x => x.Address).Description("Address property from the owner object.");
            Field<ListGraphType<AccountType>>(
                "accounts",
                resolve: context => 
                {
                    //Hepsi için tek tek istek atar
                    //repository.GetAllAccountsPerOwner(context.Source.Id)

                    //loader ile IN() kullarak tek sorgu kullandık.Startup.cs geliştirmeside var.
                    var loader = dataLoader.Context.GetOrAddCollectionBatchLoader<Guid, Account>("GetAccountsByOwnerIds", repository.GetAccountsByOwnerIds);
                    return loader.LoadAsync(context.Source.Id);
                }
                );
        }
    }
}
