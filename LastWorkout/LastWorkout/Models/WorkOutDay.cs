﻿using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace LastWorkout.Models
{
    public class WorkOutDay: RealmObject, IEntityDataBase
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string  Observasion { get; set; }

        public DateTimeOffset  WorkOutDate { get; set; }

        public Level Level { get; set; }

        public WorkOut WorkOut { get; set; }
    }
}
