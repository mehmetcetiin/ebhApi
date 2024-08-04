using Microsoft.EntityFrameworkCore;
using ebhApi.Models;

namespace ebhApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<EbhBasvurular> EbhBasvurulari { get; set; }
        public DbSet<Ekip> Ekipler { get; set; }
        public DbSet<Hastalik> Hastaliklar { get; set; }
        public DbSet<Sube> Subeler { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
