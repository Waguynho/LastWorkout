using LastWorkout.ViewModels.Base;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Reflection;


namespace LastWorkout.ViewModels
{
    public  class StartCenterViewModel : ViewModelBase
    {
        public StartCenterViewModel()
        {
            LegPressImage = "legpress.png";
            //LegPressImage = "http://www.macoratti.net/imagens/carros/tesla1.jpg";

        }

        public ICommand NextPageCommand => new Command(async () => await GoHelloView());


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

        private async Task GoHelloView()
        {
            IsBusy = true;

            try
            {
                await NavigationService.NavigateToAsync<RegisterWorkOutViewModel>();
                //await NavigationService.NavigateToAsync<HelloViewModel>();
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
