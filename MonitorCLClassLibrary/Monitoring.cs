using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorCLClassLibrary
{
    [Serializable]
    public abstract class Monitoring
    {
        public abstract string GetFields();

        public abstract string GetDescriptionFields();
    }
}
