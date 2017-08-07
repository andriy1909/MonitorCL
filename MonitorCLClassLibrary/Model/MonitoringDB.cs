using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MonitorCLClassLibrary.Model
{
    public class MonitoringDB : DbContext
    {
        public MonitoringDB() : base("MonitorDB")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UsersGroup> UserGroups { get; set; }
        public DbSet<LicenceKey> LicenceKeys { get; set; }

        public static void ReCreareDB()
        {
            var db = new MonitoringDB();

            if (db.Database.Exists())
                db.Database.Delete();
            db.Database.Create();
        }
        
        public static List<UsersGroup> GetUsersGroups()
        {
            var db = new MonitoringDB();
            return db.UserGroups.ToList();
        }
    }
}
