using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _04EF.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string ShowArrayDesc()
        {
            int[] score = { 50, 89, 30, 100, 0, 57, 78, 87 };
            string show = "";


            //Linq查詢運算式
            //var result=from m in score
            //                    orderby m descending
            //                    select m;


            //Linq擴充方法寫法
            var result = score.OrderByDescending(m => m);


            show = "遞減排序：";
            foreach (var m in result)
            {
                show += m + ",";
            }

            show += ",";
            show += "總和:" + result.Sum();

            return show;
        }
        //04-1-5 建立一般方法ShowAryAsc()-整數陣列遞增排序
        public string ShowArrayAsc()
        {
            int[] score = { 78, 99, 20, 100, 0, 66, 95, 45 };
            string show = "";

            //Linq擴充方法寫法
            //var result = score.OrderBy(m => m);

            //Linq查詢運算式寫法
            var result = from m in score
                         orderby m ascending
                         select m;

            show = "遞增排序：";
            foreach (var m in result)
            {
                show += m + ",";
            }
            show += "<br />";
            show += "平均：" + result.Sum();

            return show;
        }

        //public string LoginMember(string uid,string pwd)
        //{
        //    Member[] members= new Member[]
        //    {
        //        new Member{Uid="tom",Pwd="123",Name="湯姆"},
        //        new Member{ Uid="jasper",Pwd="123",Name="賈斯柏"},
        //        new Member{ Uid="mary",Pwd="123",Name="馬力"}
        //    };
        //    //Linq擴充方法寫法

        //    //var result = members.Where(mbox => m.Uid == uid && m.Pwd == pwd).FirstOrDefault();

        //    //Linq查詢運算是寫法
        //    var result = (from m in members
        //                  where m.Uid == uid && m.Pwd == pwd
        //                  select m).FirstOrDefault();

        //    string show = "";
        //    if(result!=null)
        //    {
        //        show = result.Name + "歡迎進入系統!!";
        //    }
        //    else
        //    {
        //        show = "帳號或密碼錯誤!!";
        //    }
        //    return show;

        //}


    }
}