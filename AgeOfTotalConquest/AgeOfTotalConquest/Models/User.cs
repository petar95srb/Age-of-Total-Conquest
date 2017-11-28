using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgeOfTotalConquest.Models
{
    public class User
    {
        public Guid Id { get; set; }
        //[Required, Index(IsUnique = true)]
        [Required]
        public string Email { get; set; }
        //[Required, Index(IsUnique = true)]
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public byte?[] Avatar { get; set; }

        
        public virtual UserStat UserStat { get; set; }


        public virtual ICollection<UserBoost>  UserBoosts  { get; set;}
        public virtual ICollection<UserReinforcement> UserReinforcements  { get; set; }

       // public virtual ICollection<Message> Messages { get; set; }
        //public  virtual ICollection<User> Friends { get; set; }





    }
    }
