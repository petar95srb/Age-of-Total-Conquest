using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgeOfTotalConquest.AOTC_DomainClasses
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("User")]
        [Required]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public string ReceiverId { get; set; }
        
        public virtual User Receiver { get; set; }

        [Required]
        public string Body { get; set; }

        [DefaultValue(true)]
        public bool IsRead { get; set; }

        
        public DateTime Date{ get; set; }
      
       

    }
}