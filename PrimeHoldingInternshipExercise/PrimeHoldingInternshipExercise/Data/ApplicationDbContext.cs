namespace PrimeHoldingInternshipExercise.Data
{
    using Microsoft.EntityFrameworkCore;
    using PrimeHoldingInternshipExercise.Data.Models;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add the skills to the database
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "Programming", Description = "Ability to write computer programs" },
                new Skill { Id = 2, Name = "Web Development", Description = "Ability to develop web applications" },
                new Skill { Id = 3, Name = "Database Management", Description = "Ability to manage and maintain databases" }
            );

            // Configure the many-to-many relationship between Employee and Skill entities
            modelBuilder.Entity<EmployeeSkill>()
                .HasKey(es => new { es.EmployeeId, es.SkillId });

            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(es => es.Employee)
                .WithMany(e => e.EmployeeSkills)
                .HasForeignKey(es => es.EmployeeId);

            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(es => es.Skill)
                .WithMany(s => s.EmployeeSkills)
                .HasForeignKey(es => es.SkillId);
        }

    }
}
