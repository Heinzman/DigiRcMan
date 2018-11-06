using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Elreg.BusinessObjects.Lanes;
using Elreg.HelperClasses;
using Elreg.Log;
using Elreg.WindowsFormsView;
using Elreg.WinFormsPresentationFramework;

namespace Elreg.WindowsFormsPresenter
{
    public abstract class GridPresenter
    {
        protected GridHandler GridHandler;
        private GridSettings _settings;
        private readonly ISimpleView _view;

        protected GridPresenter(ISimpleView view)
        {
            _view = view;
            LoadSettings();
        }

        protected abstract string DefaultXmlFileName { get; }

        public void HandleGridKey(KeyEventArgs e)
        {
            GridHandler.HandleKey(e);
        }

        public void SizeGrid()
        {
            if (_view.WindowState != FormWindowState.Minimized)
                GridHandler.SizeGrid();
        }

        public void IncreaseDataGridFont()
        {
            GridHandler.IncreaseDataGridFont();
        }

        public void DecreaseDataGridFont()
        {
            GridHandler.DecreaseDataGridFont();
        }

        public void IncreaseCellFont()
        {
            GridHandler.IncreaseCellFont();
        }

        public void DecreaseCellFont()
        {
            GridHandler.DecreaseCellFont();
        }

        public void IncreaseStatusCellFont()
        {
            GridHandler.IncreaseStatusCellFont();
        }

        public void DecreaseStatusCellFont()
        {
            GridHandler.DecreaseStatusCellFont();
        }

        public void IncreaseHeaderCellFont()
        {
            GridHandler.IncreaseHeaderCellFont();
        }

        public void DecreaseHeaderCellFont()
        {
            GridHandler.DecreaseHeaderCellFont();
        }

        public void SaveGridSettings()
        {
            string newXmlFileName;
            if (GridHandler.SaveGridSettings(XmlFileName, out newXmlFileName))
            {
                XmlFileName = newXmlFileName;
                SaveSettings();
            }
        }

        private string XmlFileName
        {
            get { return Settings.FileName; }
            set { Settings.FileName = value; }
        }

        public void LoadGridSettings()
        {
            if (CheckExistsXmlFile())
                GridHandler.LoadGridSettings(XmlFileName);
        }

        public void LoadGridSettingsChooseSource()
        {
            string newXmlFileName;
            if (GridHandler.LoadGridSettingsChooseSource(XmlFileName, out newXmlFileName))
            {
                XmlFileName = newXmlFileName;
                SaveSettings();
            }
        }

        private bool CheckExistsXmlFile()
        {
            bool exists = false;
            if (File.Exists(XmlFileName))
                exists = true;
            else if (File.Exists(DefaultXmlFileName))
            {
                XmlFileName = DefaultXmlFileName;
                exists = true;
            }
            return exists;
        }

        public void CheckIfSettingsChanged()
        {
            if (GridHandler.SettingsChanged)
            {
                const string message = "Die Einstellungen wurden geändert\nWillst du sie speichern?";
                if (MessageBox.Show(message, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    SaveGridSettings();
            }
            GridHandler.SettingsChanged = false;
        }

        public static string Format(TimeSpan? timeSpan)
        {
            string value = "--.---";
            string format = "ss.fff";
            if (timeSpan != null && timeSpan.Value != new TimeSpan())
            {
                if (timeSpan >= new TimeSpan(1, 0, 0))
                    format = "hh:mm:ss.fff";
                else if (timeSpan >= new TimeSpan(0, 1, 0))
                    format = "mm:ss.fff";
                value = (DateTime.Today + (TimeSpan) timeSpan).ToString(format);
            }
            else
                value = value + " ";
            return value;
        }

        protected static Image GetCarPicture(RaceResultLane raceResultLane)
        {
            return raceResultLane.Car.Image;
        }

        protected static string Format(int value)
        {
            if (value < 0)
                return string.Empty;
            else
                return value.ToString();
        }

        protected static string Format(float? value, int decimalPlaces)
        {
            double valueRounded = 0f;

            if (value.HasValue)
                valueRounded = Math.Round((double) value, decimalPlaces);
            return valueRounded.ToString();
        }

        private void LoadSettings()
        {
            try
            {
                Savior.Read(Settings, RegKey);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void SaveSettings()
        {
            try
            {
                Savior.Save(Settings, RegKey);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private string RegKey
        {
            get { return Constants.RegkeyPath + _view.Name; }
        }

        private GridSettings Settings
        {
            get { return _settings ?? (_settings = new GridSettings(DefaultXmlFileName)); }
        }
    }
}