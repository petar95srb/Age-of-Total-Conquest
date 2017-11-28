using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgeOfTotalConquest.Models
{
    public class UserStat
    {

        
        [Key, ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        [DefaultValue(0)]
        public int Victories { get; set; }
        [DefaultValue(0)]
        public int Losses { get; set; }
        [DefaultValue(0)]
        public int Experience { get; set; }
        public int Money { get; set; }
    }
}