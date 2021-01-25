using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<SaintModel> Saints { get; set; }
        public DbSet<CosmoModel> Cosmos { get; set; }
        public DbSet<CosmoSetModel> CosmoSets { get; set; }
    }
}
