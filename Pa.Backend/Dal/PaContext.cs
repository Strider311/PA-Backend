using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pa.Backend.Models;
namespace Pa.Backend.Dal
{

    public class PaContext : DbContext
    {
        public DbSet<ImageDbModel> Images { get; set; }

        public DbSet<SessionDbModel> Sessions { get; set; }

        public PaContext(DbContextOptions<PaContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            if (!options.IsConfigured)
            {
                IConfigurationRoot config = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.Development.json")
                   .Build();
                string connString = config.GetConnectionString("pg_db");
                options.UseNpgsql(connString); //Or whatever DB you are using
            }
        }
    }

}