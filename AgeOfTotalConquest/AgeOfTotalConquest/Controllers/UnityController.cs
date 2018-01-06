using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgeOfTotalConquest.AOTC_DomainClasses;
using AOTC_DomainClasses;
using System.Data.Entity.Migrations;

namespace AgeOfTotalConquest.Controllers
{
    public class UnityController : Controller
    {
        AOTC_DataLayer.AgeOfTotalConquestDB db = new AOTC_DataLayer.AgeOfTotalConquestDB();
        // GET: Unity
        public JsonResult User(string id)
        {
            AOTC_DomainClasses.User u = db.Users.Find(id);

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
            AOTC_DomainClasses.Boost b = db.Boosts.Find(id);

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
            AOTC_DomainClasses.Reinforcement r = db.Reinforcements.Find(id);

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
            //POSLATE PORUKE
            IQueryable<Message> msgs = db.Messages.Where(m => m.UserId.Equals(id));
            
            

            List<UnityClasses.Message> MSGS = new List<UnityClasses.Message>();
            foreach (Message m in msgs)
            {
                UnityClasses.Message msg = new UnityClasses.Message
                {
                    SenderId = m.UserId,
                    ReceiverId = m.ReceiverId,
                    Content = m.Body

                };
                MSGS.Add(msg);
            }

            //PRIMLJENE PORUKE
            msgs = db.Messages.Where(m => m.ReceiverId.Equals(id));

            foreach (Message m in msgs)
            {
                UnityClasses.Message msg = new UnityClasses.Message
                {
                    SenderId = m.UserId,
                    ReceiverId = m.ReceiverId,
                    Content = m.Body

                };
                MSGS.Add(msg);
            }






            return Json(MSGS);


        }

        public JsonResult UserFriendships(string id)
        {
            IQueryable<Friendship> fs = db.Friendships.Where(x => x.UserId.Equals(id));
            List<UnityClasses.Friendship> FS = new List<UnityClasses.Friendship>();
            foreach (Friendship f in fs)
            {
                UnityClasses.Friendship F = new UnityClasses.Friendship
                {
                    Id = f.Id,
                    UserId = f.UserId,
                    FriendId = f.FriendId,
                    Date = f.Date
                };




                FS.Add(F);

             }

            return Json(FS);


        }
        [HttpPost]
        public JsonResult Login(AgeOfTotalConquest.UnityClasses.LoginUser user)
        {
            if (user.UserName.Length <= 0 || user.Password.Length <= 0)
                return Json("ERROR");

            var userName = db.Users.Find(user.UserName);

            if (userName == null || userName.Password != user.Password)
                return Json("Wrong Password");

            AgeOfTotalConquest.UnityClasses.ForrenKey key = AgeOfTotalConquest.UnityClasses.ForrenKey.GenerateCode(100);

            ForrenKey forrenKey = new ForrenKey { id = key.key, userName = user.UserName };
            db.ForrenKey.Add(forrenKey);

            return Json(key);
        }

        [HttpGet]
        public JsonResult LogOut(AgeOfTotalConquest.UnityClasses.ForrenKey key)
        {
            var userName = db.ForrenKey.Find(key.key);
            if (userName == null)
                return Json("Error");

            db.ForrenKey.Remove(userName);

            return Json("true");
        }
		 [HttpGet]
        public JsonResult GetUserAvatar(AgeOfTotalConquest.UnityClasses.ForrenKey key)
        {
            var userName = db.ForrenKey.Find(key.key);
            if (userName == null)
                return Json("Error");

            var av=db.Users.Find(userName.userName);
			
            return Json(av.Avatar);
        }

        public JsonResult UpdateUserStat(UnityClasses.UserStat us, string id)
        {
            var user = db.ForrenKey.Find(id);

            if (user == null)
                return Json("Error");


            User u  = db.Users.Find(us.UsernameId);
            u.UserStat.Victories = us.Win;
            u.UserStat.Losses = us.Loss;

            db.Users.AddOrUpdate(u);

            return Json(us);


        }

        public  JsonResult UserStat(string id)
        {
            UserStat us = db.UserStats.Find(id);

            UnityClasses.UserStat US = new UnityClasses.UserStat
            {
                UsernameId = us.UsernameId,
                Win = us.Victories,
                Loss = us.Losses
            };

            return Json(us);
        }


        public JsonResult NewFriendship(UnityClasses.Friendship f)
        {
            var user = db.ForrenKey.Find(f.FriendId);

            if (user == null)
                return Json("Error");

            User u1 = db.Users.Find(f.UserId);
            User u2 = db.Users.Find(f.FriendId);

            Friendship F1 = new Friendship
            {
                Id = f.Id,
                Date=DateTime.Now,
                UserId=f.UserId,
                User = u1,
                FriendId=f.FriendId,
                Friend = u2
                

            };

            Friendship F2 = new Friendship
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                UserId = f.FriendId,
                User = u2,
                FriendId = f.UserId,
                Friend = u1

            };

            db.Friendships.Add(F1);
            db.Friendships.Add(F2);


            return Json(f);


        }

        public JsonResult NewFriendRequest(UnityClasses.FriendRequest f)
        {
            var user = db.ForrenKey.Find(f.FriendId);

            if (user == null)
                return Json("Error");

            User u1 = db.Users.Find(f.UserId);
            User u2 = db.Users.Find(f.FriendId);

            FriendRequest F1 = new FriendRequest
            {
                Id = f.Id,
                Date = DateTime.Now,
                UserId = f.UserId,
                User = u1,
                FriendId = f.FriendId,
                Friend = u2


            };

      

            db.FriendRequests.Add(F1);
          


            return Json(f);

        }

        public JsonResult NewMessage(UnityClasses.Message m, string id)
        {
            var user = db.ForrenKey.Find(m.SenderId);

            if (user == null)
                return Json("Error");

            Message msg = new Message
            {
                Id = m.Id,
                ReceiverId =m.ReceiverId,
                Receiver = db.Users.Find(m.ReceiverId),
                UserId = m.SenderId,
                User = db.Users.Find(m.SenderId),
                Body = m.Content,
                Date=DateTime.Now,
                IsRead = false

            };
            db.Messages.Add(msg);
            return Json(m);
        }


        public JsonResult AddUserBoost(UnityClasses.UserBoost ub, string id)
        {
            var user = db.ForrenKey.Find(id);

            if (user == null)
                return Json("Error");

            UserBoost UB = new UserBoost
            {
                Id = ub.Id,
                BoostId = ub.BoostId,
                Boost = db.Boosts.Find(ub.BoostId),
                Username = ub.Username,
                User = db.Users.Find(ub.Username)

            };

            db.UserBoosts.Add(UB);

            return Json(ub);

        }

        public JsonResult AddUserReinforcement(UnityClasses.UserReinforcement ur , string id)
        {
            var user = db.ForrenKey.Find(id);

            if (user == null)
                return Json("Error");

            UserReinforcement UR = new UserReinforcement
            {
                Id = Guid.NewGuid(),
                ReinforcementId = ur.ReinforcementId,
                Reinforcement = db.Reinforcements.Find(ur.ReinforcementId),
                Username = ur.Username,
                User = db.Users.Find(ur.Username)
            };
            db.UserReinforcements.Add(UR);

            return Json(ur);


        }

        public JsonResult AddUserUnits(UnityClasses.UserUnit uu, string id)
        {

            var user = db.ForrenKey.Find(id);

            if (user == null)
                return Json("Error");

            UserUnits u = new UserUnits
            {
                id = uu.id,
                userName = uu.userName,
                User = db.Users.Find(uu.userName),
                Name = uu.Name,
                Unit = db.Units.Find(uu.Name)
            };

            db.UserUnits.Add(u);
            return Json(uu);
                
        }

        public JsonResult RemoveUserBoost(Guid id, string username)
        {
            var user = db.ForrenKey.Find(username);

            if (user == null)
                return Json("Error");

            UserBoost UB = db.UserBoosts.Find(id);

            db.UserBoosts.Remove(UB);

            return Json("Boost successfully removed!");



        }

        public JsonResult RemoveUserReinforcement(Guid id, string username)
        {
            var user = db.ForrenKey.Find(username);

            if (user == null)
                return Json("Error");

            UserReinforcement UB = db.UserReinforcements.Find(id);

            db.UserReinforcements.Remove(UB);

            return Json("Reinforcement successfully removed!");
        }

        public JsonResult RemoveUserUnit(int id, string username)
        {
            var user = db.ForrenKey.Find(username);

            if (user == null)
                return Json("Error");

            UserUnits UB = db.UserUnits.Find(id);
            db.UserUnits.Remove(UB);

            return Json("Unit successfully removed!");
        }

        public JsonResult RemoveUserReinforcement(string id, string username)
        {
            var user = db.ForrenKey.Find(username);

            if (user == null)
                return Json("Error");

            UserReinforcement UB = db.UserReinforcements.Find(id);

            db.UserReinforcements.Remove(UB);

            return Json("Reinforcement successfully removed!");
        }

        public JsonResult RemoveFriendRequest(Guid id, string username)
        {
            var user = db.ForrenKey.Find(username);

            if (user == null)
                return Json("Error");

            FriendRequest UB = db.FriendRequests.Find(id);

           db.FriendRequests.Remove(UB);

            return Json("Success!");
        }




        protected override void Dispose(bool disposing)
        {
            if (db != null)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}