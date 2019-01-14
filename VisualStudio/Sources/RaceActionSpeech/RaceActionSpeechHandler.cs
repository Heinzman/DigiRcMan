using System;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.ComputerSpeech;

namespace Elreg.RaceActionSpeech
{
    public class RaceActionSpeechHandler : IRaceObserver, IRaceStatusObserver
    {
        private readonly IRaceModel _raceModel;
        private readonly SpeechHandler _speachHandler;

        public RaceActionSpeechHandler(IRaceModel raceModel)
        {
            _raceModel = raceModel;
            AttachToModelAsObserver();
            _speachHandler = new SpeechHandler(_raceModel.RaceSettings.SpeedOfSpeech);
        }

        private void AttachToModelAsObserver()
        {
            _raceModel.Attach(this as IRaceObserver);
            _raceModel.Attach(this as IRaceStatusObserver);
        }

        public void LapAdded(LaneId laneId)
        {           
            Lane lane = _raceModel.RaceHandler.GetLaneById(laneId);
            if (!IsLastLap(lane))
            {
                bool shouldSpeak = false;
                string textToSpeak = $"{lane.Driver.Name}";

                if (!IsInitialLap(lane) && !lane.IsFinished)
                {
                    if (lane.PositionOfLastLap != lane.Position)
                    {
                        textToSpeak += $" {GetOrdinalPosition(lane.Position)}";
                        shouldSpeak = true;
                    }
                    if (lane.Lap % ModuloForLapSpeech == 0)
                    {
                        textToSpeak += $" Runde {lane.Lap}";
                        shouldSpeak = true;
                    }
                    if (_raceModel.RaceSettings.IsUserSpeechForEveryLapActivated)
                        shouldSpeak = true;
                }
                textToSpeak += " ";

                if (shouldSpeak)
                    _speachHandler.AddTextToQueueAndSpeak(textToSpeak);
            }
        }

        public int ModuloForLapSpeech => _raceModel.RaceSettings.ModuloForLapCountSpeech;

        private bool IsInitialLap(Lane lane)
        {
            return lane.Lap == 0;
        }

        private bool IsLastLap(Lane lane)
        {
            return lane.IsFinished && lane.Lap == _raceModel.RaceSettings.LapsToDrive;
        }

        private string GetOrdinalPosition(int position)
        {
            string ordinalPositionText;

            switch (position)
            {
                case 1:
                    ordinalPositionText = "erster";
                    break;
                case 2:
                    ordinalPositionText = "zweiter";
                    break;
                case 3:
                    ordinalPositionText = "dritter";
                    break;
                case 4:
                    ordinalPositionText = "vierter";
                    break;
                case 5:
                    ordinalPositionText = "fünfter";
                    break;
                case 6:
                    ordinalPositionText = "sechster";
                    break;
                case 7:
                    ordinalPositionText = "siebter";
                    break;
                case 8:
                    ordinalPositionText = "achter";
                    break;
                case 9:
                    ordinalPositionText = "neunter";
                    break;
                default:
                    ordinalPositionText = position + "ter";
                    break;
            }
            return ordinalPositionText;
        }

        private string GetFinalPosition(int position)
        {
            string ordinalPositionText;

            if (position == 1)
                ordinalPositionText = "hat gewonnen";
            else
                ordinalPositionText = $"ist {GetOrdinalPosition(position)} Sieger";

            return ordinalPositionText;
        }

        public void LapNotAddedDueMinSeconds(LaneId laneId)
        {
        }

        public void Finished(LaneId laneId)
        {
            Lane lane = _raceModel.RaceHandler.GetLaneById(laneId);
            string textToSpeak = $"{lane.Driver.Name} {GetFinalPosition(lane.PositionOfLastLap)}.";
            _speachHandler.AddTextToQueueAndSpeak(textToSpeak);

        }

        public void RaceChanged(object sender, EventArgs e)
        {
        }

        public void PenaltyAdded(LaneId laneId)
        {
        }

        public void Disqualified(LaneId laneId)
        {
            Lane lane = _raceModel.RaceHandler.GetLaneById(laneId);
            string textToSpeak = $"{lane.Driver.Name} wurde disqualifiziert.";
            _speachHandler.AddTextToQueueAndSpeak(textToSpeak);
        }

        public void RaceStatusChanged(object sender, EventArgs e)
        {
        }

        public void LaneChanged(LaneId laneid)
        {
        }

        public void RaceStarted(object sender, EventArgs e)
        {
        }

        public void RaceRestarted(object sender, EventArgs e)
        {
        }

        public void RacePaused(object sender, EventArgs e)
        {
        }

        public void RaceInitialized(object sender, EventArgs e)
        {
        }

        public void RaceFinished(object sender, EventArgs e)
        {
        }

        public void RaceStopped(object sender, EventArgs e)
        {
        }
    }
}
