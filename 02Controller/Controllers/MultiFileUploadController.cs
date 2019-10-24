using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02Controller.Controllers
{
    public class MultiFileUploadController : Controller
    {
        // GET: MultiFileUpload
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(HttpPostedFileBase[] photo)
        {

            string fileName = "";

            for (int i = 0; i < photo.Length; i++)
            {
                HttpPostedFileBase f = photo[i];
                if (f != null)
                {
                    if (f.ContentLength > 0)
                    {
                        // 做法一:取得上傳的檔案名稱
                        //fileName = f.FileName;
                        //fileName = Path.GetFileName(fileName);
                        //做法二:自定義檔名
                        fileName = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "").Replace("上午", "").Replace("下午", "") + (i + 1).ToString() + ".jpg";
                        // 將檔案儲存到網站的Photos資料夾下
                        f.SaveAs(Server.MapPath("~/Photos/" + fileName)); //存入Photos資料夾
                    }
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