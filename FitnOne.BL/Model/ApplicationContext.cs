using Microsoft.EntityFrameworkCore;

namespace FitnessApp.BL.Model
{
    public class ApplicationContext : DbContext
    {
        //public ApplicationContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Username = postgres; Password = 1111; Server = localhost; Port = 5432; Database = netTestFitnesDb; Integrated Security = true;");
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Eating> Eatings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
