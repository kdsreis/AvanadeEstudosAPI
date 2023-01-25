using AvanadeEstudosAPI.Domain.Entities;
using AvanadeEstudosAPI.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AvanadeEstudosAPI.Infra.Context{
    public class AvanadeEstudosAPIContext : DbContext{
        public AvanadeEstudosAPIContext() 
        {}

        public AvanadeEstudosAPIContext(DbContextOptions<AvanadeEstudosAPIContext> options) : base(options)
        {}

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }           

    }

}