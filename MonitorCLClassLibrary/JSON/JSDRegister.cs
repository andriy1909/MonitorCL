using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace JSON
{
    //[DataContract]
    public class JSDRegister : JsonData
    {
        public string Name;
        public string Company;
        public DateTime DateReg;
    }
}
