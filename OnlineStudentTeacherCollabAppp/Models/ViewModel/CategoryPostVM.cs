using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStudentTeacherCollabAppp.Models.ViewModel
{
    public class CategoryPostVM
    {
        public Post Post { get; set; }

        public List<Category> Categories { get; set; }

        public List<Post> PostsList { get; set; }

        public List<User> UsersList { get; set; }

        public CategoryPostVM()
        {
            Categories = new List<Category>();
            PostsList = new List<Post>();
            UsersList = new List<User>();
        }
    }
}