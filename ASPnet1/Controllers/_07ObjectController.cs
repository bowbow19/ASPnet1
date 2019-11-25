using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPnet1.App_Code;

namespace ASPnet1.Controllers
{
    public class _07ObjectController : Controller
    {
        Animal animal;
        // GET: _07Object
        public ActionResult Index()
        {
            Person Jack = new Person();

            Jack.Name = "Jack Wang";
            Jack.Age = 18;
            Jack.Gender = true;
            Jack.Height = 180.5M;
            Jack.Weight = 62;
            Jack.Speak();
            Jack.Jump();
            Jack.Walk(10);


            Person Mary = new Person();
            Mary.Age = 18;
            Mary.Gender = false;
            Mary.Height = 160;
            Mary.Weight = 49.9M;
            Mary.Speak(5);
            Mary.Jump();

            var avg = (Jack.Age + Mary.Age) / 2;


            //有做建構子 就可以用一行結束 不用像上面寫這麼多行
            Person John = new Person("John Lin", 20, true, 170, 65);



            //繼承superman的東西
            Superman Clock = new Superman();
            Clock.Walk(100);
            Clock.Fly();
            Clock.Fly(3);

            return View();
        }

        public ActionResult polymophism() 
        {
            return View();
        }



        [HttpPost]
        public ActionResult polymophism(string type) //鑄造物件的時候要先鑄造一個aminal
        {
            
            Dog dog=new Dog();
            Cat cat=new Cat();

            if (type == "d")
            {
                animal = dog;
            }
            else if (type == "c")
            {
                animal = cat;
            }

            ViewBag.Result = animal.Speak();

                return View();


        }
    }
}