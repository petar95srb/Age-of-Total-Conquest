﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgeOfTotalConquest.UnityClasses;
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

            UntUserStat stat = new UntUserStat();
            stat.Win = u.UserStat.Victories;
            stat.Loss = u.UserStat.Losses;

            var model = Json(new UntUser
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
                new UntBoost {
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
                new UntReinforcement
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
                new UntUnit
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
            IQueryable<UserReinforcement> ur = db.UserReinforcements.Where(x => x.Username.Equals(username));
            List<UntUserReinforcement> UntUr = new List<UntUserReinforcement>();

            foreach (UserReinforcement x in ur)
            {
                UntUserReinforcement y = new UntUserReinforcement
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
            IQueryable<UserBoost> ub = db.UserBoosts.Where(x => x.Username.Equals(username));
            List<UntUserBoost> UntUb = new List<UntUserBoost>();

            foreach (UserBoost x in ub)
            {
                UntUserBoost y = new UntUserBoost
                {
                    Id = x.Id,
                    Username = x.Username,
                    BoostId = x.BoostId

                };

                UntUb.Add(y);
            }

            return Json(UntUb);
        }

        



        protected override void Dispose(bool disposing)
        {
            if (db != null)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}