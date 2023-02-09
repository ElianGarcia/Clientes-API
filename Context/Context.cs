using Clientes_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clientes_API.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Addresses)
                .WithOne(a => a.Cliente)
                .OnDelete(DeleteBehavior.Cascade);
        }
        
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
    }
}
