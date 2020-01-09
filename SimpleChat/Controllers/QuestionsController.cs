using SimpleChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleChat.Controllers
{
    public class QuestionsController : Controller
    {
        private ApplicationDbContext _db;

        public QuestionsController()
        {
            _db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }

        // GET: Questions
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(Questions questions)
        {
            questions.DateSent = DateTime.Now;
            _db.Questions.Add(questions);

            _db.SaveChanges();

            return RedirectToAction("AllQuestions");
        }

        public ActionResult AllQuestions()
        {
            var questions = _db.Questions.ToList();

            return View(questions);
        }

    }
}