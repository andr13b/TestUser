using System;

namespace TestUser.Models
{
    public class Session
    {
        public int SessionID { get; set; }
        public int UserID { get; set; }
        public DateTime SessionStart { get; set; }
        public DateTime SessionEnd { get; set; }
        public string SessionInfo { get; set; }
    }
}