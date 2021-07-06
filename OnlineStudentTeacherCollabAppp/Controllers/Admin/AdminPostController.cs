using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStudentTeacherCollabAppp.Models;
using OnlineStudentTeacherCollabAppp.Models.ViewModel;

namespace OnlineStudentTeacherCollabAppp.Controllers.Admin
{

    public class AdminPostController : Controller

    {
        TeacherStudentForumEntities context = new TeacherStudentForumEntities();

        // GET: AdminPost
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreatePost()
        {
            CategoryPostVM combodata = new CategoryPostVM();

            combodata.Categories = context.Categories.ToList();
            Post p = new Post();
            combodata.Post = p;
            return View(combodata);
        }

        [HttpPost]
        public ActionResult CreatePost(Post p)
        {

            if(ModelState.IsValid)
            {
                context.Posts.Add(p);
                context.SaveChanges();
                return RedirectToAction("Index", "AdminDashboard");
            }
            CategoryPostVM combodata = new CategoryPostVM();

            combodata.Categories = context.Categories.ToList();
            Post p1 = new Post();
            combodata.Post = p1;
            return View(combodata);
        }

        public ActionResult PopulatePostTable ()
        {
            Post p = new Post();
            CategoryPostVM combodata = new CategoryPostVM();
            combodata.Post = p;
            combodata.Categories = context.Categories.ToList();

            return View(combodata);
        }
    }
}