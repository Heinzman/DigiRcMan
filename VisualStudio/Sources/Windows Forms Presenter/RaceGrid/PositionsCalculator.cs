using System.Drawing;
using System.Windows.Forms;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Races;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsPresenter.RaceGrid
{
    public class PositionsCalculator
    {
        private readonly IRaceModel _raceModel;
        private readonly IRaceGridView _raceGridView;
        private int _maxPosition;
        private string _additionalText;

        public PositionsCalculator(IRaceModel raceModel, IRaceGridView raceGridView)
        {
            _raceModel = raceModel;
            _raceGridView = raceGridView;
        }

        public void UpdatePositions()
        {
            DetermineAndAssignPositionTexts();
            ClearAdditionalLabelTexts();
        }

        private void DetermineAndAssignPositionTexts()
        {
            _maxPosition = 0;
            foreach (Lane lane in _raceModel.Race.Lanes)
            {
                if (lane.IsStartedOrInitializedOrFinished && (lane.Lap > -1 || _raceModel.Race.Type == Race.TypeEnum.Race))
                {
                    int position = lane.Position;
                    if (position > _maxPosition)
                        _maxPosition = position;

                    Label label = _raceGridView.GetLblPositionOf(position);
                    if (label != null)
                    {
                        string previousPositionText = label.Text;
                        string nextPositionText = position + "." + lane.Driver.Name;
                        if (lane.Lap > -1)
                        {
                            CalcAdditionalText(position, lane);
                            nextPositionText += _additionalText;
                        }
                        if (previousPositionText != nextPositionText)
                            _raceGridView.SetControlPropertyThreadSafe(label, "Text", nextPositionText);
                    }

                    PictureBox pictureBox = _raceGridView.GetPicPositionOf(position);
                    if (pictureBox != null)
                    {
                        Image previousPositionImage = pictureBox.Image;
                        Image nextPositionImage = lane.Car.Image;
                        if (previousPositionImage != nextPositionImage)
                            _raceGridView.SetControlPropertyThreadSafe(pictureBox, "Image", nextPositionImage);
                    }
                }
            }
        }

        private void CalcAdditionalText(int position, Lane lane)
        {
            _additionalText = string.Empty;
            if (_raceModel.Race.IsCompetition && position > 1)
                CalcDeltaLapTime(lane);
            else if (_raceModel.Race.Type == Race.TypeEnum.Qualification)
                CalcBestRaceTime(lane);
        }

        private void CalcBestRaceTime(Lane lane)
        {
            string bestLapTime = GridPresenter.Format(lane.BestLapTime);
            _additionalText = " (" + bestLapTime + ")";
        }

        private void ClearAdditionalLabelTexts()
        {
            int pos = 1;
            foreach (Label label in _raceGridView.PositionLabels)
            {
                if (pos > _maxPosition)
                {
                    _raceGridView.SetControlPropertyThreadSafe(label, "Text", string.Empty);
                    PictureBox pictureBox = _raceGridView.GetPicPositionOf(pos);
                    if (pictureBox != null)
                        _raceGridView.SetControlPropertyThreadSafe(pictureBox, "Image", null);
                }
                pos++;
            }
        }

        private void CalcDeltaLapTime(Lane lane)
        {
            if (lane.DeltaLapTimeToLeadingLane.HasValue)
            {
                string deltaLapTime = GridPresenter.Format(lane.DeltaLapTimeToLeadingLane);
                _additionalText = " (" + deltaLapTime + ")";
            }
        }

    }
}
