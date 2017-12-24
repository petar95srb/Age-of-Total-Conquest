using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgeOfTotalConquest.AOTC_DomainClasses;

namespace AgeOfTotalConquest.Controllers
{
    public class UnityController : Controller
    {
        AOTC_DataLayer.AgeOfTotalConquestDB db = new AOTC_DataLayer.AgeOfTotalConquestDB();
        // GET: Unity
        public JsonResult User(string id)
        {
            User u = db.Users.Find(id);

            UnityClasses.UserStat stat = new UnityClasses.UserStat();
            stat.Win = u.UserStat.Victories;
            stat.Loss = u.UserStat.Losses;

            var model = Json(new UnityClasses.User
            {
                Username = u.Username,
                Email = u.Email,
                //Avatar = u.Avatar,
                // prvo da se transformise u fajl, pa da se salje kao fajl
                Stat = stat


            });

            return model;
        }

        public JsonResult Boost(int id)
        {
            Boost b = db.Boosts.Find(id);

            var model = Json(
                new UnityClasses.Boost {
                    Id = b.Id,
                    Name = b.Name,
                    Price = b.Price
                });



            return model;
        }

        public JsonResult Reinforcement(int id)
        {
            Reinforcement r = db.Reinforcements.Find(id);

            var model = Json(
                new UnityClasses.Reinforcement
                {
                    Id = r.Id,
                    UnitName = r.UnitName,
                    Count = r.Count,
                    Price = r.Price
                });

            return model;

        }

        public JsonResult Unit(string id)
        {
            Unit u = db.Units.Find(id);

            var model = Json(
                new UnityClasses.Unit
                {

                    Name = u.Name,
                    Age = u.Age,
                    Armour = u.Armour,
                    Type = u.Type,
                    Damage = u.Damage,
                    Health = u.Health,
                    Speed = u.Speed,
                    Range = u.Range

                });
            return model;
        }

        public JsonResult UnitReinforcement(string username)
        {
            IQueryable<AOTC_DomainClasses.UserReinforcement> ur = db.UserReinforcements.Where(x => x.Username.Equals(username));
            List<UnityClasses.UserReinforcement> UntUr = new List<UnityClasses.UserReinforcement>();

            foreach (AOTC_DomainClasses.UserReinforcement x in ur)
            {
                UnityClasses.UserReinforcement y = new UnityClasses.UserReinforcement
                {

                    Id = x.Id,
                    Username = x.Username,
                    ReinforcementId = x.ReinforcementId


                };
                UntUr.Add(y);
            }




            return Json(UntUr);

        }


        public JsonResult UserBoost(string username)
        {
            IQueryable<AOTC_DomainClasses.UserBoost> ub = db.UserBoosts.Where(x => x.Username.Equals(username));
            List<UnityClasses.UserBoost> UntUb = new List<UnityClasses.UserBoost>();

            foreach (AOTC_DomainClasses.UserBoost x in ub)
            {
                UnityClasses.UserBoost y = new UnityClasses.UserBoost
                {
                    Id = x.Id,
                    Username = x.Username,
                    BoostId = x.BoostId

                };

                UntUb.Add(y);
            }

            return Json(UntUb);
        }


        public JsonResult UserMessage(string id)
        {

            IQueryable<Message> msgs = db.Messages.Where(m => m.UserId.Equals(id));
            msgs.OrderBy(m => m.Date, );

            List<Message> MSGS = new List<Message>();
            foreach (Message m in msgs)
            {
                MSGS.Add(m);
            }


        }

        



        protected override void Dispose(bool disposing)
        {
            if (db != null)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}