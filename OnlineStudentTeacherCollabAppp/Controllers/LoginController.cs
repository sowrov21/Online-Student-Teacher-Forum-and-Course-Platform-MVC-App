using System;
using OnlineStudentTeacherCollabAppp.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineStudentTeacherCollabAppp.Controllers

{
    public class LoginController : Controller
    {
 
        TeacherStudentForumEntities context = new TeacherStudentForumEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User u)
        {
            if(ModelState.IsValid)
            {
                if (context.Users.Any(obj => obj.Email.Equals(u.Email) && obj.Password.Equals(u.Password)))
                {
                    //Session["username"] = u.Name.ToString();
                    
                    FormsAuthentication.SetAuthCookie(u.Name, false);

                    var user = context.Users.Where(x => x.Email == u.Email).ToList().FirstOrDefault();
                    
                    Session["CurrentUserid"] = user.Id;
                    Session["CurrentUserName"] = user.Name;

                    if (user.Type == "Admin")
                    {
                        //TempData["Message"] = "Success! matched as Admin";
                        return RedirectToAction("Index", "AdminDashboard");
                    }

                    else if (user.Type == "Student")
                    {
                        //TempData["Message"] = "Success! matched as Student";
                        return RedirectToAction("Index", "StudentDashboard");
                    }
                    else if (user.Type == "Teacher")
                    {
                        //TempData["Message"] = "Success! matched as Student";
                        return RedirectToAction("Index", "TeacherDashboard");
                    }
                    //TempData["Message"] = "Success! matched";

                }
                else
                {
                    TempData["Message"] = "Username or Password didnot matched";

                }
                return RedirectToAction("Index");

            }
            return View();

        }


        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}