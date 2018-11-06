using Elreg.BusinessObjects.Races;

namespace Elreg.WindowsFormsView
{
    public interface IRaceView
    {
        Race Race { set; }
        void PauseRace();
        void RestartRace();
        void ShowCountDownForm();
    }
}
