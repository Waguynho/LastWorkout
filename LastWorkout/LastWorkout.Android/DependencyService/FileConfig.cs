using LastWorkout.Droid.DependencyService;
using LastWorkout.Interfaces.Hardware;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileConfig))]
namespace LastWorkout.Droid.DependencyService
{
    class FileConfig : IFileConfig
    {
        public string GetPlublicStorage()
        {
            string externalStorage = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
          
            return externalStorage+"/";
        }
    }
}