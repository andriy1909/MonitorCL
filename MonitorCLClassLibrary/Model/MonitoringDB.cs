using System.Data.Entity;

namespace MonitorCLClassLibrary.Model
{
    public class MonitoringDB : DbContext
    {
        public MonitoringDB():base ("MonitorDB")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UsersGroup> UserGroups { get; set; }
        public DbSet<LicenceKey> LicenceKeys { get; set; }
    }
}
