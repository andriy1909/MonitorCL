using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Net.NetworkInformation;

namespace JSON
{
    [DataContract]
    public class JsonHeader
    {
        [DataMember]
        public string basic;
        /*{
            get
            {
                return Encoding.ASCII.GetString(Convert.FromBase64String(basic));                 
            }
            set
            {
                value = Convert.ToBase64String(Encoding.ASCII.GetBytes(login + ":" + password));
                if(value.Split(':').Count()==2)

                login = value.Split(':')[0];
                password = value.Split(':')[1];
            }
        }*/
        [DataMember]
        public string bearer;//token
        [DataMember]
        public string mac;
        [IgnoreDataMember]
        public string login { get; private set; }
        [IgnoreDataMember]
        public string password { get; private set; }
        
        public void setToken(string token)
        {
            bearer = token;
        }

        public void setLoginPassword(string login, string password)
        {
            basic = Convert.ToBase64String(Encoding.ASCII.GetBytes(login + ":" + password));
            this.login = login;
            this.password = password;
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
