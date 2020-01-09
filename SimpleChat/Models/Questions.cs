using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleChat.Models
{
    public class Questions
    {
        public int Id { get; set; }

        public string QuestionText { get; set; }

        public ApplicationUser User { get; set; }

        public int UserId { get; set; }

        public DateTime DateSent { get; set; }
    }
}