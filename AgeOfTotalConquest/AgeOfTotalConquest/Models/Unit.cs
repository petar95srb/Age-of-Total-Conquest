using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgeOfTotalConquest.Models
{
    public class Unit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }
        public int Range { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Armour { get; set; }
        public int Speed { get; set; }


        public Unit()
        {
        }
        
    }
}