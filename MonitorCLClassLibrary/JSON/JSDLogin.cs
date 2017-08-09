using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace MonitorCLClassLibrary.JSON
{
    [DataContract]
    public class JSDLogin:JsonData
    {
        public override EncriptLevel encriptLevel
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        [DataMember]
        public string LicenseKey { get; set; }
        [DataMember]
        public string UniqPC { get; set; }

        public override void DecriptData()
        {
            throw new NotImplementedException();
        }

        public override void EncriptData()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(JSDLogin));

            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, this);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);
            string json = sr.ReadToEnd();
            return json;
        }
    }
}