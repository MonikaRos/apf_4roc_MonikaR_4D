using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class UserInfo
    {
        public string Name { get; set; } = " ";
        public string Email { get; set; } = " ";
        public string Telephone { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public string Address { get; set; } = string.Empty;

        public List<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
