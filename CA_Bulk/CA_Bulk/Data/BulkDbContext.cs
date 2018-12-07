using Microsoft.EntityFrameworkCore;

namespace CA_Bulk.Data
{
    public class BulkDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=BULKDB;Trusted_Connection=True;");
        }

        public DbSet<BulkTable> BulkTable { get; set; }
    }
}