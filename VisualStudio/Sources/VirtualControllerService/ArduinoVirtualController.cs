using Heinzman.BusinessObjects;
using Heinzman.BusinessObjects.Interfaces;

namespace Heinzman.VirtualControllerService
{
    public class ArduinoVirtualController : IVirtualController
    {
        private readonly IArduinoReader _arduinoReader;
        private readonly LaneId _laneId;

        public ArduinoVirtualController(IArduinoReader arduinoReader, LaneId laneId)
        {
            _arduinoReader = arduinoReader;
            _laneId = laneId;
        }

        public ControllerLevel CurrentLevel
        { 
            get { return _arduinoReader.GetControllerLevelOf(_laneId); }
            set { }
        }

        public bool IsButtonPressed
        {
            get { return _arduinoReader.GetButtonPressedOf(_laneId); }
            set { }
        }


    }
}
