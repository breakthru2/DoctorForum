using SimpleChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleChat.chatModel
{
    public class ViewReplies
    {
        public IEnumerable<Replies> Replies { get; set; }
        public IEnumerable<Questions> Questions { get; set; }
    }
}