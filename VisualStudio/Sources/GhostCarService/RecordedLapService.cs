using Elreg.RaceOptionsService;

namespace Elreg.GhostCarService
{
    public class RecordedLapService : ServiceBase<RecordedLapData> 
    {
        private readonly string _fileNameWithPath;

        public RecordedLapService(string fileNameWithPath)
        {
            _fileNameWithPath = fileNameWithPath;
        }

        public RecordedLapData RecordedLapData
        {
            get { return Object; }
        }

        protected override string Filename
        {
            get { return System.IO.Path.GetFileName(_fileNameWithPath); }
        }

        protected override string Path
        {
            get { return System.IO.Path.GetDirectoryName(_fileNameWithPath) + "\\"; }
        }

    }
}
