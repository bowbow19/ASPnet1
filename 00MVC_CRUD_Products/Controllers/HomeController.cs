//00-1-6 using _00MVC_CRUD_Products.Models;
using _00MVC_CRUD_Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _00MVC_CRUD_Products.Controllers
{
    public class HomeController : Controller
    {
        //00-1-7 使用Entity建立DB物件
        dbProductEntities db = new dbProductEntities();

        // GET: Home
        //00-2-1 在HomeController裡撰寫Index的Action
        public ActionResult Index()
        {
            var products = db.tProduct.ToList();
            return View(products);
        }
        //00-4-1 在HomeController裡撰寫GET及POST的Create Action
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string fId, string fName, decimal fPrice, HttpPostedFileBase fImg)
        {
            //處理圖檔上傳
            string fileName = "";
            if (fImg != null)
            {
                if (fImg.ContentLength > 0)
                {
                    fileName = System.IO.Path.GetFileName(fImg.FileName); //取得檔案的檔名

                    fImg.SaveAs(Server.MapPath("~/images/" + fileName));  //將檔案存到Images資料夾下

                }
            }
            //處理圖檔上傳end
            tProduct product = new tProduct();
            product.fId = fId;
            product.fName = fName;
            product.fPrice = fPrice;
            product.fImg = fileName;

            db.tProduct.Add(product);
            db.SaveChanges();

            return RedirectToAction("Index");  //導向Index的Action方法
        }

        //00-3-1 在HomeController裡撰寫Delete的Action
        public ActionResult Delete(string fId)
        {
            //依網址傳來的fId編號取得要刪除的產品記錄
            var product = db.tProduct.Where(m => m.fId == fId).FirstOrDefault();
            string fileName = product.fImg; //取得要刪除產品的圖檔
            if (fileName != "")
            {
                //刪除指定圖檔
                System.IO.File.Delete(Server.MapPath("~/images/" + fileName));
            }

            db.tProduct.Remove(product); //依編號刪除產品記錄
            db.SaveChanges(); //回存結果

            return RedirectToAction("Index");  //導向Index的Action方法
        }

        public ActionResult Edit(string fId)
        {
            var product = db.tProduct.Where(m => m.fId == fId).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(string fId, string fName, decimal fPrice, HttpPostedFileBase fImg, string oldImg)
        {
            //處理圖檔上傳
            string fileName = "";
            if (fImg != null)
            {
                if (fImg.ContentLength > 0)
                {

                    System.IO.File.Delete(Server.MapPath("~/images/" + oldImg));//刪掉暨有的圖檔
                    fileName = System.IO.Path.GetFileName(fImg.FileName); //取得檔案的檔名
                    fImg.SaveAs(Server.MapPath("~/images/" + fileName));  //將檔案存到Images資料夾下

                }
            }
            else
            {
                fileName = oldImg;
            }
            //處理圖檔上傳end
            var product = db.tProduct.Where(m => m.fId == fId).FirstOrDefault();

            product.fName = fName;
            product.fPrice = fPrice;
            product.fImg = fileName;


            db.SaveChanges();

            return RedirectToAction("Index");  //導向Index的Action方法
        }

    }
}