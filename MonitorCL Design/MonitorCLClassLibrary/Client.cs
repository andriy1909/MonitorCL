using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonitorCLClassLibrary
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Mac { get; set; }
        public string Name { get; set; }
        public Client ParentId { get; set; }
        public DateTime? DateReg { get; set; }
    }
}
