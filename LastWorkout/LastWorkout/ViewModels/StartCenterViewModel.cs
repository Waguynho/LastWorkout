using LastWorkout.ViewModels.Base;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Reflection;
using LastWorkout.Localization;

namespace LastWorkout.ViewModels
{
    public  class StartCenterViewModel : ViewModelBase
    {
        public StartCenterViewModel()
        {
            SetImageLegPress();

            SetTitle();

            SetWorkoutHistoryName();

            SetRegisterName();
        }

        private void SetTitle()
        {
            Title = Lang.welcome;
        }

        private void SetImageLegPress()
        {
            LegPressImage = "legpress.png";
        }

        public ICommand NextPageCommand => new Command(async () => await GoWorkoutListView());

        public ICommand WorkOutsListCommand => new Command(async () => await GoWorkOutsView());

        public ICommand PanCommand => new Command( () => {
            Console.WriteLine("PAN GESTURE!");
        });

        public ICommand PinchCommand => new Command( () => {
            Console.WriteLine("PIN GESTURE!");
        });

        private string Title;
        public string title
        {
            get { return Title; }
            set
            {
                Title = value;
                RaisePropertyChanged(() => title);
            }
        }

        private string historyName;
        public string HistoryName
        {
            get { return historyName; }
            set
            {
                historyName = value;
                RaisePropertyChanged(() => HistoryName);
            }
        }

        private string registerWorkout;
        public string RegisterWorkout
        {
            get { return registerWorkout; }
            set
            {
                registerWorkout = value;
                RaisePropertyChanged(() => RegisterWorkout);
            }
        }

        private string legPressImage;
        public string LegPressImage
        {
            get { return legPressImage; }
            set
            {
                legPressImage = value;
                RaisePropertyChanged(() => LegPressImage);
            }
        }

        private void SetWorkoutHistoryName()
        {
            HistoryName = Lang.workout_list;
        }

        private void SetRegisterName()
        {
            RegisterWorkout = Lang.register_workout;
        }

        private async Task GoWorkoutListView()
        {
            IsBusy = true;

            try
            {
                await NavigationService.NavigateToAsync<RegisterWorkOutViewModel>();
            }
            catch (System.Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            IsBusy = false;
        }

        private async Task GoWorkOutsView()
        {
            try
            {
                await NavigationService.NavigateToAsync<WorkOutListViewModel>();
            }
            catch (System.Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);                
            }           
        }
    }
}
