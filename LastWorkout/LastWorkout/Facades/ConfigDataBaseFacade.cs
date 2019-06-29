using LastWorkout.Interfaces.Hardware;
using LastWorkout.Models;
using LastWorkout.Statics;
using Realms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific.AppCompat;

namespace LastWorkout.Facades
{
    public class ConfigDataBaseFacade
    {
        private static Dictionary<int, string> Levels;
        private static Dictionary<int, string> WorkOuts;

        public static void CreateBasicTables()
        {
            FillLevelsDictionary();

            CreateLevels();
        }

        public static RealmConfiguration GetConfigurationBase()
        {
            string dataBasePath = string.Concat( DependencyService.Get<IFileConfig>().GetPlublicStorage() , GlobalVariables.DataBaseFolder);

            if (!Directory.Exists(dataBasePath))
            {
                Directory.CreateDirectory(dataBasePath);
            }

            string fullName = string.Concat( dataBasePath , Path.DirectorySeparatorChar, GlobalVariables.DataBaseName);

            RealmConfiguration config = new RealmConfiguration(fullName);
            config.SchemaVersion = 1;
           
            return config;
        }

        private static void CreateLevels()
        {
            Realm realm = Realm.GetInstance(GetConfigurationBase());

            using (Transaction transaction = realm.BeginWrite())
            {
                try
                {
                    foreach (int code in Levels.Keys)
                    {
                        Level level = realm.Find<Level>(code);

                        if (level == null)
                        {
                            level = CreateLevel(realm, code);
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("=== PROBLEM: {0}", ex.Message);
                    transaction.Rollback();
                }
                finally
                {
                    realm.Dispose();
                }
            }
        }

        private static void CreateWorkOuts()
        {
            Realm realm = Realm.GetInstance(GetConfigurationBase());

            using (Transaction transaction = realm.BeginWrite())
            {
                try
                {
                    foreach (int code in WorkOuts.Keys)
                    {
                        WorkOut level = realm.Find<WorkOut>(code);

                        if (level == null)
                        {
                            level = CreateWorkOut(realm, code);
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("=== PROBLEM: {0}", ex.Message);
                    transaction.Rollback();
                }
                finally
                {
                    realm.Dispose();
                }
            }
        }

        private static Level CreateLevel(Realm realm, int code)
        {
            Level level = new Level();
            level.Code = code;
            level.Description = Levels[code];

            realm.Add(level);
            return level;
        }

        private static WorkOut CreateWorkOut(Realm realm, int code)
        {
            WorkOut workOut = new WorkOut();
            workOut.Code = code;
            workOut.Description = Levels[code];

            realm.Add(workOut);
            return workOut;
        }

        private static void FillLevelsDictionary()
        {
            Levels = new Dictionary<int, string>();

            Levels.Add(0, "Frango");
            Levels.Add(1, "Fácil");
            Levels.Add(2, "Moderado");
            Levels.Add(3, "Difícil");
            Levels.Add(4, "Monstro");
        }

        private static void FillWorkOutsDictionary()
        {
            WorkOuts = new Dictionary<int, string>();

            WorkOuts.Add(0, "Descanso");
            WorkOuts.Add(1, "Peito e Tríceps");
            WorkOuts.Add(2, "Costas e Bíceps");
            WorkOuts.Add(3, "Perna e Ombro");
            WorkOuts.Add(5, "Perna");
            WorkOuts.Add(6, "Peito");
            WorkOuts.Add(7, "Costas");
            WorkOuts.Add(8, "Ombros");
            WorkOuts.Add(9, "Bícpes e Tríceps");
        }
    }
}
