using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using MonitorCLClassLibrary;

namespace MonitorCLServer
{
    class MonitoringDB : DbContext
    {
        public MonitoringDB():base ("MonitorDB")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UsersGroup> UserGroups { get; set; }
               
    }
}
