using CSharpClassProject.EfCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CSharpClassProject.EfCore.Classes.Entities
{
    public class Context : DbContext, IContext
    {
        public DbSet<Developer> Developers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configures the database connection string
            optionsBuilder.UseSqlServer("<connection string>");
        }
    }
}