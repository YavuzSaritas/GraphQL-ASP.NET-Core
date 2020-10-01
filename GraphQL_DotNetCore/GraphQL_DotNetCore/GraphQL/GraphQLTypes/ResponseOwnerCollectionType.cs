using GraphQL_DotNetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_DotNetCore.GraphQL.GraphQLTypes
{
    public class ResponseOwnerCollectionType
    {
        public List<Owner> Owners { get; set; }
    }
}
