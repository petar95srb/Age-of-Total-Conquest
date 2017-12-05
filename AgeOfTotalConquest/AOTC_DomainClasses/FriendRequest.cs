using System;
using System.ComponentModel.DataAnnotations;

namespace AgeOfTotalConquest.AOTC_DomainClasses

{
    public class FriendRequest
    {
        [Key]
        public Guid Id { get; set; }

       
       [Required]
        public string UserId { get; set; }

        [Required]
        public string FriendId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public virtual User User { get; set; }
        public virtual User Friend { get; set; }
    }
}