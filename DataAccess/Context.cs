using MyTasks.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyTasks.DataAccess
{
    public class Context : DbContext
    {

        public Context() : base("Context")
        {
            Database.SetInitializer<Context>(null);
        }

        public DbSet<TaskGroup> TaskGroups { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<TaskGroup>()
            //    .HasOptional(a => a.Tasks)
            //    .WithOptionalDependent()
            //    .WillCascadeOnDelete(true);
        }
    }
}