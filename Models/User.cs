using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace swen_capstone_project.Models
{
    public class User
    {
        public int Id { get; set; }
        public UserType UserType { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime Created { get; set; }

        public ICollection<User>? Class { get; set; }
        public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    }
    public enum UserType
    {
        Teacher,
        Student
    }
}
