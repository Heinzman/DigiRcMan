using System;

namespace Elreg.DomainModels.RaceModel.LaneModel
{
    internal class RaceLaneModelNullObject : IRaceLaneModel
    {
        public void HandleFuelConsumption(uint speed, float speedListConsumptionFactor)
        {
        }

        public void AddFuel(float litres)
        {
        }

        public void RemoveFuel(float litres)
        {
        }

        public void CheckToAddLapWithLapTime(DateTime? timeStamp)
        {
        }

        public void AddLapManually()
        {
        }

        public void RemoveLap()
        {
        }

        public void AddPenalty()
        {
        }

        public void AddFalseStart()
        {
        }

        public void UndoPenaltyFor()
        {
        }

        public void HandlePitIn()
        {
        }

        public void HandlePitOut()
        {
        }

        public void CheckAutoDetectedLap(uint speed, float speedListConsumptionFactor)
        {
        }

        public void HandlePenaltyTimerElapsed()
        {
        }

        public void HandleFixingEngineTimerElapsed()
        {
        }

        public void HandleRefuelWaitingTimerElapsed()
        {
        }

        public void HandleRefuelTimerElapsed()
        {
        }

        public void HandleFixingDamageByRocketTimerElapsed()
        {
        }

        public void ReloadRocketWaitingTimerElapsed()
        {
        }
    }
}
