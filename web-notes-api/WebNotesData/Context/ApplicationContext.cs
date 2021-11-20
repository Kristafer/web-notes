using Microsoft.EntityFrameworkCore;
using WebNotesData.Entities;

namespace WebNotesData.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<NoteTag> NoteTags { get; set; }
        public DbSet<ShareNote> ShareNotes { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
        }
    }
}
