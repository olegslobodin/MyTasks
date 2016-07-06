using MyTasks.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyTasks.DataAccess
{
    public class Context : DbContext
    {

        public Context() : base("MyTasks")
        {
            Database.SetInitializer<Context>(new CreateDatabaseIfNotExists<Context>());
        }

        public DbSet<TaskGroup> TaskGroups { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskGroup>()
                .HasMany(a => a.Tasks)
                .WithRequired()
                .WillCascadeOnDelete(true);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<MyTasks.Models.Priority> Priorities { get; set; }
    }
}