using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace LastWorkout.Models
{
    public class WorkOutDay: RealmObject
    {
        [PrimaryKey]
        public long Id { get; set; }

        public string  Observasion { get; set; }

        public DateTimeOffset  WorkOutDate { get; set; }

        public Level Level { get; set; }
    }
}
