using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace _05ADOnet.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);



        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string id, string pwd)
        {
            string sql = "select * from tStudent where fEmail=@fEmail  and fStuID=@fStuID";
            SqlCommand cmd = new SqlCommand(sql, Conn);
            cmd.Parameters.AddWithValue("@fEmail", id);
            cmd.Parameters.AddWithValue("@fStuID", pwd);
            SqlDataReader rd;

            Conn.Open();
            rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                Conn.Close();
                return View("Index", "Home");
            }


            Conn.Close();
            ViewBag.LoginErr = "帳號或密碼有誤!!";
            return View();

        }
    }
}