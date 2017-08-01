using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using MonitorCLClassLibrary;

namespace JSON
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
        [DataMember]
        public DateTime time;
        [DataMember]
        public User user;

        public JsonData()
        {

            time = DateTime.UtcNow;
        }
    }
}
