using System.Collections.Generic;
using System.Windows.Forms;

namespace Elreg.BusinessObjects
{
    public static class ServiceHelper
    {
        private const string RelConfigPathName = "Config";
        private const string RelRaceResultsPathName = "RaceResults";
        private const string RelChamionshipsPathName = "Championships";
        private const string RelConfigViewPathName = "Views";
        private const string RelConfigTextToSpeechPathName = "TextToSpeech";
        private const string RelSoundsPathName = "Sounds";
        private const string RelGhostCarPathName = "GhostCar";
        private const string RelCarsPathName = "Cars";
        private const string RelEnginePathName = "Engine";
        private const string RelDriversPathName = "Drivers";
        private const string RelBrakesPathName = "Brakes";
        private const string RelWheelSpinPathName = "WheelSpin";
        private const string RelPitstopPathName = "Pitstop";
        private const string RelRocketStartPathName = "RocketStart";
        private const string RelRocketExplosionPathName = "RocketExplosion";
        private const string RelEngineDamagePathName = "EngineDamage";
        private const string RelRocketWarningPathName = "RocketWarning";
        private const string RelPicsPathName = "Pictures";
        private const string RelLogsPathName = "Logs";
        private const string RelStatisticsPathName = "Statistics";
        private const string RelMusicPathName = "Music";
        private const string RelMainMusicPathName = "Main";
        private const string RelRaceMusicPathName = "Race";
        private const string RelPauseMusicPathName = "Pause";
        private const string RelHymnMusicPathName = "Hymns";
        private const string BackSlash = "\\";

        public static string ConfigPath
        {
            get { return BuildPath(Application.StartupPath, RelConfigPathName); }
        }

        public static string ConfigViewPath
        {
            get { return BuildPath(ConfigPath, RelConfigViewPathName); }
        } 

        public static string RaceResultsPath
        {
            get { return BuildPath(Application.StartupPath, RelRaceResultsPathName); }
        }

        public static string ChampionshipsPath
        {
            get { return BuildPath(Application.StartupPath, RelChamionshipsPathName); }
        }

        public static string SoundsPath
        {
            get { return BuildPath(Application.StartupPath, RelSoundsPathName); }
        }

        public static string RelSoundsPath
        {
            get { return BuildRelPath(RelSoundsPathName); }
        }

        public static string RelGhostCarPath
        {
            get { return BuildRelPath(RelGhostCarPathName); }
        }

        public static string MusicPath
        {
            get { return BuildPath(Application.StartupPath, RelMusicPathName); }
        }

        public static string RaceMusicPath
        {
            get { return BuildPath(Application.StartupPath, RelMusicPathName, RelRaceMusicPathName); }
        }

        public static string MainMusicPath
        {
            get { return BuildPath(Application.StartupPath, RelMusicPathName, RelMainMusicPathName); }
        }

        public static string PauseMusicPath
        {
            get { return BuildPath(Application.StartupPath, RelMusicPathName, RelPauseMusicPathName); }
        }

        public static string HymnMusicPath
        {
            get { return BuildPath(Application.StartupPath, RelMusicPathName, RelHymnMusicPathName); }
        }

        public static string CarsPath
        {
            get { return BuildPath(Application.StartupPath, RelSoundsPathName, RelCarsPathName); }
        }

        public static string RelEnginePath
        {
            get { return BuildRelPath(RelSoundsPathName, RelCarsPathName, RelEnginePathName); }
        }

        public static string DriversPath
        {
            get { return BuildPath(Application.StartupPath, RelSoundsPathName, RelDriversPathName); }
        }

        public static string BrakesPath
        {
            get { return BuildPath(CarsPath, RelBrakesPathName); }
        }

        public static string WheelSpinPath
        {
            get { return BuildPath(CarsPath, RelWheelSpinPathName); }
        }

        public static string PitstopPath
        {
            get { return BuildPath(CarsPath, RelPitstopPathName); }
        }

        public static string RocketStartPath
        {
            get { return BuildPath(CarsPath, RelRocketStartPathName); }
        }

        public static string RocketExplosionPath
        {
            get { return BuildPath(CarsPath, RelRocketExplosionPathName); }
        }

        public static string EngineDamagePath
        {
            get { return BuildPath(CarsPath, RelEngineDamagePathName); }
        }

        public static string RocketWarningPath
        {
            get { return BuildPath(CarsPath, RelRocketWarningPathName); }
        }

        public static string PicsPath
        {
            get { return BuildPath(Application.StartupPath, RelPicsPathName); }
        }

        public static string RelPicsPath
        {
            get { return BuildRelPath(RelPicsPathName); }
        }

        public static string LogsPath
        {
            get { return BuildPath(Application.StartupPath, RelLogsPathName); }
        }

        public static string ConfigTextToSpeechPath
        {
            get { return BuildPath(ConfigPath, RelConfigTextToSpeechPathName); }
        }

        public static string StatisticsPath
        {
            get { return BuildPath(Application.StartupPath, RelStatisticsPathName); }
        }

        public static string GetAbsolutePath(params string[] relativePaths)
        {
            List<string> list = new List<string> {Application.StartupPath};
            foreach (string path in relativePaths)
                list.Add(path);

            return BuildPath(list.ToArray());
        }

        private static string BuildPath(params string[] list)
        {
            string path = string.Empty;
            foreach (string t in list)
                path = path + t + BackSlash;
            return path;
        }

        private static string BuildRelPath(params string[] list)
        {
            string path = BuildPath(list);

            while (path.EndsWith(BackSlash))
                path = path.Substring(0, path.Length - BackSlash.Length);
            return path;
        }

    }
}
