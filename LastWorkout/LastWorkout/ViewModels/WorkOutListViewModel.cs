using LastWorkout.Models;
using LastWorkout.ViewModels.Base;
using Realms;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LastWorkout.ViewModels
{
    public class WorkOutListViewModel : ViewModelBase
    {
        private IList<WorkOutDay> listItems;
        public IList<WorkOutDay> ListItems
        {
            get { return listItems; }
            set
            {
                listItems = value;
                RaisePropertyChanged(() => ListItems);
            }
        }

        public WorkOutListViewModel()
        {
            Realm realm = Realm.GetInstance();

            // Use LINQ to query
            var results = realm.All<WorkOutDay>().Where(d => d.Id > 0).OrderByDescending(w =>w.WorkOutDate);

            IList<WorkOutDay> list = new List<WorkOutDay> (results.Count()); // => 0 because no dogs have been added yet

            foreach (WorkOutDay item in results)
            {
                list.Add(item);
            }

            ListItems = list;

            string sdfasf = "";
          
        }
    }
}
