using System.Text;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.PortActions;

namespace Elreg.Logger
{
    public class PortDataActionTextCreator
    {
        private readonly PortParserEventArgs _portParserEventArgs;
        private readonly StringBuilder _actionTextBuilder = new StringBuilder();

        public PortDataActionTextCreator(PortParserEventArgs portParserEventArgs)
        {
            _portParserEventArgs = portParserEventArgs;
        }

        public string ActionText
        {
            get
            {
                CreateActionText();
                return _actionTextBuilder.ToString();
            }
        }

        private void CreateActionText()
        {
            if (LapDetectionAction != null)
                CreateLapDetectionAction();
            else if (CarControllersAction != null)
                CreateCarControllersActions();
        }

        private void CreateLapDetectionAction()
        {
            _actionTextBuilder.Clear();
            _actionTextBuilder.Append("Lap: ");
            if (LapDetectionAction.Car1)
                _actionTextBuilder.Append("Car1 ");
            if (LapDetectionAction.Car2)
                _actionTextBuilder.Append("Car2 ");
            if (LapDetectionAction.Car3)
                _actionTextBuilder.Append("Car3 ");
            if (LapDetectionAction.Car4)
                _actionTextBuilder.Append("Car4 ");
            if (LapDetectionAction.Car5)
                _actionTextBuilder.Append("Car5 ");
            if (LapDetectionAction.Car6)
                _actionTextBuilder.Append("Car6 ");
        }

        private void CreateCarControllersActions()
        {
            _actionTextBuilder.Clear();
            _actionTextBuilder.Append("Controller: ");
            CreateCarControllersAction(CarControllersAction.CarController1, 1);
            CreateCarControllersAction(CarControllersAction.CarController2, 2);
            CreateCarControllersAction(CarControllersAction.CarController3, 3);
            CreateCarControllersAction(CarControllersAction.CarController4, 4);
            CreateCarControllersAction(CarControllersAction.CarController5, 5);
            CreateCarControllersAction(CarControllersAction.CarController6, 6);
        }

        private void CreateCarControllersAction(CarController carController, int laneId)
        {
            if (carController != null)
            {
                _actionTextBuilder.Append("Car");
                _actionTextBuilder.Append(laneId.ToString());
                _actionTextBuilder.Append(" ");
                _actionTextBuilder.Append("Speed ");
                _actionTextBuilder.Append(carController.Speed.ToString());
                _actionTextBuilder.Append(" Btn ");
                _actionTextBuilder.Append(carController.LaneChange.ToString());
                _actionTextBuilder.Append(" ");
            }
        }

        private LapDetectionAction LapDetectionAction
        {
            get { return _portParserEventArgs.LapDetectionAction; }
        }

        private CarControllersAction CarControllersAction
        {
            get { return _portParserEventArgs.CarControllersAction; }
        }


    }
}
