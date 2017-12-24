using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeOfTotalConquest.UnityClasses
{
    public class UntUser
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] Avatar { get; set; }
        public UntUserStat Stat {get; set;}
    }
}