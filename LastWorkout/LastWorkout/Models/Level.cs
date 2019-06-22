using LastWorkout.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LastWorkout.Models
{
    public class Level : ISelectorItem
    {
        public int Code { get; set; }

        public string Description { get; set; }
    }
}
