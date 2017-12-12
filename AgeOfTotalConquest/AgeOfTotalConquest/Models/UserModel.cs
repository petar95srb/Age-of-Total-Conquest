using AgeOfTotalConquest.AOTC_DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeOfTotalConquest.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserStat Stat { get; set; }
        public List<Unit> Units { get; set; } 
        public List<Boost>  Boosts { get; set; }
        public List<Reinforcement> Reinforcements { get; set; }
        public List<User> Friends { get; set; }
        public List<Message> Messages { get; set; }
        public List<FriendRequest> FriendRequests { get; set; }

    }
}