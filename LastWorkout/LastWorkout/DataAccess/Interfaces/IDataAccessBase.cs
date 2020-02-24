using LastWorkout.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LastWorkout.DataAccess.Interfaces
{
    public interface IDataAccessBase<T> where T : RealmObject
    {
        void SaveNew(IEntityDataBase entityDataBase, Action<string> returnAction);
        IQueryable<T> GetAll();
    }
}
