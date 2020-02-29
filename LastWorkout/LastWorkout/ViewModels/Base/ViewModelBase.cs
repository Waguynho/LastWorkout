using LastWorkout.Localization;
using LastWorkout.Services.Navigation;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LastWorkout.ViewModels.Base
{
    public abstract class ViewModelBase : ExtendedBindableObject
    {
        protected readonly INavigationService NavigationService;

        private bool _isBusy;

        public Page PageContext { get; set; }


        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        public ViewModelBase()
        {
            NavigationService = ViewModelLocator.Resolve<INavigationService>();
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(true);
        }

        protected virtual void ShowReturnMenssage(string msgError)
        {
            if (string.IsNullOrEmpty(msgError))
            {
                ShowMenssageSuccess();
            }
            else
            {
                ShowMenssageError(msgError);
            }
        }

        protected virtual void ShowMenssageError(string msgError)
        {
            PageContext.DisplayAlert(Lang.warning, msgError, "ok");
        }

        protected virtual void ShowMenssageSuccess()
        {
            PageContext.DisplayAlert("", Lang.success_save, "ok");
        }
    }
}
