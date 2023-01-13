using Microsoft.EntityFrameworkCore;
using PersonalTable.Model.Entity;

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
        public Person Person { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options):base (options) { }
    }
}
