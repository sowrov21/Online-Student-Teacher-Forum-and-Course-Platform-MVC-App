using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStudentTeacherCollabAppp.Models;
using OnlineStudentTeacherCollabAppp.Models.ViewModel;

namespace OnlineStudentTeacherCollabAppp.Controllers.Admin
{
   /* [Authorize]*/
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
                return RedirectToAction("PopulatePostTable");
            }
            CategoryPostVM combodata = new CategoryPostVM();

            combodata.Categories = context.Categories.ToList();
            Post p1 = new Post();
            combodata.Post = p1;
            return View(combodata);
        }

        public ActionResult PopulatePostTable ()
        {
            CategoryPostVM combodata = new CategoryPostVM();
            combodata.PostsList = context.Posts.ToList();
            combodata.Categories = context.Categories.ToList();
            combodata.UsersList = context.Users.ToList();

            return View(combodata);
        }

        public ActionResult Edit(int id)
        {
            CategoryPostVM combodata = new CategoryPostVM();
            var post = context.Posts.FirstOrDefault(x => x.Id == id);
            combodata.Categories = context.Categories.ToList();
            combodata.Post = post;
            return View(combodata);
        }

        [HttpPost]
        public ActionResult Edit(Post p)
        {
            if(ModelState.IsValid)
            {
                var old_post = context.Posts.FirstOrDefault(x => x.Id == p.Id);

                context.Entry(old_post).CurrentValues.SetValues(p);
                context.SaveChanges();
                return RedirectToAction("PopulatePostTable");
            }
            CategoryPostVM combodata = new CategoryPostVM();

            combodata.Categories = context.Categories.ToList();
            combodata.Post = p;
            return View(combodata);

        }

        public ActionResult Details(int id)
        {
            var post = context.Posts.FirstOrDefault(x => x.Id == id);
            CategoryPostVM combodata = new CategoryPostVM();

            combodata.Categories = context.Categories.ToList();
            combodata.UsersList = context.Users.ToList();
            combodata.Post = post;
            return View(combodata);
        }

        public ActionResult Hide(int id)
        {
            var post = context.Posts.FirstOrDefault(x => x.Id == id);
            post.Status = "Unpublished";
            context.SaveChanges();
            return RedirectToAction("PopulatePostTable");
        }

        public ActionResult Show(int id)
        {
            var post = context.Posts.FirstOrDefault(x => x.Id == id);
            post.Status = "Published";
            context.SaveChanges();
            return RedirectToAction("PopulatePostTable");
        }


        public ActionResult Delete(int id)
        {
            var post = context.Posts.FirstOrDefault(x => x.Id == id);

            context.Posts.Remove(post);
            context.SaveChanges();
            return RedirectToAction("PopulatePostTable");
        }

    }
}