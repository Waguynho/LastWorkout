using LastWorkout.Interfaces;
using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace LastWorkout.Models
{
    public class WorkOut : RealmObject, ISelectorItem
    {
        [PrimaryKey]
        public int Code { get; set; }

        public string Description { get; set; }
    }
}
