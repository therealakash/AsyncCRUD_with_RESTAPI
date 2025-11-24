using AsyncCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace AsyncCRUD.Repositry
{
    public class Appdbcontext:DbContext
    {
        public Appdbcontext(DbContextOptions<Appdbcontext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book>()
                  .HasOne<Author>()
                  .WithMany()
                  .HasForeignKey(b => b.AuthorId)
                  .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);


        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

    }
}
