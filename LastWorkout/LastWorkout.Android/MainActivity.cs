using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace LastWorkout.Droid
{
    [Activity(Label = "LastWorkout", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
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

            Intent p = new Intent(this, typeof(PermissionActivity));

            StartActivityForResult(p, 1);
            ///
            //LoadApplication(new App());
        }

        private Context context { get; set; }
        private Bundle bundle { get; set; }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == 1)
            {
                if (resultCode == Result.Ok)
                {

                    global::Xamarin.Forms.Forms.Init(context, bundle);
                    LoadApplication(new App());


                }
                if (resultCode == Result.Canceled)
                {
                    //Write your code if there's no result
                }
            }
        }
    }
}

