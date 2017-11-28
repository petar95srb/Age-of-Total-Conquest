﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgeOfTotalConquest.Models
{
    public class Friendship
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("User")]
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid FriendId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public virtual User User { get; set; }
        public virtual User Friend { get; set; }
    }
}
