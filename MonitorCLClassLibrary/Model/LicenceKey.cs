using System;

namespace MonitorCLClassLibrary.Model
{
    public class LicenceKey
    {
        public int LicenceKeyId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string Key { get; set; }
        public string UnicId { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateExp { get; set; }
        public bool Active { get; set; }
    }
}