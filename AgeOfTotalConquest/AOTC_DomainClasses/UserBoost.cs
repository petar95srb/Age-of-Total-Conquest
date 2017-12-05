using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgeOfTotalConquest.AOTC_DomainClasses
{
    public class UserBoost
    {
        public Guid Id { get; set; }

        [ForeignKey("User")]
        public string Username { get; set; }
        public virtual User User { get; set; }

        [Required]
        public int BoostId { get; set; }
        public virtual Boost Boost { get; set; }
    }
}