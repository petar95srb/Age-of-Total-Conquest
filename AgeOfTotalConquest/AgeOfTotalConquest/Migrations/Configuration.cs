namespace AgeOfTotalConquest.Migrations
{
    using AgeOfTotalConquest.AOTC_DomainClasses;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AgeOfTotalConquest.AOTC_DataLayer.AgeOfTotalConquestDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

           

        }

        protected override void Seed(AgeOfTotalConquest.AOTC_DataLayer.AgeOfTotalConquestDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            

                User u = new User { Username = "a", Password = "a", Email = "a" };
                u.UserStat = new UserStat();
                context.Users.AddOrUpdate(u);
                u = new User { Username = "b", Password = "b", Email = "b" };
                u.UserStat = new UserStat();
                context.Users.AddOrUpdate(u);

                Reinforcement r = new Reinforcement { Id = 1, UnitName = "macevaoci", Price = 100, Count = 5 };
                context.Reinforcements.AddOrUpdate(r);

                Boost b = new Boost { Id = 1,  Name = "ExtraExp", Price = 100 };
                context.Boosts.AddOrUpdate(b);

            UserReinforcement ur = new UserReinforcement { Id = Guid.NewGuid() };
            ur.User = u;
            ur.Reinforcement = r;
            context.UserReinforcements.AddOrUpdate(ur);


            UserBoost ub = new UserBoost { Id = Guid.NewGuid() };
            ub.User = u;
            ub.Boost = b;
            context.UserBoosts.AddOrUpdate(ub);

            FriendRequest fr = new FriendRequest { Id = Guid.NewGuid(), Date = DateTime.Now };
            fr.User = u;
            fr.UserId = u.Username;
            fr.Friend = context.Users.Find("a");
            fr.FriendId = fr.Friend.Username;
            context.FriendRequests.AddOrUpdate(fr);

            Friendship f = new Friendship { Id = Guid.NewGuid(), Date = DateTime.Now };
            
            f.User = u;
            f.UserId = u.Username;
            f.Friend = context.Users.Find("a");
            f.FriendId = f.Friend.Username;
            context.Friendships.AddOrUpdate(f);

            Message m = new Message { Id = Guid.NewGuid(), Body = "!!!This is DB test message!!!", Date = DateTime.Now };
            m.User = u;
            m.UserId = u.Username;
            m.Receiver = context.Users.Find("a");
            m.ReceiverId = m.Receiver.Username;
            context.Messages.AddOrUpdate(m);




            context.SaveChanges();


            
           

        }
    }
}
