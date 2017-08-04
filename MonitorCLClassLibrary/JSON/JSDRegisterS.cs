using JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonitorCLClassLibrary
{
    public class JSDRegisterS : JsonData
    {
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
