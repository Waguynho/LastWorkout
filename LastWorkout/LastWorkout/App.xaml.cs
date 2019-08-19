using LastWorkout.Facades;
using LastWorkout.Localization;
using LastWorkout.Services.Navigation;
using LastWorkout.ViewModels.Base;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LastWorkout
{
    public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            Lang.Culture = new System.Globalization.CultureInfo("en-US");
            //Lang.Culture = new System.Globalization.CultureInfo("pt-BR");

            if (Device.RuntimePlatform == Device.UWP)
            {
                InitNavigation();
            }
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected override void OnStart ()
		{
            base.OnStart();

            if (Device.RuntimePlatform != Device.UWP)
            {
                 InitNavigation();
            }

            ConfigDataBaseFacade.CreateBasicTables();

            
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

    }
}
