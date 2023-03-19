using Microsoft.EntityFrameworkCore;
using Abby.Model;
namespace Abby.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        public DbSet<Category> Categories { get; set; }
    }
}