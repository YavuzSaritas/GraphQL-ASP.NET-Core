using GraphQL;
using GraphQL.Types;
using GraphQL_DotNetCore.Contracts;
using GraphQL_DotNetCore.Entities;
using GraphQL_DotNetCore.GraphQL.GraphQLTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_DotNetCore.GraphQL.GraphQLQueries
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation(IOwnerRepository repository)
        {
            Field<OwnerType>(
                "createOwner",
                arguments:new QueryArguments(new QueryArgument<NonNullGraphType<OwnerInputType>> {Name="owner" }),
                resolve: context =>
                {
                    var owner = context.GetArgument<Owner>("owner");
                    return repository.CreateOwner(owner);
                });

            Field<OwnerType>(
                "updateOwner",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "owner" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> {Name="ownerId" }),
                resolve: context =>
                {
                    var ownerId = context.GetArgument<Guid>("ownerId");
                    var owner = context.GetArgument<Owner>("owner");

                    var ownerDb = repository.GetById(ownerId);
                    if (ownerDb == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find owner in db."));
                        return null;
                    }
                    return repository.UpdateOwner(ownerDb, owner);
                }
                );

            Field<StringGraphType>(
                "deleteOwner",
                arguments:new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>{ Name = "ownerId" }),
                resolve: context =>
                {
                    Guid id;
                    if (!Guid.TryParse(context.GetArgument<string>("ownerId"),out id))
                    {
                        context.Errors.Add(new ExecutionError("Id Invalid"));
                        return null;
                    }
                    var owner = repository.GetById(id);
                    return repository.DeleteOwner(owner);
                }

                );
        }
    }
}
