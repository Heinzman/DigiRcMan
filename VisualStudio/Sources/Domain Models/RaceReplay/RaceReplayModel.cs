using System;
using System.Collections.Generic;
using System.IO;
using Elreg.BusinessObjects.LoggingData;
using Elreg.Logger;
using Newtonsoft.Json;

namespace Elreg.DomainModels.RaceReplay
{
    public class RaceReplayModel
    {
        private readonly string _fileName;
        private string _copiedFileName;
        private readonly string _path;
        private TextLogger _textLogger;

        public RaceReplayModel(string fileName)
        {
            _fileName = fileName;
            _path = Path.GetDirectoryName(fileName) + "\\";
        }

        public string RaceReplayTableFileName
        {
            get
            {
                string fileName = string.Empty;
                if (_textLogger != null)
                    fileName = _textLogger.TextFileName;
                return fileName;
            }
        }

        public List<RaceReplayData> RaceReplayDataList { get; private set; }

        public void ParseFile()
        {
            CopyFile();

            string allText = File.ReadAllText(_copiedFileName);
            allText = "[" + allText + "]";
            RaceReplayDataList = JsonConvert.DeserializeObject<List<RaceReplayData>>(allText);

            RemoveCopiedFile();
        }

        public void CreateRaceReplayTableFile()
        {
            _textLogger = new TextLogger(_path, "RaceReplayTableLog", 1, true, false);

            foreach (RaceReplayData raceReplayData in RaceReplayDataList)
            {
                string logText = string.Empty;
                TimeSpan timeSpan = raceReplayData.Race.RacingTime.NetTimeSpanFromStart;
                logText += timeSpan.ToString("hh\\:mm\\:ss\\.f");
                logText += "\t" + raceReplayData.EventDescription;
                _textLogger.Log(logText);
            }
            _textLogger.Flush();
            _textLogger.Stop();
        }

        private void CopyFile()
        {
            _copiedFileName = _fileName + ".temp_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            File.Copy(_fileName, _copiedFileName, true);
        }

        private void RemoveCopiedFile()
        {
            File.Delete(_copiedFileName);
        }

    }
}
