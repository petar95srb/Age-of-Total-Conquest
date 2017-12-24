using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeOfTotalConquest.UnityClasses
{
    public class UserStat
    {
        public int Win { get; set; }
        public int Loss { get; set; }
        public int Total { get { return Win + Loss; }}

    }
}