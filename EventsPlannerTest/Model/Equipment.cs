﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsPlannerTest.Model
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EventId { get; set; }
        //public virtual Event Event { get; set; }
    }
}
