using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgeOfTotalConquest.Models
{
    public class FriendRequest
    {
        [Key]
        public Guid Id { get; set; }

       
       [Required]
        public Guid UserId { get; set; }

        [Required]
        public string FriendId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public virtual User User { get; set; }
        public virtual User Friend { get; set; }
    }
}