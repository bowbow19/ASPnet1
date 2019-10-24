using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPnet1.Models;

namespace ASPnet1.Controllers
{
    public class 訂貨明細Controller : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: 訂貨明細
        public ActionResult Index()
        {
            var 訂貨明細 = db.訂貨明細.Include(訂 => 訂.訂貨主檔).Include(訂 => 訂.產品資料);
            return View(訂貨明細.ToList());
        }

        // GET: 訂貨明細/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            訂貨明細 訂貨明細 = db.訂貨明細.Find(id);
            if (訂貨明細 == null)
            {
                return HttpNotFound();
            }
            return View(訂貨明細);
        }

        // GET: 訂貨明細/Create
        public ActionResult Create()
        {
            ViewBag.訂單號碼 = new SelectList(db.訂貨主檔, "訂單號碼", "客戶編號");
            ViewBag.產品編號 = new SelectList(db.產品資料, "產品編號", "產品");
            return View();
        }

        // POST: 訂貨明細/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "訂單號碼,產品編號,單價,數量,折扣")] 訂貨明細 訂貨明細)
        {
            if (ModelState.IsValid)
            {
                db.訂貨明細.Add(訂貨明細);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.訂單號碼 = new SelectList(db.訂貨主檔, "訂單號碼", "客戶編號", 訂貨明細.訂單號碼);
            ViewBag.產品編號 = new SelectList(db.產品資料, "產品編號", "產品", 訂貨明細.產品編號);
            return View(訂貨明細);
        }

        // GET: 訂貨明細/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            訂貨明細 訂貨明細 = db.訂貨明細.Find(id);
            if (訂貨明細 == null)
            {
                return HttpNotFound();
            }
            ViewBag.訂單號碼 = new SelectList(db.訂貨主檔, "訂單號碼", "客戶編號", 訂貨明細.訂單號碼);
            ViewBag.產品編號 = new SelectList(db.產品資料, "產品編號", "產品", 訂貨明細.產品編號);
            return View(訂貨明細);
        }

        // POST: 訂貨明細/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "訂單號碼,產品編號,單價,數量,折扣")] 訂貨明細 訂貨明細)
        {
            if (ModelState.IsValid)
            {
                db.Entry(訂貨明細).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.訂單號碼 = new SelectList(db.訂貨主檔, "訂單號碼", "客戶編號", 訂貨明細.訂單號碼);
            ViewBag.產品編號 = new SelectList(db.產品資料, "產品編號", "產品", 訂貨明細.產品編號);
            return View(訂貨明細);
        }

        // GET: 訂貨明細/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            訂貨明細 訂貨明細 = db.訂貨明細.Find(id);
            if (訂貨明細 == null)
            {
                return HttpNotFound();
            }
            return View(訂貨明細);
        }

        // POST: 訂貨明細/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            訂貨明細 訂貨明細 = db.訂貨明細.Find(id);
            db.訂貨明細.Remove(訂貨明細);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
