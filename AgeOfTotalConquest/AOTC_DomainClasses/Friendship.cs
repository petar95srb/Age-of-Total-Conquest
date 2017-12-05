using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgeOfTotalConquest.AOTC_DomainClasses
{
    public class Friendship
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("User")]
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
