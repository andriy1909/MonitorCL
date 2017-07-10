using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorCLClassLibrary
{
    [Serializable]
    public abstract class Monitoring
    {
        public abstract string Fields { get; }

        public abstract string GetSign();
        
        protected DateTime ConvertDate(string value)
        {
            if (value == "" || value == null || value.Length < 8)
                return DateTime.MinValue;
            if (value.Length > 8)
            {
                value = value.Remove(14);
                value = value.Insert(12, ":");
                value = value.Insert(10, ":");
                value = value.Insert(8, " ");
            }
            value = value.Insert(6, ".");
            value = value.Insert(4, ".");

            DateTime date = DateTime.Parse(value);
            return date;
        }
    }
}
