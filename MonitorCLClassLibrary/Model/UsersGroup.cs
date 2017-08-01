using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonitorCLClassLibrary
{
    public class UsersGroup
    {
        public int UsersGroupId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public UsersGroup Parent { get; set; }
    }
}
