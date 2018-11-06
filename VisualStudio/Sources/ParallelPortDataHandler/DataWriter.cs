using System;
using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.Interfaces;

namespace Elreg.ParallelPortDataHandler
{
    public class DataWriter : IPortDataWriter
    {
        private readonly IParallelPortWriter _parallelPortWriter;
        private int _portValueA;
        private int _portValueB;
        private const int Pin0Value = 1;
        private const int Pin1Value = 2;
        private const int Pin2Value = 4;
        private const int Pin3Value = 8;
        public int PortValue { get; private set; }

        public event EventHandler<ParallelDataWriterEventArgs> PortValueChanged;

        public DataWriter(IParallelPortWriter parallelPortWriter)
        {
            _portValueB = 0;
            _parallelPortWriter = parallelPortWriter;
            Reset();
        }

        private void Reset()
        {
            PortValue = 0; 
            WriteValueAndRaiseEvent();
        }

        public void SetOutputValueOfGhostA(GhostController ghostController)
        {
            _portValueA = CalcPortValue(Ghost.GhostA, ghostController);
            CalcAndSetPortValue();
        }

        public void SetOutputValueOfGhostB(GhostController ghostController)
        {
            _portValueB = CalcPortValue(Ghost.GhostB, ghostController);
            CalcAndSetPortValue();
        }

        public void SetOutputValueOf(GhostController ghostControllerA, GhostController ghostControllerB)
        {
            _portValueA = CalcPortValue(Ghost.GhostA, ghostControllerA);
            _portValueB = CalcPortValue(Ghost.GhostB, ghostControllerB);
            CalcAndSetPortValue();
        }

        public void SetOutputValues(List<GhostController> ghostControllers)
        {
            if (ghostControllers != null && ghostControllers.Count > 0)
            {
                _portValueA = CalcPortValue(Ghost.GhostA, ghostControllers[0]);
                if (ghostControllers.Count > 1)
                    _portValueB = CalcPortValue(Ghost.GhostB, ghostControllers[1]);
                CalcAndSetPortValue();               
            }
        }

        private void CalcAndSetPortValue()
        {
            PortValue = _portValueA + _portValueB;
            //Debug.WriteLine("PortValue: " + PortValue);
            WriteValueAndRaiseEvent();
        }

        private void WriteValueAndRaiseEvent()
        {
            _parallelPortWriter.WriteValue(PortValue);
            if (PortValueChanged != null)
                PortValueChanged(this, new ParallelDataWriterEventArgs(PortValue));
        }

        private int CalcPortValue(Ghost ghost, GhostController ghostController)
        {
            int portValue = 0;

            if (ghostController.Level == 1)
                portValue = PortValue1Of(ghost);
            else if (ghostController.Level == 2)
                portValue = PortValue2Of(ghost);
            else if (ghostController.Level == 3)
                portValue = PortValue3Of(ghost);
            else if (ghostController.Level == 4)
                portValue = PortValue4Of(ghost);
            else if (ghostController.Level == 5)
                portValue = PortValue5Of(ghost);
            else if (ghostController.Level == 6)
                portValue = PortValue6Of(ghost);
            else if (ghostController.Level == 7)
                portValue = PortValue7Of(ghost);

            if (ghostController.IsButtonPressed)
                portValue = portValue + PortValueButtonOf(ghost);

            return portValue;
        }

        private int PortValueButtonOf(Ghost ghost)
        {
            return Pin0Value * GetGhostMultiplicator(ghost);
        }

        private int PortValue1Of(Ghost ghost)
        {
            return Pin1Value * GetGhostMultiplicator(ghost);
        }

        private int PortValue2Of(Ghost ghost)
        {
            return Pin2Value * GetGhostMultiplicator(ghost);
        }

        private int PortValue3Of(Ghost ghost)
        {
            return (Pin1Value * GetGhostMultiplicator(ghost)) + (Pin2Value * GetGhostMultiplicator(ghost));
        }

        private int PortValue4Of(Ghost ghost)
        {
            return Pin3Value * GetGhostMultiplicator(ghost);
        }

        private int PortValue5Of(Ghost ghost)
        {
            return (Pin1Value * GetGhostMultiplicator(ghost)) + (Pin3Value * GetGhostMultiplicator(ghost));
        }

        private int PortValue6Of(Ghost ghost)
        {
            return (Pin2Value * GetGhostMultiplicator(ghost)) + (Pin3Value * GetGhostMultiplicator(ghost));
        }

        private int PortValue7Of(Ghost ghost)
        {
            return (Pin1Value * GetGhostMultiplicator(ghost)) + (Pin2Value * GetGhostMultiplicator(ghost)) + (Pin3Value * GetGhostMultiplicator(ghost));
        }

        private int GetGhostMultiplicator(Ghost ghost)
        {
            int multiplicator = 1;
            if (ghost == Ghost.GhostB)
                multiplicator = 16;
            return multiplicator;
        }

    }
}
