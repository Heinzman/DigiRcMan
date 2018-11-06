using System;
using System.Collections.Generic;
using System.Text;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Lanes;
using Elreg.DomainModels.RaceModel;
using Elreg.Log;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsPresenter
{
    public class RaceLogPresenter : RacePresenter
    {
        private readonly IRaceLogView _raceLogView;

        public RaceLogPresenter(IRaceLogView raceLogView, RaceModel raceModel)
            : base(raceModel)
        {
            try
            {
                _raceLogView = raceLogView;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public override void FillView()
        {
            try
            {
                string race = ComputeRaceString();
                _raceLogView.DisplayRace(race);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        protected override void UpdateRace()
        {
            string race = ComputeRaceString();
            _raceLogView.DisplayRace(race);
        }

        protected override void UpdateLane(Lane lane)
        {
        }

        private string ComputeRaceString()
        {
            StringBuilder raceStringBuilder = new StringBuilder();
            raceStringBuilder.Append("Race: ");
            raceStringBuilder.Append(RaceModel.Race.Status);
            raceStringBuilder.Append("\r\n\r\n");

            foreach (Lane lane in RaceModel.Race.Lanes)
            {
                raceStringBuilder.Append(ComputeLaneString(lane));
                raceStringBuilder.Append("\r\n");
            }
            return raceStringBuilder.ToString();
        }

        private string ComputeLaneString(Lane lane)
        {
            string laneString = "ID: " + ((int) lane.Id + 1) + "\t| " +
                                "Pos: " + lane.Position + "\t| " +
                                "Driver: " + lane.Driver.Name + "\t| " +
                                "Car: " + lane.Car.Name + "\t| " +
                                "Lap: " + lane.Lap + "\t| " +
                                "Lap Time: " + Format(lane.LapTime) + "\t| " +
                                "Lap Time Net: " + Format(lane.LapTimeNet) + "\t| " +
                                "Best Lap Time: " + Format(lane.BestLapTime) + "\t| " +
                                "Penalties: " + lane.PenaltyCount + "\t| " +
                                "Race Time: " + Format(lane.RaceTime) + "\t| " +
                                "Status: " + lane.Status + "\t| ";
            return laneString;
        }

        private string Format(TimeSpan? timeSpan)
        {
            string formattedValue = string.Empty;

            if (timeSpan != null)
                formattedValue = (DateTime.MinValue + (TimeSpan) timeSpan).ToString("mm:ss.ff");
            return formattedValue;
        }

    }
}