using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeOfTotalConquest.Models
{
    public class Reinforcement
    {
        public Guid Id { get; set; }
        public int Price { get; set; }
        public string UnitName { get; set; }
        public int Count { get; set; }
    }
}