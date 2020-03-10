using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractice.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            

            if (Session["Emp_No"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Employee objUser)
        {
            if (ModelState.IsValid)
            {
                using (StudentManagementDB1Entities1 db = new StudentManagementDB1Entities1())
                {
                    var obj = db.Employees.Where(a => a.Username.Equals(objUser.Username) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["Emp_No"] = obj.Emp_No.ToString();
                        Session["Username"] = obj.Username.ToString();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(objUser);
        }

        //public ActionResult UserDashBoard()
        //{
        //    if (Session["UserID"] != null)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login");
        //    }
        //}
    }
}