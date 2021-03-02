using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;

namespace LastWorkout.Droid
{
    [Activity(Label = "PermissionActivity")]
    public class PermissionActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RequestRequiredPermissions();
        }

        private void RequestRequiredPermissions()
        {
            if ((int)Build.VERSION.SdkInt < 23)
            {
                ComeBack();
                return;
            }
            else
            {
                var read = PackageManager.CheckPermission(Manifest.Permission.ReadExternalStorage, PackageName);
                var write = PackageManager.CheckPermission(Manifest.Permission.WriteExternalStorage, PackageName);
                var call = PackageManager.CheckPermission(Manifest.Permission.CallPhone, PackageName);
                if (read != Permission.Granted && write != Permission.Granted && call != Permission.Granted)
                {
                    var permissions = new string[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage, Manifest.Permission.Internet };
                    RequestPermissions(permissions, 0);
                }
                else
                {
                    ComeBack();
                }
            }
        }

        public override  void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            if (requestCode == (int)PermissionsApp.PermissionStartup)
            {
                 ComeBack();
            }
        }

        private void ComeBack()
        {

            Intent firstIntent = new Intent(this, typeof(SplashActivity));
            firstIntent.PutExtra("WS", "Hello DATA from the Second Activity!");

            SetResult(Result.Ok, firstIntent);

            Finish();
        }
    }
}
