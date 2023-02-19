using NomNomScratch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNomScratch.Controllers
{
    
    public class CustomerController : Controller
    {
        private NomNomEntities1 db = new NomNomEntities1();
        // GET: Customer
        public ActionResult CustomerIndex(int? id)
        {

            if (id == null)
            {
                List<Cart> cartList = new List<Cart>();
                Session["Food"] = cartList;
                Session["Main"] = cartList;
                Session["Bev"] = cartList;
                Session["Des"] = cartList;
            }
            return View();
        }
        public ActionResult Process() {

           List<Cart>data = Session["Food"] as List<Cart>;
            string info = "";
            foreach (var item in data) {

                info = info + "FF" + item.Name;
                info = info + "QQ" + item.Quantity;
                info = info + "PP" + item.Price;
            }
            data.Clear();
            data = Session["Main"] as List<Cart>;
            foreach (var item in data)
            {

                info = info + "FF" + item.Name;
                info = info + "QQ" + item.Quantity;
                info = info + "PP" + item.Price;
            }
            data.Clear();
            data = Session["Bev"] as List<Cart>;
            foreach (var item in data)
            {

                info = info + "FF" + item.Name;
                info = info + "QQ" + item.Quantity;
                info = info + "PP" + item.Price;
            }
            data.Clear();
            data = Session["Des"] as List<Cart>;
            foreach (var item in data)
            {

                info = info + "FF" + item.Name;
                info = info + "QQ" + item.Quantity;
                info = info + "PP" + item.Price;
            }


            info = info + "EE";

             Order newOrder= new Order();

            newOrder.Info = info;
            newOrder.Date = DateTime.Now.ToString("d/M/yyyy");
            int cnt = 0;

            List<int> information = new List<int>();
            foreach (var item in db.Staffs.ToList())
            {
                if (item.Category == 1) {
                    cnt++; information.Add(item.StaffID);
                }
            }
            Random rnd = new Random();
            cnt = rnd.Next(0, cnt-1);

            newOrder.CookID = information[cnt];

            cnt = 0;
            information.Clear();
            foreach (var item in db.Staffs.ToList())
            {
                if (item.Category == 2)
                {
                    information.Add(item.StaffID);
                    cnt++;
                }
            }
            
            cnt = rnd.Next(0, cnt-1);
         
            newOrder.DeliverymanID = information[cnt];
            newOrder.Assign = null;

            string mail = Session["UserEmail"] as string;

            UserRegister gege = db.UserRegisters.FirstOrDefault(x => x.Email == mail);
;
            newOrder.UserID = gege.UserID;

            db.Orders.Add(newOrder);
            db.SaveChanges();
            Session["Food"] = null;
            Session["Main"] = null;
            Session["Bev"] = null;
            Session["Des"] = null;
            return RedirectToAction("CustomerIndex", "Customer");
        }



        //Appetizer
        public ActionResult CustomerAppetizer(int? id)
        {
           
            if (id == null)
            {
                List <Cart> cartList= new List<Cart>();
                
                cartList = Session["Food"] as List<Cart>;               
                ViewBag.FullCart = cartList;
            
                return View(db.Appetizers.ToList());
            }
            else
            {
                List<Cart> cartList = Session["Food"] as List<Cart>;

                bool Flag = false;
                    foreach (var Item in cartList)
                    {
                        if (Item.Code == id)
                        {
                            Item.Quantity++;
                            Flag = true;
                        foreach (var data in db.Appetizers.ToList())
                        {
                           if(data.AppID == Item.Code)
                            {
                                Item.Price += data.Price;
                                break;
                            }
                        }
                        break;
                        }
                    }
                    if(!Flag)
                {
                    Cart temp = new Cart();
                    temp.Code = id;
                    temp.Quantity = 1;
                    foreach (var data in db.Appetizers.ToList())
                    {
                        if (data.AppID == temp.Code)
                        {
                            temp.Price = data.Price;
                            temp.Name = data.Name;
                            break;
                        }
                    }
                    cartList.Add(temp);
                }

                Session["Food"] = cartList;
                
                ViewBag.FullCart = cartList;
                return View(db.Appetizers.ToList());
            }
            
        }





        public ActionResult CustomerAppetizerMinus(int? id)
        {
            List<Cart> cartList = Session["Food"] as List<Cart>;
            foreach (var Item in cartList)
            {
                if (Item.Code == id)
                {
                    Item.Price = Item.Price - (Item.Price / Item.Quantity);
                    Item.Quantity--;
                   
                    if(Item.Quantity == 0)
                    {
                        cartList.Remove(Item);
                    }
                    break;
                }
            }
            Session["Food"] = cartList;
            return RedirectToAction("CustomerAppetizer/null");           

        }














        //MAIN COURSE
        public ActionResult CustomerMainCourse(int? id)
        {

            if (id == null)
            {
                List<Cart> cartList = new List<Cart>();

                cartList = Session["Main"] as List<Cart>;
                ViewBag.FullCart = cartList;

                return View(db.MainCourses.ToList());
            }
            else
            {
                List<Cart> cartList = Session["Main"] as List<Cart>;

                bool Flag = false;
                foreach (var Item in cartList)
                {
                    if (Item.Code == id)
                    {
                        Item.Quantity++;
                        Flag = true;
                        foreach (var data in db.MainCourses.ToList())
                        {
                            if (data.MfID == Item.Code)
                            {
                                Item.Price += data.Price;
                                break;
                            }
                        }
                        break;
                    }
                }
                if (!Flag)
                {
                    Cart temp = new Cart();
                    temp.Code = id;
                    temp.Quantity = 1;
                    foreach (var data in db.MainCourses.ToList())
                    {
                        if (data.MfID == temp.Code)
                        {
                            temp.Price = data.Price;
                            temp.Name = data.Name;
                            break;
                        }
                    }
                    cartList.Add(temp);
                }

                Session["Main"] = cartList;

                ViewBag.FullCart = cartList;
                return View(db.MainCourses.ToList());
            }

        }



        public ActionResult CustomerMainCourseMinus(int? id)
        {
            List<Cart> cartList = Session["Main"] as List<Cart>;
            foreach (var Item in cartList)
            {
                if (Item.Code == id)
                {
                    Item.Price = Item.Price - (Item.Price / Item.Quantity);
                    Item.Quantity--;

                    if (Item.Quantity == 0)
                    {
                        cartList.Remove(Item);
                    }
                    break;
                }
            }
            Session["Main"] = cartList;
            return RedirectToAction("CustomerMainCourse/null");

        }

















        //Beverage
        public ActionResult CustomerBeverage(int? id)
        {

            if (id == null)
            {
                List<Cart> cartList = new List<Cart>();

                cartList = Session["Bev"] as List<Cart>;
                ViewBag.FullCart = cartList;

                return View(db.Beverages.ToList());
            }
            else
            {
                List<Cart> cartList = Session["Bev"] as List<Cart>;

                bool Flag = false;
                foreach (var Item in cartList)
                {
                    if (Item.Code == id)
                    {
                        Item.Quantity++;
                        Flag = true;
                        foreach (var data in db.Beverages.ToList())
                        {
                            if (data.BevID == Item.Code)
                            {
                                Item.Price += data.Price;
                                break;
                            }
                        }
                        break;
                    }
                }
                if (!Flag)
                {
                    Cart temp = new Cart();
                    temp.Code = id;
                    temp.Quantity = 1;
                    foreach (var data in db.Beverages.ToList())
                    {
                        if (data.BevID == temp.Code)
                        {
                            temp.Price = data.Price;
                            temp.Name = data.Name;
                            break;
                        }
                    }
                    cartList.Add(temp);
                }

                Session["Bev"] = cartList;

                ViewBag.FullCart = cartList;
                return View(db.Beverages.ToList());
            }

        }



        public ActionResult CustomerBeverageMinus(int? id)
        {
            List<Cart> cartList = Session["Bev"] as List<Cart>;
            foreach (var Item in cartList)
            {
                if (Item.Code == id)
                {
                    Item.Price = Item.Price - (Item.Price / Item.Quantity);
                    Item.Quantity--;

                    if (Item.Quantity == 0)
                    {
                        cartList.Remove(Item);
                    }
                    break;
                }
            }
            Session["Bev"] = cartList;
            return RedirectToAction("CustomerBeverage/null");

        }









        //Dessert
        public ActionResult CustomerDessert(int? id)
        {

            if (id == null)
            {
                List<Cart> cartList = new List<Cart>();

                cartList = Session["Des"] as List<Cart>;
                ViewBag.FullCart = cartList;

                return View(db.Desserts.ToList());
            }
            else
            {
                List<Cart> cartList = Session["Des"] as List<Cart>;

                bool Flag = false;
                foreach (var Item in cartList)
                {
                    if (Item.Code == id)
                    {
                        Item.Quantity++;
                        Flag = true;
                        foreach (var data in db.Desserts.ToList())
                        {
                            if (data.DesID == Item.Code)
                            {
                                Item.Price += data.Price;
                                break;
                            }
                        }
                        break;
                    }
                }
                if (!Flag)
                {
                    Cart temp = new Cart();
                    temp.Code = id;
                    temp.Quantity = 1;
                    foreach (var data in db.Desserts.ToList())
                    {
                        if (data.DesID == temp.Code)
                        {
                            temp.Price = data.Price;
                            temp.Name = data.Name;
                            break;
                        }
                    }
                    cartList.Add(temp);
                }

                Session["Des"] = cartList;

                ViewBag.FullCart = cartList;
                return View(db.Desserts.ToList());
            }

        }



        public ActionResult CustomerDessertMinus(int? id)
        {
            List<Cart> cartList = Session["Des"] as List<Cart>;
            foreach (var Item in cartList)
            {
                if (Item.Code == id)
                {
                    Item.Price = Item.Price - (Item.Price / Item.Quantity);
                    Item.Quantity--;

                    if (Item.Quantity == 0)
                    {
                        cartList.Remove(Item);
                    }
                    break;
                }
            }
            Session["Des"] = cartList;
            return RedirectToAction("CustomerDessert/null");

        }









    
    }
}