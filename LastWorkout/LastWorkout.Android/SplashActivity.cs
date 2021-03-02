using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.App;
using Android.Util;
using System;

namespace LastWorkout.Droid
{
    [Activity(MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity, ActivityCompat.IOnRequestPermissionsResultCallback
    {
        static readonly string TAG = "X:" + typeof(SplashActivity).Name;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.SplashScreen);             
            }
            catch (Exception e)
            {

                Log.Debug(TAG, "SplashActivity.OnCreate ==> " + e.Message);
            }

        }

        protected override void OnStart()
        {
            base.OnStart();
            Log.Debug(TAG, "SplashActivity.OnStart");
            VerifyPermissions();
        }

        // Prevent the back button from canceling the startup process
        public override void OnBackPressed() { }    

        #region Permissions
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            if (requestCode == 0)
            {
                // Received permission result for camera permission.
                Log.Info(TAG, "Received response for Location permission request.");

                // Check if the only required permission has been granted
                if ((grantResults.Length == 1) && (grantResults[0] == Permission.Granted))
                {
                    // Location permission has been granted, okay to retrieve the location of the device.
                    Log.Info(TAG, "Location permission has now been granted.");
                    StartApp();
                }
                else
                {
                    Log.Info(TAG, "Location permission was NOT granted.");
                    ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.WriteExternalStorage }, 0);
                }
            }
            else
            {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }

        private void StartApp()
        {
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }

        private void VerifyPermissions()
        {
            Intent p = new Intent(this, typeof(PermissionActivity));

            StartActivityForResult(p, (int)PermissionsApp.PermissionStartup);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            string param = data.GetStringExtra("WS");
            if (requestCode == (int)PermissionsApp.PermissionStartup)
            {
                if (resultCode == Result.Ok)
                {
                    Intent MainActivity = new Intent(this, typeof(MainActivity));

                    StartActivity(MainActivity);
                }
                if (resultCode == Result.Canceled)
                {
                    //Write your code if there's no result
                }
            }
        }

        #endregion
    }
}
