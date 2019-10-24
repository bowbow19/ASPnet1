using _03View.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03View.Controllers
{
    public class HTMLHelperController : Controller
    {
        // GET: HTMLHelper
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Member member,string ValidationCode)
        {
            if (Session["code"].ToString() == ValidationCode)
            {
                string  msg = "";
                msg = "註冊資料如下：<br>" +
                    "帳號：" + member.UserId + "<br>" +
                    "密碼：" + member.Pwd + "<br>" +
                    "姓名：" + member.Name + "<br>" +
                    "信箱：" + member.Email + "<br>" +
                    "生日：" + member.Birthday.ToShortDateString();

                ViewBag.Msg = msg;

            }
            else
            {
                ViewBag.Msg = "驗證碼錯誤!";
            }
            return View(member);
        }
        

        //圖形驗證碼
        public ActionResult getCode()
        {
             string code = GetARandomCode(6);
            Session["code"]=code;

            Bitmap img = new Bitmap(code.Length * 25, 40);
            Graphics g = Graphics.FromImage(img);

            Random r = new Random();
            int intRed = r.Next(0, 256);
            int intGreen = r.Next(0, 256);
            int intBlue = r.Next(0, 256);


            g.Clear(Color.FromArgb(1, intRed,intGreen, intBlue));

            //噪音線
            for(int i=0;i<100;i++)
            { 
            int x1 = r.Next(img.Width);
            int y1 = r.Next(img.Width);
            int x2 = r.Next(img.Width);
            int y2 = r.Next(img.Width);

            g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }

            Rectangle MyRect = new Rectangle(0, 0, img.Width, img.Height);
             intRed = r.Next(0, 256);
             intGreen = r.Next(0, 256);
             intBlue = r.Next(0, 256);

            Color color1 = Color.FromArgb( intRed, intGreen, intBlue);

            intRed = r.Next(0, 256);
            intGreen = r.Next(0, 256);
            intBlue = r.Next(0, 256);

            Color color2 = Color.FromArgb( intRed, intGreen, intBlue);
            System.Drawing.Drawing2D.LinearGradientBrush brush =
                new System.Drawing.Drawing2D.LinearGradientBrush(MyRect, color1, color2, 1.2f);

            Font font = new Font("Arial Black", 20, FontStyle.Bold);

            g.DrawString(code, font, brush, 5, 5);

            g.DrawRectangle(new Pen(Color.Silver),0,0,img.Width-1,img.Height-1);

            Image image = img;

            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            return File(ms.GetBuffer(), "image/jepg");

        }

        string GetARandomCode(int n)
        {
            string[] arrLetter = { "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S","T","W","X","Y",
                "a","b","c","d","e","f","g","h","j","k","m","n","p","r","s","t","w","x","y","0","1","2","3","4","5","6","7","8","9" };

            Random r = new Random();
            string strCode="";
           int a = 0;
            for(int i=0; i<n;i++)
            { 
                a=r.Next(0, arrLetter.Length);
                strCode += arrLetter[a];
            }

            return strCode;
        }

       

    }
}