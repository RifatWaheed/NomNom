using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NomNomScratch.Models;

namespace NomNomScratch.Controllers
{
    [RoutePrefix("AdminLogins")]
    public class AdminLoginsController : Controller
    {
        private NomNomEntities1 db = new NomNomEntities1();
        
        HomeController data = new HomeController();

        private String urlHome = string.Format("https://localhost:44398/");


        [HttpGet]
        public ActionResult MainPage()
        {
            return View();
        }



        [HttpGet]
        public ActionResult SignUp()
        {

            if (Session["UserEmail"] != null)
                return RedirectToAction("MainPage");
            else
            {
                return View();
            }
        }

        [Route("Login")]
        [HttpPost]
        public ActionResult SignUp(UserRegister user)
        {
           if(ModelState.IsValid)

            {
                Session["UserEmail"] = user.Email;
                db.UserRegisters.Add(user);
                db.SaveChanges();

           }

            return Redirect(urlHome);
        }
        public ActionResult LogOutAdmin()
        {

            Session["AdminEmail"] = null;
            return Redirect(urlHome);
        }

        public ActionResult LogOutUser()
        {

            Session["UserEmail"] = null;
            return Redirect(urlHome);
        }

        public ActionResult LogOutStaff()
        {

            Session["StaffEmail"] = null;
            return Redirect(urlHome);
        }


        //Login


        [HttpGet]
        [Route("Login")]
        public ActionResult Login()
        {
            if(Session["AdminEmail"] !=null)
                return RedirectToAction("MainPage");
            else
            return View();
        }

        [HttpPost]
        public ActionResult Login(TempLogin TempLogin1)
        {

            Console.WriteLine("Yahoo");
        
                var login = db.AdminLogins.Where(u => u.Email.Equals(TempLogin1.Email) && u.Password.Equals(TempLogin1.Password)).FirstOrDefault();

                if (login != null)
                {
                Session["AdminEmail"] = TempLogin1.Email;
                TempData["AdminLogin"] = login.Name;
                return RedirectToAction("dashboard","BookFood");

                }

                else
                {
                    ViewBag.LoginFailed = "Incorrect Email or Password";
                    return View();
                }
        }



        [HttpGet]
        [Route("Login")]
        public ActionResult StaffLogin()
        {
            if (Session["StaffEmail"] != null)
                return RedirectToAction("MainPage");
            else
                return View();
        }

        [HttpPost]
        public ActionResult StaffLogin(Staff log)
        {

            Console.WriteLine("Yahoo");

            var login = db.Staffs.Where(u => u.Email.Equals(log.Email) && u.Password.Equals(log.Password)).FirstOrDefault();

            if (login != null)
            {
                Session["StaffEmail"] = login.Email;
                TempData["StaffLogin"] = login.Name;
                return RedirectToAction("Staffdashboard", "BookFood");

            }

            else
            {
                ViewBag.LoginFailed = "Incorrect Email or Password";
                return View();
            }
        }




        [HttpGet]
        public ActionResult UserLogin()
        {
            if (Session["UserEmail"] != null) {
                return RedirectToAction("CustomerIndex", "Customer");
            }
            else
            {
                return View();

            }
          
        }

        [HttpPost]
        public ActionResult UserLogin(UserRegister TempLogin1)
        {

            Console.WriteLine("Yahoo");
         
            var login = db.UserRegisters.Where(u => u.Email.Equals(TempLogin1.Email) && u.Password.Equals(TempLogin1.Password)).FirstOrDefault();

            if (login != null)
            {
                Session["UserEmail"] = TempLogin1.Email;
                return RedirectToAction("CustomerIndex", "Customer");

            }

            else
            {
                ViewBag.LoginFailed = "Incorrect Email or Password";
                return View();
            }
        }








        // GET: AdminLogins
        public ActionResult Index()
        {
            return View(db.AdminLogins.ToList());
        }


        public ActionResult Appetizer()
        {
            return View(db.Appetizers.ToList());
        }

      

        public ActionResult VoucherList()
        {
            return View(db.VoucherLists.ToList());
        }

        // GET: AdminLogins/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogin adminLogin = db.AdminLogins.Find(id);
            if (adminLogin == null)
            {
                return HttpNotFound();
            }
            return View(adminLogin);
        }

        // GET: AdminLogins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminLogins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdminId,Email,Password")] AdminLogin adminLogin)
        {
            if (ModelState.IsValid)
            {
                db.AdminLogins.Add(adminLogin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminLogin);
        }

        // GET: AdminLogins/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogin adminLogin = db.AdminLogins.Find(id);
            if (adminLogin == null)
            {
                return HttpNotFound();
            }
            return View(adminLogin);
        }


       


        // POST: AdminLogins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdminId,Email,Password")] AdminLogin adminLogin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminLogin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminLogin);
        }

        // GET: AdminLogins/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogin adminLogin = db.AdminLogins.Find(id);
            if (adminLogin == null)
            {
                return HttpNotFound();
            }
            return View(adminLogin);
        }

        // POST: AdminLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AdminLogin adminLogin = db.AdminLogins.Find(id);
            db.AdminLogins.Remove(adminLogin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
