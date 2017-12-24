using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeOfTotalConquest.UnityClasses
{
    public class Friendship
    {
        public Guid Id { get; set; }
        public String UserId { get; set; }
        public String FriendId { get; set; }
        public DateTime Date { get; set; }
    }
}