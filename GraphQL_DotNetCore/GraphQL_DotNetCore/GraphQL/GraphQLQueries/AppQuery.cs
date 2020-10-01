using GraphQL;
using GraphQL.Types;
using GraphQL_DotNetCore.Contracts;
using GraphQL_DotNetCore.GraphQL.GraphQLTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_DotNetCore.GraphQL.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IOwnerRepository repository)
        {
            Field<ListGraphType<OwnerType>>(
                "owners",
                resolve: context =>  repository.GetAll());
            Field<OwnerType>(
                "owner",
                arguments:new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> {Name="ownerId" }),
                resolve: context =>
                {
                    Guid id;
                    if (!Guid.TryParse(context.GetArgument<string>("ownerId"),out id))
                    {
                        context.Errors.Add(new ExecutionError("Wrong value for guid")); // --> Error handling
                        return null;
                    }
                   // var id = context.GetArgument<Guid>("ownerId"); --> basic
                    return repository.GetById(id);
                });
        }
    }
}
