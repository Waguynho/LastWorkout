using LastWorkout.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LastWorkout.Facades
{
    public class ConfigDataBaseFacade
    {
        private static Dictionary<int, string> Levels;


        public static void CreateBasicTables()
        {
            FillLevelsDictionary();

            CreateLevels();
        }

        private static void CreateLevels()
        {
            Realm realm = Realm.GetInstance();

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

        private static Level CreateLevel(Realm realm, int code)
        {
            Level level = new Level();
            level.Code = code;
            level.Description = Levels[code];

            realm.Add(level);
            return level;
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
    }
}
