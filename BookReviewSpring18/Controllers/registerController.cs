using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookReviewSpring18.Models;

namespace BookReviewSpring18.Controllers
{
    
    public class RegisterController : Controller
    {
        BookReviewDbEntities db = new BookReviewDbEntities();
        // GET: register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include ="ReviewerUserName,ReviewerFirstName,ReviewerLastName" + "ReviewerEmail,ReviewPlainPassword")]Reviewer r)
        {
            Message m = new Message();
            int result = db.usp_NewReviewer(r.ReviewerUserName, r.ReviewerFirstName, r.ReviewerLastName, r.ReviewerEmail, r.ReviewPlainPassword);
            if (result != -1)
            {
                m.MessageText = "Welcome, " + r.ReviewerUserName;
            }
            else
            {
                m.MessageText = "Something went horribly, horribly wrong";
            }
            return View("Result", m);
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}