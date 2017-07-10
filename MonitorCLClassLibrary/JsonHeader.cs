using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace MonitorCLClassLibrary
{
    public class JsonHeader
    {
        string basic;
        string bearer;//token


        public void setLodinPassword(string login, string password)
        {
            basic = Convert.ToBase64String(Encoding.ASCII.GetBytes(login + ":" + password));
            new HMACSHA256().
        }

        public string getLoginPassword()
        {
            return Encoding.ASCII.GetString(Convert.FromBase64String(bearer));
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
