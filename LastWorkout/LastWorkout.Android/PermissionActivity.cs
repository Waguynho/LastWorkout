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
                if (PackageManager.CheckPermission(Manifest.Permission.ReadExternalStorage, PackageName) != Permission.Granted
                    && PackageManager.CheckPermission(Manifest.Permission.WriteExternalStorage, PackageName) != Permission.Granted)
                {
                    var permissions = new string[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage };
                    RequestPermissions(permissions, 1);
                }
                else
                {
                    ComeBack();
                }
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            ComeBack();
        }

        private void ComeBack()
        {
            Intent returnIntent = new Intent();
            SetResult(Result.Ok);
            Finish();
        }
    }
}
