using System;
using System.Collections.Generic;
using Elreg.BusinessObjects;

namespace Elreg.RaceConsolidationService
{
    public class LinearRaceDataCreator
    {
        private readonly List<RaceData> _raceDataList;

        public List<LinearRaceData> LinearRaceDataList { get; private set; }

        public LinearRaceDataCreator(List<RaceData> raceDataList)
        {
            _raceDataList = raceDataList;
            LinearRaceDataList = new List<LinearRaceData>();
        }

        public void DoWork()
        {
            DateTime? dateTimeOfRaceStart = null;
            LinearRaceData previousLinearRaceData = null;

            foreach (RaceData raceData in _raceDataList)
            {
                if (raceData.RaceEvent == RaceEvent.RaceStarted)
                {
                    dateTimeOfRaceStart = raceData.TimeStamp;
                    previousLinearRaceData = null;
                }
                if (dateTimeOfRaceStart != null)
                {
                    LinearRaceData linearRaceData = new LinearRaceData();
                    linearRaceData.TimeStamp = raceData.TimeStamp;
                    linearRaceData.Driver = raceData.Driver;
                    linearRaceData.Event = raceData.Event;
                    linearRaceData.Fuel = raceData.Fuel;
                    linearRaceData.LapTime = raceData.LapTime;
                    linearRaceData.Laps = raceData.Laps;
                    linearRaceData.Penalties = raceData.Penalties;
                    linearRaceData.Position = raceData.Position;
                    linearRaceData.RaceEvent = raceData.RaceEvent;
                    TimeSpan timeSpan = raceData.TimeStamp - dateTimeOfRaceStart.Value;
                    linearRaceData.Second = (int)timeSpan.TotalSeconds;

                    if (previousLinearRaceData != null)
                    {
                        for (int second = previousLinearRaceData.Second+1; second < linearRaceData.Second; second++)
                        {
                            LinearRaceDataList.Add(new LinearRaceData { Second = second });
                        }
                    }
                    LinearRaceDataList.Add(linearRaceData);
                    previousLinearRaceData = linearRaceData;
                }
            }
        }
    }
}
