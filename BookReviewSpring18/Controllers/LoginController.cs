using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookReviewSpring18.Models;

namespace BookReviewSpring18.Controllers
{
    public class LoginController : Controller
    {
        BookReviewDbEntities db = new BookReviewDbEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "UserName, Password")]LoginClass1 lc)
        {
            int results = db.usp_ReviewerLogin(lc.UserName, lc.Password);
            int revkey = 0;
            Message msg = new Message();
            if(results != -1)
                
            {
                var pkey = (from r in db.Reviewers
                            where r.ReviewerUserName.Equals(lc.UserName)
                            select r.ReviewerKey).FirstOrDefault();
                revkey = (int)pkey;
                Session["reviewerkey"] = revkey;

                msg.MessageText = "Welcome, " + lc.UserName;
            }
            else
            {
                msg.MessageText = "Invalid Login";
            }
            return View("result", msg);
        }
        public ActionResult Result(Message msg)
        {
            return View(msg);
        }
    }
}