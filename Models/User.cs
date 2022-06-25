using System.Collections.Generic;

namespace TestUser.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool DriverLicense { get; set; }
        public string Profession { get; set; }
        public ICollection<Session> Enrollments { get; set; }
    }
}