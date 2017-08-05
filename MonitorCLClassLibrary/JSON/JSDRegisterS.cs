using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Security.Cryptography;
using MonitorCLClassLibrary;

namespace MonitorCLClassLibrary.JSON
{
    [DataContract]
    public class JSDRegisterS : JsonData
    {
        [DataMember]
        public string token { get; set; }


        public override EncriptLevel encriptLevel
        {
            get
            {
                return EncriptLevel.VeryHigh;
            }
        }

        public override void DecriptData()
        {

        }

        public override void EncriptData()
        {

        }
    }
}
