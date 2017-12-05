using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgeOfTotalConquest.AOTC_DomainClasses
{
    public class User
    {

        [Key]
        [Required]
        //[Required(ErrorMessage ="You must enter an username")]
        //[StringLength(20, MinimumLength = 4, ErrorMessage = "Minimalno 4 karaktera")]
        public string Username { get; set; }


        //[Required(ErrorMessage = "You must enter an email")]
        [Required]
        public string Email { get; set; }
        
       
        
        //[Required(ErrorMessage = "You must enter the password")]
        //[StringLength(maximumLength:20, MinimumLength = 4, ErrorMessage = "Password length must be beetween 4 and 20 characters")]
        public string Password { get; set; }

        public byte?[] Avatar { get; set; }

        
        public virtual UserStat UserStat { get; set; }


        public virtual ICollection<UserBoost>  UserBoosts  { get; set;}
        public virtual ICollection<UserReinforcement> UserReinforcements  { get; set; }

       // public virtual ICollection<Message> Messages { get; set; }
        //public  virtual ICollection<User> Friends { get; set; }





    }
    }
