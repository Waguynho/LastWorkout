using LastWorkout.DataAccess.Interfaces;
using LastWorkout.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LastWorkout.DataAccess
{
    public class WorkOutDayDataAccess :  DataAccessBase<LastWorkout.Models.WorkOutDay>, IWorkOutDayDataAccess
    {
    }
}
