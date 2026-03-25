using Microsoft.EntityFrameworkCore;
using Sales_Management_API.Model;

namespace Sales_Management_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Salesheader> Salesheaders { get; set; }
        public DbSet<Salesdetail> Salesdetails { get; set; }
    }
}
