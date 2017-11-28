using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgeOfTotalConquest.Models
{
    public class UserBoost
    {
        public Guid Id { get; set; }

        [Required, ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public Guid BoostId { get; set; }
        public  virtual Boost Boost { get; set; }
    }
}