using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_DotNetCore.Entities
{
    public class Owner
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is Required!")]
        public string Name { get; set; }
        public string Address { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
