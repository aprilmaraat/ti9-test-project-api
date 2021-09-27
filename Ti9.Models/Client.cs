using System;
using System.ComponentModel.DataAnnotations;

namespace Ti9.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string IpAddress { get; set; }
        public string OsVersion { get; set; }
        public string OnlineStatus { get; set; }
        public string TimeZone { get; set; }
        public string Browser { get; set; }
        public string Resolution { get; set; }
    }
}
