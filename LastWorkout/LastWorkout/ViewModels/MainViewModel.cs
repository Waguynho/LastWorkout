using LastWorkout.ViewModels.Base;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LastWorkout.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        

        public override Task InitializeAsync(object navigationData)
        {
            IsBusy = true;

 

            return base.InitializeAsync(navigationData);
        }

    
    }
}
