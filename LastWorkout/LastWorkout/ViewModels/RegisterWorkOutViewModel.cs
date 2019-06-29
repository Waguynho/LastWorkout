using LastWorkout.Interfaces;
using LastWorkout.Models;
using LastWorkout.ViewModels.Base;
using Realms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Linq;
using Xamarin.Forms;

namespace LastWorkout.ViewModels
{

    public class RegisterWorkOutViewModel : ViewModelBase
    {

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

        private DateTime workOutDate = DateTime.Now;
        public DateTime WorkOutDate
        {
            get { return workOutDate; }
            set
            {
                workOutDate = value;
                RaisePropertyChanged(() => WorkOutDate);
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
        }

        private void LoadLevels()
        {
            Realm realm = Realm.GetInstance();

            IList<Level> levelItems = realm.All<Level>().OrderBy(l => l.Code).ToList<Level>();

            Levels = levelItems.ToList<ISelectorItem>();
        }

        private async Task Save()
        {
            IsBusy = true;

            try
            {
                WorkOutDay workOutDay = new WorkOutDay();
                //workOutDay.WorkOutLevel = SelectedLevel.Code;
                workOutDay.Observasion = Observation;
                workOutDay.WorkOutDate = WorkOutDate;
                workOutDay.Id = WorkOutDate.Ticks;
                workOutDay.Level = (Level)SelectedLevel;

                SaveWorkOutDay(workOutDay);
            }
            catch (System.Exception e)
            {
                await PageContext.DisplayAlert("erro", e?.Message, "cancel");
                Console.WriteLine("======== " + e.Message);
            }

            IsBusy = false;
        }

        private void SaveWorkOutDay(WorkOutDay workOutDay)
        {
            Realm realm = Realm.GetInstance();

            realm.Write(() =>
            {
                bool success = realm.Add(workOutDay).IsValid;
                if (success)
                {
                    PageContext.DisplayAlert("aviso", "Salvou!", "ok");
                }
            });
        }
    }
}
