using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using MonitorCLClassLibrary;
using System.Runtime.Serialization.Json;
using System.IO;

namespace MonitorCLClassLibrary.JSON
{
    [DataContract]
    public class JSDRegister : JsonData
    {        
        [IgnoreDataMember]
        public override EncriptLevel encriptLevel
        {
            get
            {
                return EncriptLevel.VeryHigh;
            }
        }

        /// <summary>
        /// Serial key
        /// </summary>
        [DataMember]
        public string key;
        /// <summary>
        /// BaseBoad serial
        /// </summary>
        [DataMember]
        public string Id_1;
        /// <summary>
        /// BiosSerial
        /// </summary>
        [DataMember]
        public string Id_2;
        [DataMember]
        public string computerName;
        
        public override void EncriptData()
        {

        }

        public override void DecriptData()
        {

        }

        public override string ToString()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(JSDRegister));

            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, this);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);
            string json = sr.ReadToEnd();
            return json;
        }
    }
}
