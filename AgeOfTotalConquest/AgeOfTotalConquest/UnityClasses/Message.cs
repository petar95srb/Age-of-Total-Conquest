using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeOfTotalConquest.UnityClasses
{
    public class Message
    {
        public Guid Id { get; set; }
        public String SenderId { get; set; }
        public String ReceiverId { get; set; }
        public String Content { get; set; }
    }
}