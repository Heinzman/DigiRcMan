using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;
using Heinzman.ArduinoService;
using Heinzman.BusinessObjects.Interfaces;
using Heinzman.BusinessObjects.Sound;
using Heinzman.CentralUnitService;
using Heinzman.CentralUnitService.Settings;
using Heinzman.Controls.Forms;
using Heinzman.DomainModels.Logs;
using Heinzman.DomainModels.RaceModel;
using Heinzman.DomainModels.RocketModel;
using Heinzman.GhostCarService;
using Heinzman.GhostCarService.Replay;
using Heinzman.MockObjects.MockSerialPort;
using Heinzman.MusicPlayer;
using Heinzman.ParallelPort;
using Heinzman.ParallelPortDataHandler;
using Heinzman.RaceActionSound;
using Heinzman.CarSound;
using Heinzman.RaceDataService.RaceData;
using Heinzman.PortDataParser;
using Heinzman.MockObjects;
using Heinzman.RaceDebugService;
using Heinzman.RaceSound;
using Heinzman.DomainModels;
using Heinzman.RaceOptionsService;
using Heinzman.Log;
using Heinzman.HelperClasses;
using Heinzman.RaceControlService;
using Heinzman.BusinessObjects.Options;
using Heinzman.RaceSoundService;
using Heinzman.RaceStatisticsService;
using Heinzman.ResourcesService;
using Heinzman.WindowsFormsApplication.FormMocks;
using Heinzman.WindowsFormsApplication.Forms;
using Heinzman.WindowsFormsPresenter;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectSound;
using Heinzman.RaceRecovery;
using Buffer = Microsoft.DirectX.DirectSound.Buffer;
using Form = System.Windows.Forms.Form;

namespace Heinzman.WindowsFormsApplication.Start
{
    public class Initializer
    {
        protected Form StartForm;
        protected readonly RaceModel RaceModel = new RaceModel();
        private ISerialPort _serialPort;
        private ISerialPort _vcuSerialPort;
        protected ISerialPortReader VcuSerialPortReader;
        protected ISerialPortWriter VcuSerialPortWriter;
        private ISerialPortReader _portReader;
        private IParallelPortReader _parallelPortReader;
        private DataParser _parallelPortParser;
        private ISerialPortParser _serialPortParser;
        private RaceDataProvider _raceDataProvider;
        private DriversService _driversService;
        private CarsService _carsService;
        private SoundOptionsService _soundOptionsService;
        private RaceKeyController _raceKeyController;
        private RaceSettingsService _raceSettingsService;
        private SerialPortService _serialPortService;
        protected VcuSerialPortService VcuSerialPortService;
        private ParallelPortService _parallelPortService;
        private RaceProviderService _raceProviderService;
        private ActionSoundsService _actionSoundsService;
        private CarSoundsService _carSoundsService;
        private ApplicationSettingsService _settingsService;
        private Device _device;
        private BufferDescription _bufferDescription;
        private readonly SoundMixerService _soundMixerService = new SoundMixerService();
        private MusicHandler _musicHandler;
        private IParallelPortWriter _parallelPortWriter;
        private IPortDataWriter _parallelPortDataWriter;
        private GhostcarsService _ghostcarsService;
        private StatisticLogger _statisticLogger;
        protected ICentralUnit CentralUnit;
        protected ICentralUnitOptionsService CentralUnitOptionsService;
        protected IArduinoWriter ArduinoWriter;
        private RaceDebugger _raceDebugger;

        [DllImport("user32.dll", SetLastError = false)]
        static extern IntPtr GetDesktopWindow();

        public virtual void StartApp()
        {
            try
            {
                InitErrorLogs();
                InitTracing();
                Application.ThreadException += new ThreadExceptionHandler().ApplicationThreadException;
                //SplashForm.ShowSplashScreen();
                SplashForm.SetStatus("Initialisieren...");
                Init();
                InitMusicHandlerAndPlay();
                SplashForm.SetStatus("Daten laden...");
                InitSoundDevice();
                InitBufferDescription();
                InitListener();
                InitActionSoundsService();
                InitCarSoundsService();
                InitRaceActionSound();
                InitRaceCarSound();
                InitLoggerModel();
                InitCountDownSoundHandler();
                InstantiateStartForm();
                CheckToInitCarSound3DTestForm();
                CheckIdsOfDriversAndCars();
                StartVcuSerialPortReader();
                StartForm.Show();
                SplashForm.SetStatus("Splash Form schlieﬂen...");
                SplashForm.CloseForm();
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

        private void StartVcuSerialPortReader()
        {
            try
            {
                if (Properties.Settings.Default.EnableCentralUnit)
                    VcuSerialPortReader.Start();

                if (Properties.Settings.Default.UseMockVcuSerialPortReader)
                {
                    SerialPortMockForm serialPortMockForm = new SerialPortMockForm(VcuSerialPortReader as SerialPortReaderMock);
                    serialPortMockForm.Show();
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, @"Central Unit Setup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorLog.LogError(false, ex);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
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
            if (Properties.Settings.Default.Tracing && !Properties.Settings.Default.TraceAutoFlush)
                Trace.Flush();
        }

        private void InitTracing()
        {
            try
            {
                if (Properties.Settings.Default.Tracing)
                {
                    string logFileName = @".\Logs\TraceLog_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
                    Trace.Listeners.Add(new TextWriterTraceListener(logFileName));
                    Trace.AutoFlush = Properties.Settings.Default.TraceAutoFlush;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void InitSoundDevice()
        {
            if (Properties.Settings.Default.SoundActivated)
            {
                DevicesCollection devicesCollection = new DevicesCollection();
                _device = new Device(devicesCollection[0].DriverGuid);
                _device.SetCooperativeLevel(FormHandle, CooperativeLevel.Priority);
            }
        }

        private void InitBufferDescription()
        {
            bool surroundSound = _raceSettingsService.RaceSettings.SurroundActivated;
            if (Properties.Settings.Default.SoundActivated || Properties.Settings.Default.MusicActivated)
                _bufferDescription = new BufferDescription
                                     {
                                         Control3D = surroundSound,
                                         ControlEffects = false,
                                         ControlPan = !surroundSound,
                                         ControlFrequency = true,
                                         ControlVolume = true,
                                         GlobalFocus = true
                                     };
        }

        protected virtual void InstantiateStartForm()
        {
            StartForm = new RaceControlForm(RaceModel, _portReader, _serialPortParser, _raceDataProvider,
                        _parallelPortReader, _parallelPortParser, _driversService,
                        _carsService, _ghostcarsService,
                        _soundOptionsService, _raceSettingsService, _raceKeyController,
                        _serialPortService, _parallelPortService, _settingsService,
                        _soundMixerService, _actionSoundsService, 
                        _statisticLogger, CentralUnit, ArduinoWriter,
                        VcuSerialPortService, VcuSerialPortReader, _raceDebugger);
        }

        private void CheckToInitCarSound3DTestForm()
        {
            if (Properties.Settings.Default.StartCarSound3DTest)
                ((CarSound3DTestForm) StartForm).CarSoundsService = _carSoundsService;
        }

        protected void Init()
        {
            InitSerialPortService();
            InitVcuSerialPortService();
            InitParallelPortService();
            InitRaceProviderService();
            InitParallelPortReader();
            CreateParallelPortWriter();
            InitParallelPortWriter();
            InitSerialPort();
            InitVcuSerialPort();
            InitSerialPortReader();
            InitVcuSerialPortReaderWriter();
            InitArduinoService();
            InitRaceSettingsService();
            CreateSerialPortParserByFactoryMethod();
            InitParallelPortParser();
            InitRaceDataProvider();
            InitDriversService();
            InitCarsService();
            InitGhostcarsService();
            InitSoundsService();
            InitRaceKeyController();
            InitCentralUnitOptionsService();
            InitRaceModel();
            InitCentralUnit();
            InitStatisticsService();
            InitRaceDebugger();
            InitReplayService();
            InitSettingsService();
            SendOptionsToArduino();
            SetLanguage();
            InitRocketHandler();
        }

        private void InitRocketHandler()
        {
            new RocketHandler(RaceModel, CentralUnitOptionsService.Options.RocketSettings);
        }

        private void InitArduinoService()
        {
            if (Properties.Settings.Default.EnableCentralUnit)
                ArduinoWriter = new ArduinoWriter(VcuSerialPortWriter);
            else
                ArduinoWriter = new MockArduinoWriter();
        }

        protected virtual void InitCentralUnitOptionsService()
        {
            CentralUnitOptionsService = new OptionsService();
            CentralUnitOptionsService.Options.EngineDamageSettings = _raceSettingsService.RaceSettings.EngineDamageSettings;
            CentralUnitOptionsService.Options.RocketSettings = _raceSettingsService.RaceSettings.RocketSettings;
        }

        protected virtual void InitCentralUnit()
        {
            if (Properties.Settings.Default.EnableCentralUnit)
                CentralUnit = new CentralUnit(RaceModel, CentralUnitOptionsService, ArduinoWriter, VcuSerialPortReader);
            else
                CentralUnit = new CentralUnitNullObject(new MockCentralUnitOptionsService());
        }

        private void SendOptionsToArduino()
        {
            try
            {
                ArduinoWriter.SendResetAll();
                CentralUnit.SendOptionsToArduino();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void InitStatisticsService()
        {
            _statisticLogger = new StatisticLogger(RaceModel) {Activated = true};
        }

        private void InitRaceDebugger()
        {
            _raceDebugger = new RaceDebugger(RaceModel); 
        }

        private void InitReplayService()
        {
            new ReplayService(RaceModel, _serialPortParser, ArduinoWriter, _ghostcarsService);
        }

        private void InitGhostcarsService()
        {
            _ghostcarsService = new GhostcarsService {IsActivated = Properties.Settings.Default.EnableGhostcars};
        }

        private void InitParallelPortWriter()
        {
            _parallelPortDataWriter = new DataWriter(_parallelPortWriter);
        }

        private void SetLanguage()
        {
            LanguageManager.LanguageType = _raceSettingsService.RaceSettings.LanguageType;
        }

        private void InitMusicHandlerAndPlay()
        {
            try
            {
                if (Properties.Settings.Default.MusicActivated)
                {
                    _musicHandler = new MusicHandler(RaceModel, _soundMixerService, _raceKeyController);
                    _musicHandler.SetMainPlayerAndPlay();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public static void InitErrorLogs()
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
                if (windowsIdentity != null)
                    userId = windowsIdentity.Name;
                return userId;
            }
        }

        private void InitSerialPortService()
        {
            _serialPortService = new SerialPortService();
        }

        private void InitVcuSerialPortService()
        {
            VcuSerialPortService = new VcuSerialPortService();
        }

        private void InitParallelPortService()
        {
            _parallelPortService = new ParallelPortService();
        }

        private void InitRaceProviderService()
        {
            _raceProviderService = new RaceProviderService();
        }

        private void InitSerialPort()
        {
            try
            {
                SerialPortCreator serialPortCreator = new SerialPortCreator(_serialPortService.SerialPortSettings);
                _serialPort = serialPortCreator.DoWork();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
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

        private void InitSerialPortReader()
        {
            try
            {
                SerialPortReaderCreator serialPortReaderCreator = new SerialPortReaderCreator(_serialPort, _parallelPortDataWriter);
                _portReader = serialPortReaderCreator.DoWork();
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
                SerialPortReader.SerialPortReaders.PortReaderWriter portReaderWriter = new SerialPortReader.SerialPortReaders.PortReaderWriter(_vcuSerialPort);
                VcuSerialPortWriter = portReaderWriter;

                if (Properties.Settings.Default.UseMockVcuSerialPortReader)
                    VcuSerialPortReader = new SerialPortReaderMock();
                else
                    VcuSerialPortReader = portReaderWriter;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void InitParallelPortReader()
        {
            try
            {
                CreateParallelPortReaderByFactoryMethod();
                _parallelPortReader.Start();
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
                LoggerModel.Inst.PortReader = _portReader;
                LoggerModel.Inst.SerialPortParser = _serialPortParser;
                LoggerModel.Inst.LoadData();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void CreateParallelPortReaderByFactoryMethod()
        {
            if (Properties.Settings.Default.UseMockParallelPortReader)
                _parallelPortReader = new MockParallelPortReader(_parallelPortService.ParallelPortSettings);
            else
                _parallelPortReader = new PortReader(_parallelPortService.ParallelPortSettings);
        }

        private void CreateParallelPortWriter()
        {
            if (Properties.Settings.Default.UseMockParallelPortWriter)
                _parallelPortWriter = new MockParallelPortWriter();
            else
                _parallelPortWriter = new PortWriter(_parallelPortService.ParallelPortSettings, false);
        }

        private void InitRaceKeyController()
        {
            KeySettings keySettings = new KeySettings();
            _raceKeyController = new RaceKeyController(RaceModel, keySettings);
        }

        private void CreateSerialPortParserByFactoryMethod()
        {
            if (Properties.Settings.Default.UseMockSerialPortParser)
            {
                _serialPortParser = new MockSerialPortParser();
                new ControllersMockPresenter(new ControllersMockForm(), _serialPortParser);
            }
            else
                _serialPortParser = new SerialPortParser(_portReader);
        }

        private void InitParallelPortParser()
        {
            _parallelPortParser = new DataParser(_parallelPortReader) { InputPin = _parallelPortService.ParallelPortSettings.InputPin };
        }

        private void InitRaceDataProvider()
        {
            _raceDataProvider = new RaceDataProvider(_serialPortParser, _raceProviderService, RaceModel);
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
                if (Properties.Settings.Default.SoundActivated)
                    _actionSoundsService = new ActionSoundsService(_soundOptionsService, _driversService, _device,
                                                                   _bufferDescription, SoundMixer,
                                                                   RaceModel);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void InitCarSoundsService()
        {
            try
            {
                if (Properties.Settings.Default.SoundActivated)
                    _carSoundsService = new CarSoundsService(_device, _bufferDescription, SoundMixer);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void InitSettingsService()
        {
            _settingsService = new ApplicationSettingsService();
        }

        private void InitRaceActionSound()
        {
            try
            {
                if (Properties.Settings.Default.SoundActivated)
                    new RaceActionSoundHandler(RaceModel, _actionSoundsService, _raceSettingsService.RaceSettings);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void InitRaceCarSound()
        {
            try
            {
                if (Properties.Settings.Default.SoundActivated)
                    new RaceCarSoundHandler(RaceModel, _raceSettingsService.RaceSettings, _carSoundsService);
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
                if (Properties.Settings.Default.SoundActivated)
                {
                    CountDownSoundHandler countDownSoundHandler = new CountDownSoundHandler(RaceModel, _device, SoundMixer);
                    countDownSoundHandler.Init();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void InitListener()
        {
            try
            {
                if (Properties.Settings.Default.SoundActivated)
                {
                    BufferDescription bufferDescription = new BufferDescription
                                                              {
                                                                  PrimaryBuffer = true,
                                                                  Control3D = true,
                                                                  ControlEffects = false,
                                                                  ControlPan = false,
                                                                  Mute3DAtMaximumDistance = true,
                                                                  StickyFocus = true
                                                              };
                    Listener3DOrientation orientation = new Listener3DOrientation
                                                            {
                                                                Front = new Vector3(0, 0, 5),
                                                                Top = new Vector3(0, 5, 0)
                                                            };
                    Buffer buffer = new Buffer(bufferDescription, _device);
                    new Listener3D(buffer) { Position = new Vector3(0, 0, 0), Orientation = orientation };
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void InitRaceModel()
        {
            RaceModel.SpeedSumAvgCalculator = new SpeedSumAvgCalculator();
            RaceModel.LapTimeAvgCalculator = new LapTimeAvgCalculator(_raceSettingsService.RaceSettings);
            RaceModel.RaceSettings = _raceSettingsService.RaceSettings;
            RaceModel.GhostcarsService = _ghostcarsService;
            RaceModel.CentralUnitOptions = CentralUnitOptionsService.Options;
            RaceModel.FuelConsumption.Options = CentralUnitOptionsService.Options;
        }

        private static IntPtr FormHandle
        {
            get { return GetDesktopWindow(); }
        }

        private SoundMixer SoundMixer
        {
            get { return _soundMixerService.SoundMixer; }
        }
    }
}
