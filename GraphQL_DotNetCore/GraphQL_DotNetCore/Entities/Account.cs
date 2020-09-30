using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_DotNetCore.Entities
{
    public class Account
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Type is Required")]
        public TypeOfAccount Type { get; set; }
        public string Description { get; set; }

        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}
