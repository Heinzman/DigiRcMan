using System;
using System.Collections.Generic;
using System.IO;
using Elreg.BusinessObjects;
using Elreg.Log;
using Elreg.Logger;

namespace Elreg.RaceConsolidationService
{
    public class RaceDataCreator
    {
        private readonly string _fileName;
        private string _copiedFileName;

        public List<RaceData> RaceDataList { get; private set; }

        public RaceDataCreator(string fileName)
        {
            _fileName = fileName;
            RaceDataList = new List<RaceData>();
        }

        public void DoWork()
        {
            try
            {
                ParseLogFile();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ParseLogFile()
        {
            CopyFile();
            using (StreamReader streamReader = new StreamReader(_copiedFileName))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                    Parse(line);
            }
            RemoveCopiedFile();
        }

        private void Parse(string line)
        {
            string[] taggedValues = line.Split(';');
            RaceData raceData = null;

            foreach (string taggedValue in taggedValues)
            {
                KeyValuePair<string, string> keyValuePair = DetermineKeyValuePair(taggedValue);
                if (keyValuePair.Key == RaceLogger.DriverTag)
                {
                    if (raceData == null)
                        raceData = new RaceData();
                    raceData.Driver = keyValuePair.Value;
                }
                else if (keyValuePair.Key == RaceLogger.EventIdTag)
                {
                    if (raceData == null)
                        raceData = new RaceData();
                    int raceEventId;
                    if (int.TryParse(keyValuePair.Value, out raceEventId))
                    {
                        raceData.RaceEvent = (RaceEvent)raceEventId;
                        raceData.Event = raceData.RaceEvent.ToString();
                    }
                }
                else if (keyValuePair.Key == RaceLogger.LapsTag)
                {
                    if (raceData == null)
                        raceData = new RaceData();
                    raceData.Laps = keyValuePair.Value;
                }
                else if (keyValuePair.Key == RaceLogger.TimeStampTag)
                {
                    if (raceData == null)
                        raceData = new RaceData();
                    DateTime dateTime;
                    if (DateTime.TryParse(keyValuePair.Value, out dateTime))
                        raceData.TimeStamp = dateTime;
                }
                else if (keyValuePair.Key == RaceLogger.PenaltiesTag)
                {
                    if (raceData == null)
                        raceData = new RaceData();
                    raceData.Penalties = keyValuePair.Value;
                }
                else if (keyValuePair.Key == RaceLogger.PositionTag)
                {
                    if (raceData == null)
                        raceData = new RaceData();
                    raceData.Position = keyValuePair.Value;
                }
                else if (keyValuePair.Key == RaceLogger.LaptimeTag)
                {
                    if (raceData == null)
                        raceData = new RaceData();
                    TimeSpan timeSpan;
                    if (TimeSpan.TryParse("00:" + keyValuePair.Value, out timeSpan))
                        raceData.LapTime = timeSpan;
                }
            }
            if (raceData != null && raceData.RaceEvent != RaceEvent.Undefined)
                RaceDataList.Add(raceData);
        }

        private KeyValuePair<string, string> DetermineKeyValuePair(string taggedValue)
        {
            KeyValuePair<string, string> keyValuePair = new KeyValuePair<string, string>();

            string[] splitted = taggedValue.Split(new[] { ": " }, StringSplitOptions.None);
            if (splitted.Length == 2)
                keyValuePair = new KeyValuePair<string, string>(splitted[0].Trim(), splitted[1].Trim());

            return keyValuePair;
        }

        private void RemoveCopiedFile()
        {
            File.Delete(_copiedFileName);
        }

        private void CopyFile()
        {
            _copiedFileName = _fileName + ".temp_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            File.Copy(_fileName, _copiedFileName, true);
        }

    }
}
