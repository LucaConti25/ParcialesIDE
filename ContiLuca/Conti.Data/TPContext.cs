using Microsoft.EntityFrameworkCore;
using Conti.ModeloDominio;
using Microsoft.Extensions.Configuration;

namespace Conti.Data
{
    public class TPContext: DbContext
    {
        public DbSet<Multa> Multas { get; set; }
        public TPContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

    }

   
}
