using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using _07WebAPI.Models;

namespace _07WebAPI.Controllers
{
    public class CourseController : ApiController
    {
        List<Course> courses = new List<Course>
        {
            new Course{Id=1,Name="ASP.net MVC5",Hours=30},
            new Course{Id=1,Name="ASP.net WebForm",Hours=50},
            new Course{Id=1,Name="ASP",Hours=40},
            new Course{Id=1,Name="PHP",Hours=10},
            new Course{Id=1,Name="JavaScript",Hours=40},
            new Course{Id=1,Name="HTML5",Hours=70},
            new Course{Id=1,Name="jQuery",Hours=50},
            new Course{Id=1,Name="Android Aoo",Hours=30},
            new Course{Id=1,Name="Bootstrap",Hours=30}
        };

        public IEnumerable<Course> Get()
        {
            return courses;
        }
    }
}

