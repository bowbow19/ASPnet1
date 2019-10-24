using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _06ViewModel.Models;
using _06ViewModel.ViewModels;


namespace _06ViewModel.Controllers
{
    public class VMHomeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();

        // GET: VMHome
        public ActionResult Index(int jobTitle = 1)
        {
            ViewBag.JobTitle = db.職稱.Where(m => m.職稱代碼 == jobTitle).FirstOrDefault().職稱1;
            ViewBag.jobTitleID =jobTitle;

            EmpTitle et = new EmpTitle()
            {
                Employee = db.員工.Where(m => m.職稱1 == jobTitle).ToList(),
                JobTitle = db.職稱.ToList()
            };

            return View(et);
        }
        public ActionResult Create(int? jobTitle)
        {
            if (jobTitle == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.jobTitleID = jobTitle;
            return View();
        }
        [HttpPost]
        public ActionResult Create(員工 員工, int jobTitle)
        {
            員工.職稱1 = jobTitle;
            db.員工.Add(員工);
            db.SaveChanges();
            return RedirectToAction("Index", jobTitle);
        }
        public ActionResult Details(int? id, int jobTitle)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.jobTitle = db.職稱.Where(m => m.職稱代碼 == jobTitle).FirstOrDefault().職稱1;
            ViewBag.jobTitleID = jobTitle;

            EmpTitle et = new EmpTitle()
            {
                Employee = db.員工.Where(m => m.員工編號 == id).ToList(),
                JobTitle = db.職稱.Where(m => m.職稱代碼 == jobTitle).ToList()
            };


            return View(et);
        }



        public ActionResult Delete(int? id, int jobTitle)
        {


            var emp = db.員工.Where(m => m.員工編號 == id).FirstOrDefault();
            db.員工.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index", new { jobTitle = jobTitle });
        }
    }
}