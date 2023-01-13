using Microsoft.EntityFrameworkCore;
using PersonalTable.Model.Entity;
using static System.Net.Mime.MediaTypeNames;

namespace PersonalTable.Model
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Person> Person { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base (options) 
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Person>().
                Property(p => p.Birthday)
                .HasColumnType("date");
        }

    }
}
