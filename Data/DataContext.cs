using Microsoft.EntityFrameworkCore;

namespace ENSEK.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Reading> Readings { get; set; }

}
}
