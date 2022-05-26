using Microsoft.EntityFrameworkCore;

namespace GezdimGordum.Models
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options)
        {

        }

        public DbSet<Paylasim> Paylasimlar { get; set; }
    }
}
