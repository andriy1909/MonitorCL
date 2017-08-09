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
using System.Diagnostics;

namespace MonitorCLClassLibrary.JSON
{
    [DataContract]
    public class JsonPack
    {
        [DataMember]
        public string metod = null;
        [DataMember]
        public string bearer = null;//token
        [DataMember]
        public JsonData data;
        [DataMember]
        public DateTime time;
        [DataMember]
        public string signature = "";
        [DataMember]
        public bool Accept;
        [DataMember]
        public string Errors;

        [IgnoreDataMember]
        private DateTime currentDataTime = DateTime.UtcNow;


        public void SetSignature()
        {
            signature = null;

            HMACSHA256 sha = new HMACSHA256(Encoding.ASCII.GetBytes(Properties.Settings.Default.privateKey));
            signature = Encoding.ASCII.GetString(sha.ComputeHash(Encoding.ASCII.GetBytes(data.ToString())));
        }

        public bool CheckSignature()
        {
            string oldSignature = signature;
            SetSignature();
            return oldSignature == signature && signature != "";
        }

        public bool CheckTime(double milSec = 10000)
        {
            return true;// currentDataTime.Subtract(data.time).TotalMilliseconds < milSec;
        }

        public override string ToString()
        {
            metod = data.GetType().Name;
            SetSignature();
            data.EncriptData();
            time = DateTime.UtcNow;

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(JsonPack));

            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, this);
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
            metod = deserializedJsonPack.metod;
            bearer = deserializedJsonPack.bearer;
            data = deserializedJsonPack.data;
            time = deserializedJsonPack.time;
            signature = deserializedJsonPack.signature;
            data.DecriptData();

            return CheckTime() && CheckSignature();
        }






        //delete
        public string GetJsonStr_Delete()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(JsonPack));

            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, this);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);
            string json = sr.ReadToEnd();

            return json;
        }

        //delete
        public string GetJsonDataStr_Delete()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(JsonData));

            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, data);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);
            string json = sr.ReadToEnd();

            return json;
        }

    }
}