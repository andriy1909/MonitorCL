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
using MonitorCLClassLibrary.Properties;
using System.Diagnostics;

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


        public void SetSignature()
        {
            HMACSHA256 sha = new HMACSHA256(Encoding.ASCII.GetBytes(Settings.Default.privateKey));
            signature = Encoding.ASCII.GetString(sha.ComputeHash(Encoding.ASCII.GetBytes(GetJsonDataStr())));
        }

        public bool CheckSignature()
        {
            string oldSignature = signature;
            SetSignature();
            return oldSignature == signature && signature != "";
        }

        public bool CheckTime(double milSec = 10000)
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

        public bool GetJson(string str)
        {
            JsonPack deserializedJsonPack = new JsonPack();
            try
            {
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(str)))
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedJsonPack.GetType());
                    deserializedJsonPack = ser.ReadObject(ms) as JsonPack;
                    ms.Close();
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err);
                return false;
            }
            this.header = deserializedJsonPack.header;
            this.data = deserializedJsonPack.data;
            this.signature = deserializedJsonPack.signature;

            return CheckTime() && CheckSignature();
        }
    }
}