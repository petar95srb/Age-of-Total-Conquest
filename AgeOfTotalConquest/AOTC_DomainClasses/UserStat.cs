using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgeOfTotalConquest.AOTC_DomainClasses
{
    public class UserStat
    {

        
        [Key, ForeignKey("User")]
        public string UsernameId { get; set; }
        public virtual User User { get; set; }

        [DefaultValue(0)]
        public int Victories { get; set; }
        [DefaultValue(0)]
        public int Losses { get; set; }
        public int Total { get { return Victories + Losses; } }
        [DefaultValue(0)]
        public int Experience { get; set; }
        public int Money { get; set; }
    }
}