using Microsoft.AspNet.Identity;
using SimpleChat.chatModel;
using SimpleChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleChat.Controllers
{
    public class RepliesController : Controller
    {
        private ApplicationDbContext _db;

        public RepliesController()
        {
            _db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }

        // GET: Replies
        public ActionResult Index()
        {
            var replies = _db.Replies.ToList();

            return View(replies);
        }

        public ActionResult Reply(int id)
        {
            var question = _db.Questions.SingleOrDefault(q => q.Id == id);

            if (question == null)
                return HttpNotFound();

            var viewModel = new Chat
            {
                Questions = question
            };  

            return View(viewModel);
        }

        public ActionResult ReplySave(Replies replies, int id)
        {
            replies.QuestionId = id;
            replies.ReplyDate = DateTime.Now;

            string user = User.Identity.GetUserId();
            replies.UserId = user;

            _db.Replies.Add(replies);

            _db.SaveChanges();

            var ViewAllReply = _db.Replies.Where(c => c.QuestionId == id).ToList();
            var viewSpecificQuestion = _db.Questions.Where(c => c.Id == id).ToList();

            var view = new ViewReplies
            {
                Replies = ViewAllReply,
                Questions = viewSpecificQuestion
            };

            return View(view);
        }

        public ActionResult ViewAll(int id)
        {
            var ViewAllReply = _db.Replies.Where(c => c.QuestionId == id).ToList();
            var viewSpecificQuestion = _db.Questions.Where(c => c.Id == id).ToList();

            var view = new ViewReplies
            {
                Replies = ViewAllReply,
                Questions = viewSpecificQuestion
            };

            return View(view);
        }
    }
}