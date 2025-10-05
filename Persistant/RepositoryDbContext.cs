using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistant
{
    public sealed class RepositoryDbContext : DbContext
    {

        public RepositoryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Animal> Animals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);

            //modelBuilder.Entity<BaseEntity>().HasKey(e => e.Id);
            modelBuilder.Entity<BaseEntity>().UseTpcMappingStrategy();
            //modelBuilder.Entity<Person>();
            //modelBuilder.Entity<Animal>();

                //Apply global filter for soft deletes to all BaseEntity - derived types
                //foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                //         .Where(t => typeof(BaseEntity).IsAssignableFrom(t.ClrType) && !t.IsAbstract()))
                //{

                //    var parameter = Expression.Parameter(entityType.ClrType, "e");
                //    var prop = Expression.PropertyOrField(parameter, nameof(BaseEntity.IsDeleted));
                //    var notDeleted = Expression.Lambda(Expression.Equal(prop, Expression.Constant(false)), parameter);
                //    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(notDeleted);
                //}
            // Add indexes, constraints, seed data etc. here as needed
        }
    }
}
