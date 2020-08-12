using CSharpClassProject.EfCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CSharpClassProject.EfCore.Classes.Entities
{
    public class Context : DbContext, IContext
    {
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Tester> Testers { get; set; }
        public DbSet<DeveloperSkill> DeveloperSkills { get; set; }
        public DbSet<TesterSkill> TesterSkills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configures the database connection string
            optionsBuilder.UseSqlServer("<connection string>");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<DeveloperSkill>()
                .HasIndex(developerSkill => new { developerSkill.DeveloperId, developerSkill.Skill })
                .IsUnique()
                .HasName("UX_DeveloperSkills_DeveloperId_Skill");

            modelBuilder
                .Entity<TesterSkill>()
                .HasIndex(testerSkill => new { testerSkill.TesterId, testerSkill.Skill })
                .IsUnique()
                .HasName("UX_TesterSkills_TesterId_Skill");
        }
    }
}