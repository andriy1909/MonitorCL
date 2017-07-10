using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonitorCLClassLibrary
{
    public class JsonData
    {
        public List<Monitoring> monitoring;
        public string text;

        public DateTime time;

        public JsonData()
        {
            time = DateTime.UtcNow;
        }
    }
}
