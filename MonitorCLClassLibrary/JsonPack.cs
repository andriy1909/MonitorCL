using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace MonitorCLClassLibrary
{
    public class JsonPack
    {
        string login;
        string password;
        Monitoring[] monitoring;
        

        public string getJsonStr()
        {
            throw new NotImplementedException();
        }
    }
}
