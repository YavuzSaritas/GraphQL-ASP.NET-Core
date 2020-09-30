﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_DotNetCore.Entities
{
    public class OwnerContextConfiguration : IEntityTypeConfiguration<Owner>
    {
        private Guid[] _ids;
        public OwnerContextConfiguration(Guid[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.HasData(
                new Owner
                {
                    Id = _ids[0],
                    Name="John Doe",
                    Address="John Doe's Adress"
                },
                new Owner
                {
                    Id = _ids[1],
                    Name = "Jane Done",
                    Address = "Jane Doe's Adress"
                }
                );
        }
    }
}