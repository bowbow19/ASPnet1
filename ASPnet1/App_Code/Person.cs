using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPnet1.App_Code
{
    public class Person
    {
        //fidld
         string name;
         int age;
         bool gender;
         decimal height;
         decimal weight;

        //建構子//名稱一定是類別 沒有回傳值
        public Person() 
        {
            name = "第一名";
        }

        public Person(string Name,int Age)
        {
            name = Name;
            age = Age;
        }

        public Person(string Name, int Age, bool Gender)
        {
            name = Name;
            age = Age;
            gender = Gender;
        }

        public Person(string Name, int Age, bool Gender, decimal b,decimal w)
        {
            name = Name;
            age = Age;
            gender = Gender;
            height = b;
            weight = w;
        }
        public Person(string Name, decimal b, decimal w)
        {
            name = Name;
            height = b;
            weight = w;
        }

        //屬性(Attribute)

        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(name))
                    name = "第一名";

                return name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    name = value;
            }

        }
        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                if (value < 0)
                    age = 0;
                else
                    age = value;
            }
        }
        public bool Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }
        public decimal Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value < 0)
                    weight = 1;
                else
                    weight = value;
            }
        }
        public decimal Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value < 0)
                    height = 1;
                else
                    height = value;

            }
        }

        //方法

        public string Speak()
        {
            return "我的名字叫" + name;

        }

        //打三個斜線會自動載入以下文字,可提示傳入參數說明

        /// <summary>
        /// 請傳入要說的話
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string Speak(string content)
        {
            return name + "說:" + content;
        }
        public string Speak(int n )
        {
            return name + "說我現在:" + n+"年級";
        }

        public string Jump()
        {
            return name + "嚇一跳";
        }

        public string Jump(int m)
        {
            return name + "嚇了" + m + "公尺高";
        }
        public string Jump(int b,int c)
        {
            return name + "嚇了" + b + "公尺高"+c+"公尺遠";
        }



        public string Walk(int m)
        {
            return name + "走了幾"+ m +"步";
        }

    }
}