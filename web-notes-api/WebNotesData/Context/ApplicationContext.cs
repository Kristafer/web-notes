using Microsoft.EntityFrameworkCore;
using WebNotesData.Entities;

namespace WebNotesData.Context
{
    public class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
        }
    }
}
