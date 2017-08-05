using System;

namespace MonitorCLClassLibrary.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Information { get; set; }
        public string TypePC { get; set; }
        public UsersGroup Group { get; set; }
        public DateTime DateReg { get; set; }
    }
}
