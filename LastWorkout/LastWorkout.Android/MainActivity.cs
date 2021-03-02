using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace LastWorkout.Droid
{
    [Activity(Label = "Last Workout", Icon = "@mipmap/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            this.bundle = bundle;
            this.context = this;

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        private Context context { get; set; }
        private Bundle bundle { get; set; }

    }
}

