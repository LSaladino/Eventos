using Core.Domain;
using Core.Domain.Model.Event;
using Core.Domain.Model.User;
using Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> op) : base(op)
        {

        }


        public DbSet<Customer> Customers { get; set; }  
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.Entity<User>().HasIndex(p => p.Email).IsUnique();
        }
    }
}
