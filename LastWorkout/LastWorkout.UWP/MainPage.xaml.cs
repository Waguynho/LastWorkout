namespace LastWorkout.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new LastWorkout.App());
        }
    }
}
