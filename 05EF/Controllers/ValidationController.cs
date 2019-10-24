using _05EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _05EF.Controllers
{
    public class ValidationController : Controller
    {

        dbStudentEntities db = new dbStudentEntities();

        // GET: Validation
        public ActionResult Index()
        {
            return View(db.tStudent.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tStudent stu)
        {
            if(ModelState.IsValid)
            { 
            db.tStudent.Add(stu);
            db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Delete(string id)
        {
            //var stu = from m in db.tStudent
            //          where m.fStuId == id
            //          select m;

            var stu = db.tStudent.Where(m => m.fStuId == id).FirstOrDefault();
            db.tStudent.Remove(stu);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}


