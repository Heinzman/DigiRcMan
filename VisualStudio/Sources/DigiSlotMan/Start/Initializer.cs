using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;
using Catel.IoC;
using Elreg.BusinessObjectContracts;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Options;
using Elreg.DomainModels;
using Elreg.DomainModels.Logs;
using Elreg.DomainModels.RaceModel;
using Elreg.HelperLib;
using Elreg.Log;
using Elreg.PortDataParser;
using Elreg.RaceActionSound;
using Elreg.RaceActionSpeech;
using Elreg.RaceControlService;
using Elreg.RaceDataService.RaceData;
using Elreg.RaceOptionsService;
using Elreg.RaceStatisticsService;
using Elreg.ResourcesService;
using Elreg.SerialPortReader.SerialPortReaders;
using Elreg.UnitTests.MockObjects.MockSerialPort;
using Elreg.WindowsFormsApplication;
using Elreg.WindowsFormsApplication.FormMocks;
using Elreg.WindowsFormsApplication.Forms;
using Elreg.WindowsFormsPresenter.RaceControl;

namespace Elreg.DigiRcMan.Start
{
    public class Initializer
    {
        protected Controls.Forms.Form StartForm;
        protected readonly RaceModel RaceModel = new RaceModel();
        private ISerialPort _vcuSerialPort;
        protected ISerialPortReader VcuSerialPortReader;
        private ISerialPortParser _serialPortParser;
        protected RaceDataProvider RaceDataProvider;
        private DriversService _driversService;
        private CarsService _carsService;
        private SoundOptionsService _soundOptionsService;
        private RaceKeyController _raceKeyController;
        private RaceSettingsService _raceSettingsService;
        protected VcuSerialPortService VcuSerialPortService;
        protected RfIdSettingsService RfIdSettingsService;
        private RaceProviderService _raceProviderService;
        // private ActionSoundsService _actionSoundsService;
        //private readonly SoundMixerService _soundMixerService = new SoundMixerService();
        //private MusicHandler _musicHandler; todo
        private StatisticLogger _statisticLogger;
        private readonly Lazy<IPropertySettings> _propertySettingsLazy;

        public Initializer()
        {
            _propertySettingsLazy = new Lazy<IPropertySettings>(() => (IPropertySettings)ServiceLocator.Default.ResolveType(typeof(IPropertySettings)));
        }

        [DllImport("user32.dll", SetLastError = false)]
        static extern IntPtr GetDesktopWindow();

        public virtual void StartApp()
        {
            try
            {
                InitErrorLogs();
                InitTracing();
                Application.ThreadException += new ThreadExceptionHandler().ApplicationThreadException;
                Init();
                InitMusicHandlerAndPlay();
                InitSoundDevice();
                InitBufferDescription();
                InitActionSoundsService();
                InitRaceActionSound();
                InitRaceActionSpeech();
                InitLoggerModel();
                InitCountDownSoundHandler();
                InitPauseSoundHandler();
                InstantiateStartForm();
                FormHelper.StartForm = StartForm;
                CheckIdsOfDriversAndCars();
                StartForm.Show();
                Application.Run(StartForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Assembly.GetExecutingAssembly().GetName().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorLog.LogError(false, ex);
            }
            finally
            {
                FlushTracing();
            }
        }

        private void CheckIdsOfDriversAndCars()
        {
            DriverIdChecker driverIdChecker = new DriverIdChecker(_driversService.Drivers);
            driverIdChecker.DoWork();
            CarIdChecker carIdChecker = new CarIdChecker(_carsService.Cars);
            carIdChecker.DoWork();
        }

        private void FlushTracing()
        {
            if (PropertySettings.Tracing && !PropertySettings.TraceAutoFlush)
                Trace.Flush();
        }

        private void InitTracing()
        {
            try
            {
                if (PropertySettings.Tracing)
                {
                    string logFileName = @".\Logs\TraceLog_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
                    Trace.Listeners.Add(new TextWriterTraceListener(logFileName));
                    Trace.AutoFlush = PropertySettings.TraceAutoFlush;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void InitSoundDevice()
        {
            if (PropertySettings.SoundActivated)
            {
                //DevicesCollection devicesCollection = new DevicesCollection();
                //_device = new Device(devicesCollection[0].DriverGuid);
                //_device.SetCooperativeLevel(FormHandle, CooperativeLevel.Priority);
            }
        }

        private void InitBufferDescription()
        {
            //const bool surroundSound = false;
            //if (PropertySettings.SoundActivated || PropertySettings.MusicActivated)
            //    _bufferDescription = new BufferDescription
            //                         {
            //                             Control3D = surroundSound,
            //                             ControlEffects = false,
            //                             ControlPan = !surroundSound,
            //                             ControlFrequency = true,
            //                             ControlVolume = true,
            //                             GlobalFocus = true
            //                         };
        }

        protected virtual void InstantiateStartForm()
        {
            StartForm = new RaceControlForm(RaceModel,
                                            _serialPortParser,
                                            RaceDataProvider,
                                            _driversService,
                                            _carsService,
                                            _soundOptionsService,
                                            _raceSettingsService,
                                            _raceKeyController,
                                            //_soundMixerService,
                                            //_actionSoundsService,
                                            _statisticLogger,
                                            VcuSerialPortService,
                                            VcuSerialPortReader);
        }

        protected void Init()
        {
            InitRfIdSettingsService();
            InitVcuSerialPortService();
            InitRaceProviderService();
            InitVcuSerialPort();
            InitVcuSerialPortReaderWriter();
            InitRaceSettingsService();
            CreateSerialPortParser();
            StartVcuSerialPortReader();
            InitRaceDataProvider();
            InitDriversService();
            InitCarsService();
            InitSoundsService();
            InitRaceKeyController();
            InitRaceModel();
            InitStatisticsService();
            SetLanguage();
        }

        private void InitRfIdSettingsService()
        {
            RfIdSettingsService = new RfIdSettingsService();

            //RfIdSettingsService.RfIdSettings.TagIdsOfCarIdList = new List<TagIdsOfCarId>(); todo
            //RfIdSettingsService.RfIdSettings.TagIdsOfCarIdList.Add(new TagIdsOfCarId
            //{
            //    CarId = 1,
            //    TagIds = new List<string> { "E3 A0 BC 30", "AA 02 02" }
            //});
            //RfIdSettingsService.RfIdSettings.TagIdsOfCarIdList.Add(new TagIdsOfCarId
            //{
            //    CarId = 2,
            //    TagIds = new List<string> { "C2 BB 01 01", "BB 02 02" }
            //});
            //RfIdSettingsService.RfIdSettings.TagIdsOfCarIdList.Add(new TagIdsOfCarId
            //{
            //    CarId = 3,
            //    TagIds = new List<string> { "AA CC 01 01", "CC 02 02" }
            //});
            //RfIdSettingsService.Save();
        }

        private void InitStatisticsService()
        {
            _statisticLogger = new StatisticLogger(RaceModel) {Activated = true};
        }

        private void SetLanguage()
        {
            LanguageManager.LanguageType = _raceSettingsService.RaceSettings.LanguageType;
        }

        private void InitMusicHandlerAndPlay()
        {
            try
            {
                if (PropertySettings.MusicActivated)
                {
                    //_musicHandler = new MusicHandler(RaceModel, _soundMixerService, _raceKeyController); todo
                    //_musicHandler.SetMainPlayerAndPlay();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        protected static void InitErrorLogs()
        {
            string appUserId = SystemHelper.UserId;
            string computer = SystemHelper.ComputerName;

            ErrorLog.Init(appUserId, UserId, computer, false);
        }

        private static string UserId
        {
            get
            {
                string userId = string.Empty;
                WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
                userId = windowsIdentity.Name;
                return userId;
            }
        }

        private void InitVcuSerialPortService()
        {
            VcuSerialPortService = new VcuSerialPortService();
        }

        private void InitRaceProviderService()
        {
            _raceProviderService = new RaceProviderService();
        }

        private void InitVcuSerialPort()
        {
            try
            {
                SerialPortCreator serialPortCreator = new SerialPortCreator(VcuSerialPortService.VcuSerialPortSettings);
                _vcuSerialPort = serialPortCreator.DoWork();

            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void InitVcuSerialPortReaderWriter()
        {
            try
            {
                PortReaderWriter portReaderWriter = new PortReaderWriter(_vcuSerialPort);

                if (PropertySettings.UseMockVcuSerialPortReader)
                    VcuSerialPortReader = new SerialPortReaderMock();
                else
                    VcuSerialPortReader = portReaderWriter;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }


        private void StartVcuSerialPortReader()
        {
            try
            {
                VcuSerialPortReader.Start();

                if (PropertySettings.UseMockVcuSerialPortReader)
                {
                    SerialPortMockForm serialPortMockForm = new SerialPortMockForm(VcuSerialPortReader as SerialPortReaderMock);
                    serialPortMockForm.Show();
                }
            }
            catch (IOException ex)
            {
                ErrorLog.LogError(true, ex);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void InitLoggerModel()
        {
            try
            {
                LoggerModel.Inst.RaceModel = RaceModel;
                LoggerModel.Inst.PortReader = VcuSerialPortReader;
                LoggerModel.Inst.SerialPortParser = _serialPortParser;
                LoggerModel.Inst.LoadData();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void InitRaceKeyController()
        {
            KeySettings keySettings = new KeySettings();
            _raceKeyController = new RaceKeyController(RaceModel, keySettings);
        }

        private void CreateSerialPortParser()
        {
            _serialPortParser = new RfIdSerialPortParser(VcuSerialPortReader, RfIdSettingsService.RfIdSettings);
        }

        private void InitRaceDataProvider()
        {
            RaceDataProvider = new RaceDataProvider(_serialPortParser, _raceProviderService, RaceModel);
        }

        private void InitDriversService()
        {
            _driversService = new DriversService();
        }

        private void InitCarsService()
        {
            _carsService = new CarsService();
        }

        private void InitRaceSettingsService()
        {
            _raceSettingsService = new RaceSettingsService();
        }

        private void InitSoundsService()
        {
            _soundOptionsService = new SoundOptionsService();
        }

        private void InitActionSoundsService()
        {
            try
            {
                //if (PropertySettings.SoundActivated) todo
                    //_actionSoundsService = new ActionSoundsService(_soundOptionsService, _driversService, _device,
                    //                                               _bufferDescription, SoundMixer,
                    //                                               RaceModel);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void InitRaceActionSound()
        {
            try
            {
            //    if (PropertySettings.SoundActivated) todo
            //        new RaceActionSoundHandler(RaceModel, _actionSoundsService, _raceSettingsService.RaceSettings);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void InitRaceActionSpeech()
        {
            try
            {
                if (PropertySettings.SoundActivated)
                    new RaceActionSpeechHandler(RaceModel);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void InitCountDownSoundHandler()
        {
            try
            {
                if (PropertySettings.SoundActivated)
                   new CountDownSoundHandler(RaceModel); 
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void InitPauseSoundHandler()
        {
            try
            {
                if (PropertySettings.SoundActivated)
                {
                    //PauseSoundHandler pauseSoundHandler = new PauseSoundHandler(RaceModel, _device, SoundMixer); todo
                    //pauseSoundHandler.Init();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void InitRaceModel()
        {
            RaceModel.LapTimeAvgCalculator = new LapTimeAvgCalculator(_raceSettingsService.RaceSettings);
            RaceModel.RaceSettings = _raceSettingsService.RaceSettings;
        }

        private static IntPtr FormHandle
        {
            get { return GetDesktopWindow(); }
        }

        //private SoundMixer SoundMixer
        //{
        //    get { return _soundMixerService.SoundMixer; }
        //}

        private IPropertySettings PropertySettings
        {
            get { return _propertySettingsLazy.Value; }
        }

    }
}
