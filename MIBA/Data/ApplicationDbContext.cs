using MIBA.Models;
using Microsoft.EntityFrameworkCore;

namespace MIBA.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudyCategories>()
                .HasMany(c => c.Studies)
                .WithOne(s => s.Categories);
            modelBuilder.Entity<Studies>()
                .HasMany(c => c.Lectors)
                .WithMany(s => s.Studies);
        }


        public DbSet<News> News { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<RegistrationJudic> RegistrationJudic { get; set; }
        public DbSet<RegistrationPhys> RegistrationPhys { get; set; }
        public DbSet<StudyCategories> StudyCategories { get; set; }
        public DbSet<Studies> Studies { get; set; }
        public DbSet<Lectors> Lectors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<NewCourse> NewCourse { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<CourseRecomendation> CourseRecomendations { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
    }
}
