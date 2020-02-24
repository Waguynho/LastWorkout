using LastWorkout.DataAccess;
using LastWorkout.DataAccess.Interfaces;
using LastWorkout.Facades;
using LastWorkout.Localization;
using LastWorkout.Models;
using LastWorkout.ViewModels.Base;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

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

        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisePropertyChanged(() => Title);
            }
        }


        public WorkOutListViewModel()
        {
            LoadWorkOutDays();

            SetTitle();
        }

        private void LoadWorkOutDays()
        {
            IQueryable<WorkOutDay> results = DependencyService.Resolve<IWorkOutDayDataAccess>().GetAll().Where(d => d.Id > 0).OrderByDescending(w => w.WorkOutDate);

            IList<WorkOutDay> list = new List<WorkOutDay>(results.Count());

            foreach (WorkOutDay item in results)
            {
                list.Add(item);
            }

            ListItems = list;
        }

        private void SetTitle()
        {
            Title = Lang.workout_list;
        }
    }
}
