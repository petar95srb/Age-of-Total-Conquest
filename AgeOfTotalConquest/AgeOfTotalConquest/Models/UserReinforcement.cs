using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgeOfTotalConquest.Models
{
    public class UserReinforcement
    {
        public Guid Id { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public Guid ReinforcementId { get; set; }
        public virtual Reinforcement Reinforcement { get; set; }


    }
}