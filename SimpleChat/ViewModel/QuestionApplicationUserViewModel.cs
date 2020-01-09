using SimpleChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleChat.ViewModel
{
    public class QuestionApplicationUserViewModel
    {
        public IEnumerable<Questions> Question { get; set; }
        public IEnumerable<ApplicationUser> ApplicationUser { get; set; }
    }
}