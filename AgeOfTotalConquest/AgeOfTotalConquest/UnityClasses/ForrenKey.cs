using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeOfTotalConquest.UnityClasses
{
    public class ForrenKey
    {
        public string key { get; set; }

        public static ForrenKey GenerateCode(int lenght)
        {
            ForrenKey temp=new ForrenKey();
            Random rand=new Random(Environment.TickCount);
            temp.key = "";
            for(int i=0;i<lenght;i++)
            {
                char cr = (char)rand.Next(33, 126);
                temp.key += cr;
            }




            return temp;
        }
    }
}