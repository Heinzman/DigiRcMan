using System;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.Log;
using Elreg.WindowsFormsView;
using Elreg.DomainModels;
using Elreg.Logger;

namespace Elreg.WindowsFormsPresenter
{
    public class PortParserLogPresenter 
    {
        private readonly IPortParserLogView _portParserLogView;
        private readonly PortParserLogModel _portParserLogModel;
        private string _logText;
        private string _actionText;
        private string _comPortLine;

        public PortParserLogPresenter(IPortParserLogView portParserLogView, PortParserLogModel portParserLogModel)
        {
            try
            {
                _portParserLogModel = portParserLogModel;
                _portParserLogView = portParserLogView;
                _portParserLogModel.LogReceived += PortParserLogModelLogReceived;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void Detach()
        {
            try
            {
                _portParserLogModel.LogReceived -= PortParserLogModelLogReceived;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void PortParserLogModelLogReceived(object sender, PortParserEventArgs e)
        {
            try
            {
                PortDataActionTextCreator textCreator = new PortDataActionTextCreator(e);
                _actionText = textCreator.ActionText;
                _comPortLine = e.ComPortLine;
                CalcLogText();
                Display();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void Display()
        {
            _portParserLogView.UpdateLog(_logText);
        }

        private void CalcLogText()
        {
            _logText = _actionText + "  (" + _comPortLine + ")" + Environment.NewLine;
        }

    }
}
