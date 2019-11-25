using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPnet1.App_Code
{
    public class Superman:Person    //冒號就是繼承
    {
        string style;

        public string Style
        { get { return style; } set { style = value; } }

        public string Fly()
        {
            return "I can fly height";

        }

        public string Fly(int f)
        {
            return "我飛了"+f+"公尺遠";

        }


    }
}