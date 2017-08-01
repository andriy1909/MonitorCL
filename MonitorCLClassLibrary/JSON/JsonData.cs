using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace MonitorCLClassLibrary
{
    [DataContract]
    public class JsonData
    {
        [DataMember]
        public List<Monitoring> monitoring;
        [DataMember]
        public string text;
        [DataMember]
        public List<byte[]> images;

        public DateTime time;

        public JsonData()
        {
            time = DateTime.UtcNow;
        }
    }
}
