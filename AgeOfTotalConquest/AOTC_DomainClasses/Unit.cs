using System.ComponentModel.DataAnnotations;

namespace AgeOfTotalConquest.AOTC_DomainClasses
{
    public class Unit
    {
        [Key]
        public string Name { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }
        public int Range { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Armour { get; set; }
        public int Speed { get; set; }


       
        
    }
}