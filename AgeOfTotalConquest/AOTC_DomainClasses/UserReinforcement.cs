using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgeOfTotalConquest.AOTC_DomainClasses
{
    public class UserReinforcement
    {
        public Guid Id { get; set; }

        [ForeignKey("User")]
        public string Username { get; set; }
        public virtual User User { get; set; }
        
        public int  ReinforcementId { get; set; }
        public virtual Reinforcement Reinforcement { get; set; }


    }
}