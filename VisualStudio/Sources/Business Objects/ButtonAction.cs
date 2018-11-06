using System;
using System.Collections.Generic;

namespace Elreg.BusinessObjects
{
    public class ButtonAction
    {
        private readonly int _buttonPressedCountForAction;
        private readonly Queue<DateTime?> _timeStampBtnPressedDownQueue;
        private DateTime? _timeStampBtnPressedDownFirst;

        public ButtonAction(int buttonPressedCountForAction)
        {
            _buttonPressedCountForAction = buttonPressedCountForAction;
            _timeStampBtnPressedDownQueue = new Queue<DateTime?>();
        }

        public bool IsBtnPressedDown { get; private set; }

        public DateTime TimeStampBtnPressedDownFirst
        {
            get
            {
                if (_timeStampBtnPressedDownFirst.HasValue)
                    return (DateTime)_timeStampBtnPressedDownFirst;
                else
                    return DateTime.Now.AddYears(-1);
            }
        }

        public DateTime TimeStampBtnPressedDownLast
        {
            get
            {
                DateTime? timeStampBtnPressedDownLast = null;
                if (_timeStampBtnPressedDownQueue.Count > 0)
                    timeStampBtnPressedDownLast = _timeStampBtnPressedDownQueue.Peek();

                if (timeStampBtnPressedDownLast.HasValue)
                    return (DateTime)timeStampBtnPressedDownLast;
                else
                    return DateTime.Now.AddYears(-1);
            }
        }

        public void HandleButtonPressedDown()
        {
            _timeStampBtnPressedDownQueue.Enqueue(DateTime.Now);
            while (_timeStampBtnPressedDownQueue.Count >= _buttonPressedCountForAction)
                _timeStampBtnPressedDownFirst = _timeStampBtnPressedDownQueue.Dequeue();
            IsBtnPressedDown = true;
        }

        public void HandleButtonUp()
        {
            IsBtnPressedDown = false;
        }

        public void Clear()
        {
            _timeStampBtnPressedDownQueue.Clear();
            _timeStampBtnPressedDownFirst = null;
        }
    }
}
