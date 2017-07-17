using System;
using MonitorCLClassLibrary;
using System.Data.Entity;

namespace MonitorCLServer
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; } 

        public DataContext():base("MonitorDB")
        {

        }
    }
}