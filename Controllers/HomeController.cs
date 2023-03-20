using BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigSchool.Controllers
{
    private ApplicationDbContext _DbContext;
    public HomeController()
    {
        _DbContext = new ApplicationDbContext();
    }
    public ActionResult Index()
    {
        var upcommingCourses = _DbContext.Courses
            .Include(c => c.lecturer)
            .Include(c => c.Category)
             .Where(c => c.DateTime > DateTime.Now);
        return View(upcommingCourses);
    }
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}