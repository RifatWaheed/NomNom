using NomNomScratch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNomScratch.Controllers



{

    public class BookFoodController : Controller
    {
        private NomNomEntities1 db = new NomNomEntities1();
        // GET: BookFood

        public ActionResult dashboard(int? id, int? info)
        {
            if (id != null)
            {

                db.Orders.FirstOrDefault(x => x.OrderId == (int)info).Assign = (int)id;
                db.SaveChanges();
            }

            List<makeOrder> data = new List<makeOrder>();
            foreach (var item in db.Orders.ToList())
            {

                makeOrder mylist = new makeOrder();
                mylist.Input(item.OrderId, item.Info, item.UserID, item.Date.ToString(), item.CookID, item.DeliverymanID, item.Assign);

                data.Add(mylist);
            }

            data.Sort(
             delegate (makeOrder p1, makeOrder p2)
            {
                return p1.OrderID.CompareTo(p2.OrderID);
             }
            );

            return View(data);
        }

        public ActionResult Staffdashboard(int? id, int? info)
        {
            if (id != null)
            {

                db.Orders.FirstOrDefault(x => x.OrderId == (int)info).Assign = (int)id;
                db.SaveChanges();
            }

            List<makeOrder> data = new List<makeOrder>();
            foreach (var item in db.Orders.ToList())
            {

                makeOrder mylist = new makeOrder();
                if (item.Assign == 1)
                {
                    mylist.Input(item.OrderId, item.Info, item.UserID, item.Date.ToString(), item.CookID, item.DeliverymanID, item.Assign);
                    data.Add(mylist);
                }
            }
            data.Sort(
           delegate (makeOrder p1, makeOrder p2)
           {
               return p1.OrderID.CompareTo(p2.OrderID);
           }
          );
            return View(data);
        }





        public ActionResult BookFoodFirstPage()
        {
            return View();
        }

        public ActionResult AppetizerShow()
        {
            return View(db.Appetizers.ToList());
        }

        public ActionResult MainCourseShow()
        {
            return View(db.MainCourses.ToList());
        }

        public ActionResult DessertShow()
        {
            return View(db.Desserts.ToList());
        }


        public ActionResult BeverageShow()
        {
            return View(db.Beverages.ToList());
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AppetizerEdit(int id)
        {



            Appetizer AppetizerName = db.Appetizers.First(x => x.AppID == id);

            AppetizerName.AppID = id;
            ViewBag.Name = AppetizerName.Name;
            ViewBag.Price = AppetizerName.Price;

            return View(AppetizerName);
        }



        [HttpPost]

        public ActionResult AppetizerEdit(Appetizer apptzr)
        {



            Appetizer AppetizerName = db.Appetizers.First(x => x.AppID == apptzr.AppID);

            AppetizerName.Name = apptzr.Name;
            AppetizerName.Price = apptzr.Price;



            db.SaveChanges();

            return RedirectToAction("AppetizerShow");
        }







        public ActionResult AppetizerDelete(int id)
        {



            db.Appetizers.Remove(db.Appetizers.Single(x => x.AppID == id));
            db.SaveChanges();



            return RedirectToAction("AppetizerShow");
        }






        [HttpGet]
        public ActionResult AppetizerAdd()
        {

            return View();

        }




        [HttpPost]


        public ActionResult AppetizerAdd(Appetizer apptzr)
        {


            if (ModelState.IsValid)

            {

                db.Appetizers.Add(apptzr);
                db.SaveChanges();

            }

            return RedirectToAction("AppetizerShow");




        }













        [HttpGet]
        public ActionResult BeverageEdit(int id)
        {



            Beverage BeverageName = db.Beverages.First(x => x.BevID == id);

            BeverageName.BevID = id;
            ViewBag.Name = BeverageName.Name;
            ViewBag.Price = BeverageName.Price;

            return View(BeverageName);
        }



        [HttpPost]

        public ActionResult BeverageEdit(Beverage bvrg)
        {



            Beverage BeverageName = db.Beverages.First(x => x.BevID == bvrg.BevID);

            BeverageName.Name = bvrg.Name;
            BeverageName.Price = bvrg.Price;



            db.SaveChanges();

            return RedirectToAction("BeverageShow");
        }





        public ActionResult BeverageDelete(int id)
        {



            db.Beverages.Remove(db.Beverages.Single(x => x.BevID == id));
            db.SaveChanges();



            return RedirectToAction("BeverageShow");
        }









        [HttpGet]
        public ActionResult BeverageAdd()
        {

            return View();

        }




        [HttpPost]


        public ActionResult BeverageAdd(Beverage bvrg)
        {


            if (ModelState.IsValid)

            {

                db.Beverages.Add(bvrg);
                db.SaveChanges();

            }



            return RedirectToAction("BeverageShow");




        }







        [HttpGet]
        public ActionResult MainCourseEdit(int id)
        {



            MainCourse MainCourseName = db.MainCourses.First(x => x.MfID == id);

            MainCourseName.MfID = id;
            ViewBag.Name = MainCourseName.Name;
            ViewBag.Price = MainCourseName.Price;

            return View(MainCourseName);
        }



        [HttpPost]

        public ActionResult MainCourseEdit(MainCourse maincrs)
        {



            MainCourse MainCourseName = db.MainCourses.First(x => x.MfID == maincrs.MfID);

            MainCourseName.Name = maincrs.Name;
            MainCourseName.Price = maincrs.Price;



            db.SaveChanges();

            return RedirectToAction("MainCourseShow");
        }







        public ActionResult MainCourseDelete(int id)
        {



            db.MainCourses.Remove(db.MainCourses.Single(x => x.MfID == id));
            db.SaveChanges();



            return RedirectToAction("MainCourseShow");
        }





        [HttpGet]
        public ActionResult MainCourseAdd()
        {

            return View();

        }




        [HttpPost]


        public ActionResult MainCourseAdd(MainCourse maincrs)
        {


            if (ModelState.IsValid)

            {

                db.MainCourses.Add(maincrs);
                db.SaveChanges();

            }

            return RedirectToAction("MainCourseShow");




        }




        [HttpGet]
        public ActionResult DessertEdit(int id)
        {



            Dessert DessertName = db.Desserts.First(x => x.DesID == id);

            DessertName.DesID = id;
            ViewBag.Name = DessertName.Name;
            ViewBag.Price = DessertName.Price;

            return View(DessertName);
        }



        [HttpPost]

        public ActionResult DessertEdit(Dessert dsrt)
        {



            Dessert DessertName = db.Desserts.First(x => x.DesID == dsrt.DesID);

            DessertName.Name = dsrt.Name;
            DessertName.Price = dsrt.Price;



            db.SaveChanges();

            return RedirectToAction("DessertShow");
        }



        public ActionResult DessertDelete(int id)
        {



            db.Desserts.Remove(db.Desserts.Single(x => x.DesID == id));
            db.SaveChanges();



            return RedirectToAction("DessertShow");
        }




        [HttpGet]
        public ActionResult DessertAdd()
        {

            return View();

        }




        [HttpPost]


        public ActionResult DessertAdd(Dessert dsrt)
        {


            if (ModelState.IsValid)

            {

                db.Desserts.Add(dsrt);
                db.SaveChanges();

            }

            return RedirectToAction("DessertShow");




        }











    }
}