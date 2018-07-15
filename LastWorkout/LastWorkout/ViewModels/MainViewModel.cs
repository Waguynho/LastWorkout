using LastWorkout.ViewModels.Base;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LastWorkout.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand SettingsCommand => new Command(async () => await SettingsAsync());

        public override Task InitializeAsync(object navigationData)
        {
            IsBusy = true;

 

            return base.InitializeAsync(navigationData);
        }

        private async Task SettingsAsync()
        {
            //await NavigationService.NavigateToAsync<SettingsViewModel>();
        }
    }
}
