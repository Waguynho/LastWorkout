using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LastWorkout.DataAccess.Interfaces;
using LastWorkout.Facades;
using LastWorkout.Models;
using Realms;

namespace LastWorkout.DataAccess
{
    public abstract class DataAccessBase<T> where T : RealmObject
    {
        private static Realm realm;

        protected DataAccessBase()
        {
            if (realm == null)
            {
                realm = Realm.GetInstance(ConfigDataBaseFacade.GetConfigurationBase());
            }
        }

        public virtual void SaveNew(IEntityDataBase entityDataBase, Action<string> returnAction)
        {
            try
            {
                int lastId = realm.All<T>().Count();
                entityDataBase.Id = (entityDataBase.Id == 0) ? lastId + 1 : entityDataBase.Id;
                realm.Write(() =>                {

                    realm.Add((RealmObject)entityDataBase, true);
                });
                System.Diagnostics.Debug.WriteLine("======= ID ==> {0}", entityDataBase.Id);
                returnAction?.Invoke(string.Empty);
            }
            catch (Exception e)
            {
                returnAction?.Invoke(e.Message);
            }
        }

        public virtual IQueryable<T> GetAll()
        {
            try
            {
                return realm.All<T>();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Print(e.Message);
                System.Diagnostics.Debug.WriteLine(e.Message);
                return null;
            }
        }
    }
}
