using LastWorkout.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LastWorkout.ViewModels
{
    public class RegisterWorkOutViewModel: ViewModelBase
    {
       

        private ICommand homeCommand;
        public ICommand HomeCommand
        {
            get { return homeCommand; }
            set
            {
                homeCommand = value;
                RaisePropertyChanged(() => HomeCommand);
            }
        }

        public RegisterWorkOutViewModel()
        {
            HomeCommand = HomeCommand == null ? HomeCommand = new Command(async () => await GoHome()) :  HomeCommand;
            
        }

        private async Task GoHome()
        {
            IsBusy = true;

            try
            {
                await NavigationService.NavigateToAsync<StartCenterViewModel>();
            }
            catch (System.Exception e)
            {
                Console.WriteLine("======== " + e.Message);
            }

            IsBusy = false;
        }
    }
}
