using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using AgeOfTotalConquest.AOTC_DomainClasses;
using AOTC_DomainClasses;

namespace AgeOfTotalConquest.AOTC_DataLayer
{
    public class AgeOfTotalConquestDB:DbContext
    {
        public DbSet<User> Users { get; set; }
        public  DbSet<Friendship> Friendships { get; set; }
        public  DbSet<Unit> Units { get; set; }
        public  DbSet<Message> Messages { get; set; }
        public DbSet<Boost> Boosts { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<Reinforcement> Reinforcements { get; set; }
        public DbSet<UserBoost> UserBoosts { get; set; }
        public DbSet<UserReinforcement> UserReinforcements { get; set; }
        public DbSet<UserStat> UserStats { get; set; }
        public DbSet<UserUnits> UserUnits { get; set; }
        public DbSet<ForrenKey> ForrenKey { get; set; }

        public AgeOfTotalConquestDB() : base()
        {
            Database.SetInitializer<AgeOfTotalConquestDB>(new CreateDatabaseIfNotExists<AgeOfTotalConquestDB>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
         
        }
    }
}