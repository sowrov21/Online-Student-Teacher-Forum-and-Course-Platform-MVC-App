using OnlineStudentTeacherCollabAppp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace OnlineStudentTeacherCollabAppp.Controllers.Teacher
{

    public class TeacherDashboardController : Controller
    {
        // GET: TeacherDashboard
        
        TeacherStudentForumEntities dbObj = new TeacherStudentForumEntities();
        public ActionResult Index(User obj)
        {
            if(obj!= null)
            {
                return View(obj);
            }
            else
            {
                return View();

            }
            
        }

        public ActionResult Update(User obj)
        {
            if (obj != null)
            {
                return View(obj);
            }
            else
            {
                return View();

            }

        }


        [HttpPost]
        public ActionResult UpdateProfile(User model)
        {

            int CurId =Convert.ToInt32(Session["CurrentUserid"]);

            
                User obj = new User();

            if (ModelState.IsValid)
            {
                obj.Id = model.Id;
                obj.Name = model.Name;
                obj.Email = model.Email;
                obj.Type = model.Type;
                obj.Address = model.Address;
                obj.Password = model.Password;

                if(model.Id == 0)
                {
                    dbObj.Users.Add(obj);
                    dbObj.SaveChanges();

                }

                else
                {
                    dbObj.Entry(obj).State = EntityState.Modified;
                    dbObj.SaveChanges();
                }

                
            }

            ModelState.Clear();

            return View("UpdateProfile");
        }

        public ActionResult ShowProfile()
        {
            var res = dbObj.Users.ToList();
            return View(res);
        }



    }
}