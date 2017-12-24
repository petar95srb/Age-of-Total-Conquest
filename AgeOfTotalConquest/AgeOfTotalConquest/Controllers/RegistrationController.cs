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

        public ActionResult UserModel(string id)
        {
           User u = db.Users.Find(id);
            var model  = new Models.UserModel
            {
                Username = u.Username,
                Email = u.Email,
                Password = u.Password,
                Stat = u.UserStat,
                Messages = db.Messages.Where(m => m.ReceiverId.Equals(id) || m.UserId.Equals(id)).ToList(),
                Friends = db.Friendships.Where(f => f.UserId.Equals(id)).Select(f => f.Friend).ToList(),
                Boosts = db.UserBoosts.Where(ub => ub.Username.Equals(id)).Select(ub => ub.Boost).ToList(),
                Reinforcements  = db.UserReinforcements.Where(x=>x.Username.Equals(id)).Select(x=>x.Reinforcement).ToList()
                
            };

            return View(model);

        }

        public JsonResult User(string id)
        {

            User u = db.Users.Find(id);
            var model = Json(new Models.UserModel
            {
                Username = u.Username,
                Email = u.Email,
                Password = u.Password,
                Stat = u.UserStat,
                Messages = db.Messages.Where(m => m.ReceiverId.Equals(id) || m.UserId.Equals(id)).ToList(),
                Friends = db.Friendships.Where(f => f.UserId.Equals(id)).Select(f => f.Friend).ToList(),
                Boosts = db.UserBoosts.Where(ub => ub.Username.Equals(id)).Select(ub => ub.Boost).ToList(),
                Reinforcements = db.UserReinforcements.Where(x => x.Username.Equals(id)).Select(x => x.Reinforcement).ToList()

            });

         
          



            return model;

        }

        
        protected override void Dispose(bool disposing)
        {
            if (db != null)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}