using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.Log;
using Elreg.Logger;

namespace Elreg.RaceStatisticsService
{
    public class StatisticLogger : LoggerBase, IRaceLapObserver
    {
        private readonly IRaceModel _raceModel;

        private const string LoggerNameConst = "StatisticLog";
        private const int MaxLinesInChapterConst = 1;

        public StatisticLogger(IRaceModel raceModel) : base(false)
        {
            _raceModel = raceModel;
        }

        public new bool Activated
        {
            get { return base.Activated; }
            set
            {
                if (!base.Activated && value)
                {
                    StartLogging();
                    _raceModel.Attach(this);
                }
                else if (base.Activated && !value)
                {
                    ForceFlush();
                    StopLogging();
                    _raceModel.Detach(this);
                }
                base.Activated = value;
            }
        }

        public override string LogsPath
        {
            get { return ServiceHelper.StatisticsPath; }
        }
        
        public string FileName
        {
            get { return TextLogger.TextFileName; }
        }

        public void LapAdded(LaneId laneId)
        {
            try
            {
                Lane lane = _raceModel.RaceHandler.GetLaneById(laneId);
                TimeSpan? lapTime = lane.LapTime;
                if (lapTime.HasValue)
                {
                    StatisticRecord statisticRecord = new StatisticRecord
                                                          {
                                                              TrackName = _raceModel.RaceSettings.TrackName,
                                                              EventName = _raceModel.RaceSettings.EventName,
                                                              CarId = lane.Car.Id,
                                                              CarName = lane.Car.Name,
                                                              DriverId = lane.Driver.Id,
                                                              DriverName = lane.Driver.Name,
                                                              LapTime = lapTime.Value,
                                                              RaceType = _raceModel.Race.Type,
                                                              TimeStamp = DateTime.Now
                                                          };
                    string xml = Serialize(statisticRecord);
                    TextLogger.Log(xml);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void LapNotAddedDuePenaltyOrNoFuel(LaneId laneId) { }

        public void LapNotAddedDueMinSeconds(LaneId laneId) { }

        public override string LoggerName
        {
            get { return LoggerNameConst; }
        }

        public void AutoDetectedLapAdded(LaneId laneId) { }

        public void Finished(LaneId laneId)
        {
            try
            {
                ForceFlush();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ForceFlush()
        {
            TextLogger.Flush();
        }

        private string Serialize(StatisticRecord statisticRecord)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(StatisticRecord)); 
                StringBuilder builder = new StringBuilder();
                XmlWriterSettings settings = new XmlWriterSettings {OmitXmlDeclaration = true};

                using (XmlWriter stringWriter = XmlWriter.Create(builder, settings)) 
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    serializer.Serialize(stringWriter, statisticRecord, ns); 
                    return builder.ToString();
                } 
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
                return null;
            }
        }

        protected override int MaxLinesInChapter
        {
            get { return MaxLinesInChapterConst; }
        }
    }
}
