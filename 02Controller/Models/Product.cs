using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _02Controller.Models
{
    //02-3-2 在Product class中輸入下列欄位以建立Model
    public class Product
    {
        public string PId { get; set; }		// PId編號屬性
        public string PName { get; set; }	// PName品名屬性
        public int Price { get; set; }		// Price單價屬性
    }
}