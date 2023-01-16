namespace PersonalTable.Model
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class ApplicationContext : DbContext
    {
        public DbSet<Person> Person { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base (options) 
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
