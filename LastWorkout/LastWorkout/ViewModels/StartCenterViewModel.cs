using LastWorkout.ViewModels.Base;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LastWorkout.ViewModels
{
    public  class StartCenterViewModel : ViewModelBase
    {
        public ICommand NextPageCommand => new Command(async () => await GoHelloView());

        private async Task GoHelloView()
        {
            IsBusy = true;

            try
            {
                await NavigationService.NavigateToAsync<HelloViewModel>();
                //await NavigationService.RemoveLastFromBackStackAsync();
            }
            catch (System.Exception e)
            {

                Debug.WriteLine("======== " + e.Message);
                Console.WriteLine("======== " + e.Message);
            }

            IsBusy = false;
        }

    }
}
