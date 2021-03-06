﻿using Microsoft.AspNet.Identity;
using SimpleChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SimpleChat.ViewModel;

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

            string user = User.Identity.GetUserId();
            questions.UserId = user;

            _db.Questions.Add(questions);

            _db.SaveChanges();

            return RedirectToAction("AllQuestions");
        }

        public ActionResult AllQuestions()
        {

            var questions = _db.Questions.Include(u => u.User).ToList();
            
            return View(questions);
        }

    }
}