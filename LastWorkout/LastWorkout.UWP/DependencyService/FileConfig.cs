using LastWorkout.Interfaces.Hardware;
using LastWorkout.UWP.DependencyService;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileConfig))]
namespace LastWorkout.UWP.DependencyService
{
    public class FileConfig : IFileConfig
    {
        public string GetPlublicStorage()
        {
            string bbb = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            return bbb+"\\";
        }
    }
}
