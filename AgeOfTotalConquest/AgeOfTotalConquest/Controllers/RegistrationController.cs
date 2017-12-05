using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgeOfTotalConquest.AOTC_DataLayer;
using AgeOfTotalConquest.AOTC_DomainClasses;
using System.Data.Entity.Migrations;
namespace AgeOfTotalConquest.Controllers
{
    public class RegistrationController : Controller
    {
        AgeOfTotalConquestDB db = new AgeOfTotalConquestDB();
        // GET: Registration
        public ActionResult SignUp(string usernmame, string email, string password)
        {

            User u = new User { Username = usernmame, Email = email, Password = password };
            db.Users.AddOrUpdate(u);
            return View();
        }

        public ActionResult User(string id)
        {
           var model = db.Users.Find(id);

           return View(model);
        }

        
        protected override void Dispose(bool disposing)
        {
            if (db != null)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}