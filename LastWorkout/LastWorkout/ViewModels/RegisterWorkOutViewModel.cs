using LastWorkout.DataAccess;
using LastWorkout.DataAccess.Interfaces;
using LastWorkout.Facades;
using LastWorkout.Interfaces;
using LastWorkout.Localization;
using LastWorkout.Models;
using LastWorkout.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LastWorkout.ViewModels
{
    public class RegisterWorkOutViewModel : ViewModelBase
    {

        int IdRecordDay;

        private IList<ISelectorItem> levels;
        public IList<ISelectorItem> Levels
        {
            get { return levels; }
            set
            {
                levels = value;
                RaisePropertyChanged(() => Levels);
            }
        }

        private IList<ISelectorItem> workOuts;
        public IList<ISelectorItem> WorkOuts
        {
            get { return workOuts; }
            set
            {
                workOuts = value;
                RaisePropertyChanged(() => WorkOuts);
            }
        }

        private ISelectorItem selectedLevel;
        public ISelectorItem SelectedLevel
        {
            get { return selectedLevel; }
            set
            {
                selectedLevel = value;
                RaisePropertyChanged(() => SelectedLevel);
            }
        }

        private ISelectorItem selectedWorkOut;
        public ISelectorItem SelectedWorkOut
        {
            get { return selectedWorkOut; }
            set
            {
                if (selectedWorkOut != value)
                {
                    selectedWorkOut = value;
                    RaisePropertyChanged(() => SelectedWorkOut);
                }
            }
        }

        private DateTime workOutDate = DateTime.Now;
        public DateTime WorkOutDate
        {
            get { return workOutDate; }
            set
            {
                if (workOutDate != value)
                {
                    workOutDate = value;
                    RaisePropertyChanged(() => WorkOutDate);
                }
            }
        }

        private string observation;
        public string Observation
        {
            get { return observation; }
            set
            {
                observation = value;
                RaisePropertyChanged(() => Observation);
            }
        }

        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get { return saveCommand; }
            set
            {
                saveCommand = value;
                RaisePropertyChanged(() => SaveCommand);
            }
        }

        public RegisterWorkOutViewModel()
        {
            SaveCommand = SaveCommand == null ? SaveCommand = new Command(async () => await Save()) : SaveCommand;

            LoadLevels();

            LoadWorkOuts();
        }

        private async void LoadLevels()
        {
            try
            {
                IList<Level> levelItems = DependencyService.Resolve<ILevelDataAccess>().GetAll().OrderBy(l => l.Code).ToList<Level>();

                Levels = levelItems.ToList<ISelectorItem>();
            }
            catch (Exception e)
            {

                await PageContext.DisplayAlert("erro", e?.Message, "cancel");
            }       
        }

        private void LoadWorkOuts()
        {
            IEnumerable<WorkOut> workOutItems = DependencyService.Resolve<IWorkOutDataAccess>().GetAll().OrderBy(l => l.Code).ToList<WorkOut>().Select(x => new WorkOut { Description = x.Description, Code = x.Code });

            WorkOuts = workOutItems.ToList<ISelectorItem>();
        }

        private async Task Save()
        {
            IsBusy = true;

            try
            {
                WorkOutDay workOutDay = new WorkOutDay();
                workOutDay.Id = (IdRecordDay > 0) ? IdRecordDay : workOutDay.Id;
                workOutDay.WorkOutDate = WorkOutDate;                
                workOutDay.Level = (Level)SelectedLevel;
                workOutDay.WorkOut = (WorkOut)SelectedWorkOut;
                workOutDay.Observasion = Observation;

                SaveWorkOutDay(workOutDay);
                IdRecordDay = workOutDay.Id;
            }
            catch (System.Exception e)
            {
                await PageContext.DisplayAlert("erro", e?.Message, "cancel");                
            }

            IsBusy = false;
        }

        private void SaveWorkOutDay(WorkOutDay workOutDay)
        {
            DependencyService.Resolve<IWorkOutDayDataAccess>().SaveNew(workOutDay, ShowReturnMenssage);
        }
    }
}
