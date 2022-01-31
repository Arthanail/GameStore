using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }
        public DbSet<Game> Games { get; set; }
    }
}