using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using web_basics.data.Entities;

namespace web_basics.data
{
    public class WebBasicsDBContext : DbContext
    {
        IConfiguration _configuration;
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Dog> Dogs { get; set; }

        public WebBasicsDBContext(IConfiguration configuration) : base()
        {
            this._configuration = configuration;
            DbInitializer.Initialize(this);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }



    }
}
