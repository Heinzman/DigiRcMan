using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;

namespace Elreg.CentralUnitService
{
    public class CentralUnitNullObject : ICentralUnit
    {
        public CentralUnitNullObject(ICentralUnitOptionsService optionsService)
        {
            OptionsService = optionsService;
        }

        public ICentralUnitOptionsService OptionsService { get; private set; }

        public ISerialPortReader VcuSerialPortReader
        {
            get { return null; }
        }

        public void EngineDamaged(LaneId laneId)
        {
        }

        public void EngineFixed(LaneId laneId)
        {
        }

        public void StopControlling()
        {            
        }

        public void SendOptionsToArduino()
        {
        }
    }
}
