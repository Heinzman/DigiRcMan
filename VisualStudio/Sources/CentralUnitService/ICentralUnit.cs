using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;

namespace Elreg.CentralUnitService
{
    public interface ICentralUnit
    {
        ICentralUnitOptionsService OptionsService { get; }
        void EngineDamaged(LaneId laneId);
        void EngineFixed(LaneId laneId);
        void StopControlling();
        void SendOptionsToArduino();
    }
}