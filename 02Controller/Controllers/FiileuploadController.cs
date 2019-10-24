using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02Controller.Controllers
{
    public class FiileuploadController : Controller
    {
        // GET: Fiileupload
        public ActionResult Create()
        {
            return View();
        }
        //上傳功能
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase photo)
        {

            string fileName = "";
            
            if (photo!=null)
            {
                if(photo.ContentLength>0)
                {
                    fileName = photo.FileName;
                    fileName = Path.GetFileName(fileName);

                    photo.SaveAs(Server.MapPath("~/Photos/"+fileName));
                }

            }

            return RedirectToAction("ShowPhotos");
        }

        public string ShowPhotos()
        {
            string show = "";

            DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Photos"));

            FileInfo[] fInfo = dir.GetFiles();

            foreach (FileInfo result in fInfo)
            {
                show += "<img src='../Photos/" + result.Name + "' width='90' height='60' />";
            }

            return show;
        }



    }
}