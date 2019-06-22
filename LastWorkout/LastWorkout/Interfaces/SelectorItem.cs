using System;
using System.Collections.Generic;
using System.Text;

namespace LastWorkout.Interfaces
{
    public interface ISelectorItem
    {
         int Code { get; set; }

         string Description { get; set; }
    }
}
