using System;

namespace Elreg.DomainModels.RaceModel.LaneModel
{
    public interface IRaceLaneModel
    {
        void CheckToAddLapWithLapTime(DateTime? timeStamp);
        void AddLapManually();
        void RemoveLap();
        void AddPenalty();
        void UndoPenaltyFor();
    }
}