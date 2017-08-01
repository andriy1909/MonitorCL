using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonitorCLClassLibrary
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public UsersGroup Group { get; set; }
        public DateTime DateReg { get; set; }
    }
}
