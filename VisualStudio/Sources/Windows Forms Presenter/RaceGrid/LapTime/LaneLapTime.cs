using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.Log;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsPresenter.RaceGrid.LapTime
{
    public class LaneLapTime : ILaneLapTime
    {
        private readonly LaneId _laneId;
        private readonly IRaceModel _raceModel;
        private int _rowIndex = UndefinedRowIndex;
        private readonly IRaceGridView _raceGridView;
        private readonly IRaceGridPresenter _presenter;
        private readonly bool _isResetTimerActivated;
        private Color _backgroundColor;
        private readonly System.Timers.Timer _timer = new System.Timers.Timer();
        private bool _isBackcolorSet;
        private int _secondsExpired;

        private const int UndefinedRowIndex = -1;

        public LaneLapTime(LaneId laneId, IRaceModel raceModel, IRaceGridView raceGridView, IRaceGridPresenter presenter,
                           bool isResetTimerActivated)
        {
            _laneId = laneId;
            _raceModel = raceModel;
            _raceGridView = raceGridView;
            _presenter = presenter;
            _isResetTimerActivated = isResetTimerActivated;
            InitTimer();
        }

        private void InitTimer()
        {
            _timer.Interval = 900;
            _timer.Elapsed += TimerElapsed;
            _timer.Enabled = false;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (_secondsExpired++ >= _raceModel.RaceSettings.SecondsForValidLap)
                {
                    ResetBackgroundColor();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private int RowIndex
        {
            get
            {
                if (_rowIndex == UndefinedRowIndex)
                    _rowIndex = _presenter.GetRowIndexBy(_laneId);
                return _rowIndex;
            }
        }

        public void HandleLapAdded()
        {
            SetBackgroundColorToLapRecognized();
            CheckStartTimer();
        }

        private void CheckStartTimer()
        {
            if (_isResetTimerActivated)
                StartTimer();
        }

        private void StartTimer()
        {
            _timer.Start();
            _isBackcolorSet = true;
            _secondsExpired = 0;
        }

        public void HandleLapNotAddedDuePenaltyOrNoFuel()
        {
            SetBackgroundColorToLapNotAddedDuePenaltyOrNoFuel();
            CheckStartTimer();
        }

        public void HandleLapNotAddedDueMinSeconds()
        {
            SetBackgroundColorToLapNotAddedDueMinSeconds();
            CheckStartTimer();
        }

        public void HandleAutoDetectedLapAdded()
        {
            SetBackgroundColorToAutoDetectedLap();
            CheckStartTimer();
        }

        public void HandleFinished()
        {
            SetBackgroundColorToNormal();
        }

        public void HandleRaceRestarted()
        {
            if (_isBackcolorSet)
                _timer.Start();
        }

        public void Reset()
        {
            _rowIndex = UndefinedRowIndex;
        }

        public void ResetBackgroundColor()
        {
            SetBackgroundColorToNormal();
            _isBackcolorSet = true;
            _timer.Enabled = false;
            _secondsExpired = 0;
        }

        public void HandleRacePaused()
        {
            if (_isBackcolorSet)
                _timer.Stop();
        }

        private void SetBackgroundColorToLapRecognized()
        {
            Color backgroundColor = Color.LightGreen;
            SetBackgroundColor(RowIndex, backgroundColor);
        }

        private void SetBackgroundColorToLapNotAddedDuePenaltyOrNoFuel()
        {
            Color backgroundColor = ControlPaint.LightLight(Color.Red);
            SetBackgroundColor(RowIndex, backgroundColor);
        }

        private void SetBackgroundColorToLapNotAddedDueMinSeconds()
        {
            Color backgroundColor = GetBackgroundColorForLapNotAddedDueMinSeconds();
            SetBackgroundColor(RowIndex, backgroundColor);
        }

        private void SetBackgroundColorToLapNotAddedDueMinSecondsAfterAutoDetectedLap()
        {
            Color backgroundColor = GetBackgroundColorForLapNotAddedDueMinSecondsAfterAutoDetectedLap();
            SetBackgroundColor(RowIndex, backgroundColor);
        }

        private void SetBackgroundColorToNormal()
        {
            Color backgroundColor = _presenter.AlternatingBackgroundColor;
            if (RowIndex % 2 == 0)
                backgroundColor = _presenter.DefaultBackgroundColor;
            SetBackgroundColor(RowIndex, backgroundColor);
        }

        private void SetBackgroundColorToAutoDetectedLap()
        {
            Color backgroundColor = GetBackgroundColorForAutoDetectedLap();
            SetBackgroundColor(RowIndex, backgroundColor);
        }

        private static Color GetBackgroundColorForAutoDetectedLap()
        {
            return ControlPaint.LightLight(Color.Yellow);
        }

        private static Color GetBackgroundColorForLapNotAddedDueMinSeconds()
        {
            return ControlPaint.LightLight(Color.MediumPurple);
        }

        private static Color GetBackgroundColorForLapNotAddedDueMinSecondsAfterAutoDetectedLap()
        {
            return ControlPaint.LightLight(Color.Orange);
        }

        private void SetBackgroundColor(int rowIndex, Color backgroundColor)
        {
            if (rowIndex >= 0)
            {
                _backgroundColor = backgroundColor;
                _raceGridView.GrdLanes[RaceGridPresenter.Columns.ColumnLapTime.ToString(), rowIndex].Style.BackColor = _backgroundColor;
                _raceGridView.GrdLanes[RaceGridPresenter.Columns.ColumnLapTimeBestLapTime.ToString(), rowIndex].Style.BackColor = _backgroundColor;
                _raceGridView.GrdLanes[RaceGridPresenter.Columns.ColumnLapTime.ToString(), rowIndex].Style.SelectionBackColor = _backgroundColor;
                _raceGridView.GrdLanes[RaceGridPresenter.Columns.ColumnLapTimeBestLapTime.ToString(), rowIndex].Style.SelectionBackColor = _backgroundColor;
            }
        }

    }
}
