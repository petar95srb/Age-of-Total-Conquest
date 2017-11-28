using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgeOfTotalConquest.Models
{
    public class Message
    {
        public Guid Id { get; set; }

        [ForeignKey("User")]
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        [Required]
        public string Body { get; set; }

        public int isRead { get; set; }


        public DateTime Date{ get; set; }
        public virtual User User { get; set; }
        public virtual User Receiver { get; set; }

    }
}