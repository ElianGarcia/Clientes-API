using Clientes_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clientes_API.DAL
{
    public class Context : DbContext
    {
        public Context() : base()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("AppDb");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
    }
}
