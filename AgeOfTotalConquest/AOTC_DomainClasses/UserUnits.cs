using AgeOfTotalConquest.AOTC_DomainClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOTC_DomainClasses
{
    public class UserUnits
    {
       public int id { get; set; }

        [ForeignKey("User")]
        public string userName { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Unit")]
        public string Name { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
