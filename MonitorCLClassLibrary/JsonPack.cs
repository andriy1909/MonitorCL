using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Drawing;
using System.IO;

namespace MonitorCLClassLibrary
{
    public class JsonPack
    {
        public string login;
        public string password;
        public List<Monitoring> monitoring;
        public List<byte[]> images;

        public string getJsonStr()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(JsonPack));

            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, this);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);
            return sr.ReadToEnd();
        }

        public JsonPack getJson(string str)
        {
            JsonPack deserializedJsonPack = new JsonPack();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(str));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedJsonPack.GetType());
            deserializedJsonPack = ser.ReadObject(ms) as JsonPack;
            ms.Close();
            return deserializedJsonPack;
        }
    }
}