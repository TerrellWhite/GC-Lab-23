using GCLab_23.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCLab_23.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Register(string email)
        {
            gccoffeeshopEntities ORM = new gccoffeeshopEntities(); //need this is every operation that takes in information
            User UsertoEdit = ORM.Users.Find(email);
            if (UsertoEdit == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.UserToEdit = UsertoEdit;
            //ToDo : validation

            return View();
        }
        public ActionResult SaveChanges(User newUser)
        {
            gccoffeeshopEntities ORM = new gccoffeeshopEntities();
            ORM.Users.Add(newUser);
            ORM.SaveChanges();
            return RedirectToActionPermanent("Products");

        }
        public ActionResult Products()
        {
            gccoffeeshopEntities ORM = new gccoffeeshopEntities();
            ViewBag.Items = ORM.items.ToList();

            return View();
        }
    }
}