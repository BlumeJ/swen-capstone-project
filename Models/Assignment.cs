using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace swen_capstone_project.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public User? Creator { get; set; }
        public string Name { get; set; } = string.Empty;
        public string QuestionOne { get; set; } = string.Empty;
        public string QuestionTwo { get; set; } = string.Empty;
        public string QuestionThree { get; set; } = string.Empty;
        public string QuestionFour { get; set; } = string.Empty;
        public string AnswerOne { get; set; } = string.Empty;
        public string AnswerTwo { get; set; } = string.Empty;
        public string AnswerThree { get; set; } = string.Empty;
        public string AnswerFour { get; set; } = string.Empty;
        public double? Grade { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
