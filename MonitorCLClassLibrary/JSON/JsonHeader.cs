using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Net.NetworkInformation;

namespace MonitorCLClassLibrary
{
    [DataContract]
    public class JsonHeader
    {
        [DataMember]
        public Metods metod;
        [DataMember]
        public string basic;
        [DataMember]
        public string bearer;//token
        [DataMember]
        public string mac;

        public JsonHeader(Metods metod = Metods.query)
        {
            this.metod = metod;
        }

        public void setToken(string token)
        {
            bearer = token;
        }

        public void setLoginPassword(string login, string password)
        {
            basic = Convert.ToBase64String(Encoding.ASCII.GetBytes(login + ":" + password));
        }

        public string getLoginPassword()
        {
            return Encoding.ASCII.GetString(Convert.FromBase64String(basic));
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
