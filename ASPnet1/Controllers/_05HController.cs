using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPnet.Controllers
{
    public class _05HController : Controller
    {
        const string eng = "ABCDEFGHJKLMNPQRSTUVWXYZIO";
        // GET: _05H

        public string IDnumber(string id)
        {
            string result = "";
            if (!LengthCheck(ref id))
                Response.Write("格式有誤");
            else if (!LetterCheck(ref id))
                Response.Write("格式有誤");
            else if (!GenderCheck(ref id))
                Response.Write("格式有誤");
            else if (!NumberCheck(ref id))
                Response.Write("格式有誤");
            else if (!EChaNCheck(ref id))
                result = "此身份證字號不正確";
            else
                result = "這是合法的身分證字號";

            return result;
        }
        //符合10碼字元
        public bool LengthCheck(ref string id)
        {
            if (id.Length == 10)
                return true;

            return false;
        }
        //第一個字是否為英文字
        public bool LetterCheck(ref string id)
        {

            string w = id.Substring(0, 1);

            if (eng.Contains(w))
                return true;

            return false;

        }
        //判斷第二碼數字是否為1或2
        public bool GenderCheck(ref string id)
        {
            string gender = id.Substring(1, 1);

            if (gender == "1" || gender == "2")
                return true;

            return false;
        }
        //判斷後8碼是否為數字
        public bool NumberCheck(ref string id)
        {
            try
            {
                for (int i = 2; i < 10; i++)
                {
                    Convert.ToInt16(id.Substring(i, 1));
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        //確認英文轉成數字
        public bool EChaNCheck(ref string id)
        {
            string w = id.Substring(0, 1);
            int intEng = eng.IndexOf(w) + 10;
            int n1 = intEng / 10;
            int n2 = intEng % 10;

            int[] a = new int[9];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = Convert.ToInt16(id.Substring(i + 1, 1));
            }


            int sum = n1 + n2 * 9 + a[0] * 8 + a[1] * 7 + a[2] * 6 + a[3] * 5 + a[4] * 4 + a[5] * 3 + a[6] * 2 + a[7] + a[8];


            //int sum = 0;
            //for (int i = 0; i < 8; i++)
            //{
            //    sum += a[i] * (8 - 1);
            //}
            //sum = n1 + n2 * 9 + a[8];

            if (sum % 10 == 0)
                return true;

            return false;

        }


    }
}