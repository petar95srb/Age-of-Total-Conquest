﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgeOfTotalConquest.Models
{
    public class Boost
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }
    }
}