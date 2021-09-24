using System;

namespace Ti9.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string IpAddress { get; set; }
        public string OsVersion { get; set; }
        public bool OnlineStatus { get; set; }
    }
}
