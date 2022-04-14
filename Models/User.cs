﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace swen_capstone_project.Models
{
    public class User
    {
        public int Id { get; set; }
        public UserType UserType { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public DateTime Created { get; set; }

    }

    public enum UserType
    {
        Teacher,
        Student
    }
}