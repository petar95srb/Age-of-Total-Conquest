using AgeOfTotalConquest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgeOfTotalConquest.Controllers
{
    public class HomeController : Controller
    {
        AgeOfTotalConquestDB db = new AgeOfTotalConquestDB();
        public ActionResult Index()
        {
            User u = new User
            {
                Username = "a",
                Email = "a",
                Password = "a",
            };
            u.UserStat = new UserStat { Victories = 0, Losses = 0 };
           
            Reinforcement r = new Reinforcement { UnitName = "pojacanje" };
            UserReinforcement ur = new UserReinforcement { Reinforcement = r, User = u };
            Boost b = new Boost { Name = "powerUp" };
            UserBoost ub = new UserBoost { User = u, Boost = b };
            User u2 = new User { Username = "b", Password = "b", Email = "b" };
            Friendship f = new Friendship { User = u, Friend = u2 };
            Message m = new Message { User = u, Receiver = u2 };
            FriendRequest fr = new FriendRequest { User = u, Friend = u2 };

            db.Users.AddOrUpdate(u);
            db.Users.AddOrUpdate(u2);
            //db.Messages.AddOrUpdate(m);
           // db.Friendships.AddOrUpdate(f);
            db.Reinforcements.AddOrUpdate(r);
            db.Boosts.AddOrUpdate(b);
             db.UserBoosts.AddOrUpdate(ub);
            //db.UserReinforcements.AddOrUpdate(ur);

            db.SaveChanges();
           
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
        protected override void Dispose(bool disposing)
        {
            if (db != null)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}