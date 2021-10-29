using DDD.Domain.Enties;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure.DB
{
    public class ContextDatabase : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ContextDatabase() { }

        public ContextDatabase(DbContextOptions _context) : base(_context) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(connectionString: "Server=localhost;DataBase=db_supermarket;Uid=root;Pwd=");
        }
    }
}
