using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistant.Configurations
{
    internal sealed class PersonConfigurations : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder) {
            builder.HasKey(person => person.Id);
            builder.Property(account => account.Id).ValueGeneratedOnAdd();
            builder.Property(person => person.Name). HasMaxLength(60);
        }
    }
}
