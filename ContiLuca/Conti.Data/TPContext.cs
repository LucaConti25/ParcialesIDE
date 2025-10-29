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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Multa>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Patente).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Monto).IsRequired().HasPrecision(18,2);
                entity.Property(e => e.Fecha).IsRequired();
                entity.Property(e => e.Estado).IsRequired().HasMaxLength(100);
            });
        }

    }

   
}
