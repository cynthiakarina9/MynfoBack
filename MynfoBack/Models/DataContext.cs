using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MynfoBack.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<Ejemplo> Ejemploes { get; set; }

        public System.Data.Entity.DbSet<MynfoBack.Models.DeviceUser> DeviceUsers { get; set; }
    }
}