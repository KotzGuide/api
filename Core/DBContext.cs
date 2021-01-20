using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<SaintModel> Saints { get; set; }
    }
}
