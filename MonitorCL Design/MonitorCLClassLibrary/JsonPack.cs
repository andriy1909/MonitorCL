using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;

namespace MonitorCLClassLibrary
{
    [DataContract]
    public class JsonPack
    {
        [DataMember]
        public JsonHeader header;
        [DataMember]
        public JsonData data;
        [DataMember]
        public string signature = "";


        /*public string login;
        public string password;
        public DateTime time;
        public string signature;

        public List<Monitoring> monitoring;
        public List<byte[]> images;*/

        public void SetSignature(string privateKey)
        {
            HMACSHA256 sha = new HMACSHA256(Encoding.ASCII.GetBytes(privateKey));
            signature = Encoding.ASCII.GetString(sha.ComputeHash(Encoding.ASCII.GetBytes(GetJsonDataStr())));
        }

        public bool CheckSignature(string privateKey)
        {
            string oldSignature = signature;
            SetSignature(privateKey);
            return oldSignature == signature && signature != "";
        }

        public bool Validate(string token, string privateKey)
        {
            return CheckSignature(privateKey) && token == header.bearer;
        }

        public bool CheckTime(double milSec=10000)
        {
            return true;// DateTime.UtcNow.Subtract(data.time).TotalMilliseconds < milSec;
        }

        public string GetJsonStr()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(JsonPack));

            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, this);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);
            string json = sr.ReadToEnd();

            return json;
        }


        public string GetJsonDataStr()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(JsonData));

            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, data);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);
            string json = sr.ReadToEnd();

            return json;
        }

        public void GetJson(string str)
        {
            JsonPack deserializedJsonPack = new JsonPack();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(str));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedJsonPack.GetType());
            deserializedJsonPack = ser.ReadObject(ms) as JsonPack;
            ms.Close();
            this.header = deserializedJsonPack.header;
            this.data = deserializedJsonPack.data;
            this.signature = deserializedJsonPack.signature;
        }
    }
}