using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPnet1.App_Code
{
    public class Fish:Animal,IAnimalMove //抽象類別寫前面,且只能寫一次 但可以繼承很多介面
    {
        public string Move(int m)
        {
            return "游了" + m + "公尺";
        }

    }
}