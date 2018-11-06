using Elreg.BusinessObjects.Sound;
using Elreg.RaceOptionsService;
using Elreg.RaceSoundService;
using Elreg.UnitTests.TestHelper;
using Microsoft.DirectX.DirectSound;
using NUnit.Framework;

namespace Elreg.UnitTests.RaceActionSoundTests.RaceActionSoundHandlerTests
{
    [TestFixture]
    public class RaceActionSoundHandlerTest : BaseLapTest
    {
        private ActionSoundsService _actionSoundsService;
        private Device _device;
        private BufferDescription _bufferDescription;

        [Test]
        public void TestLowFuelDetectedSoundListHandlerShouldHaveBufferSounds()
        {
            // todo
            //CreateActionSoundsService();
            //RaceActionSoundHandler_Accessor raceActionSoundHandlerAccessor = new RaceActionSoundHandler_Accessor(RaceModel, _actionSoundsService, RaceSettings);
            //StartRace();
            //const LaneId laneId1 = LaneId.Lane1;
            //SoundListHandler soundListHandler = DetermineCurrentSoundListHandlerBy(laneId1, raceActionSoundHandlerAccessor);
            //Assert.IsTrue(soundListHandler.BufferSounds.Count == 0);
            //raceActionSoundHandlerAccessor.LowFuelDetected(laneId1);
            //Assert.IsTrue(soundListHandler.BufferSounds.Count > 0);
        }

        //private SoundListHandler DetermineCurrentSoundListHandlerBy(LaneId laneId, RaceActionSoundHandler_Accessor raceActionSoundHandlerAccessor)
        //{
        //    SoundListHandler soundListHandler;
        //    raceActionSoundHandlerAccessor._soundListHandlers.TryGetValue(laneId, out soundListHandler);
        //    return soundListHandler;
        //}

        private void CreateActionSoundsService()
        {
            CreateDevice();
            CreateBufferDescription();
            SoundOptionsService soundOptionsService = new SoundOptionsService();
            DriversService driversService = new DriversService();

            _actionSoundsService = new ActionSoundsService(soundOptionsService, driversService, _device,
                                                           _bufferDescription, SoundMixer,
                                                           RaceModel);
        }

        private void CreateDevice()
        {
            DevicesCollection devicesCollection = new DevicesCollection();
            _device = new Device(devicesCollection[0].DriverGuid);
        }

        private void CreateBufferDescription()
        {
            _bufferDescription = new BufferDescription
            {
                Control3D = true,
                ControlEffects = false,
                ControlPan = false,
                ControlFrequency = true,
                ControlVolume = true,
                GlobalFocus = true
            };
        }

        private SoundMixer SoundMixer
        {
            get
            {
                SoundMixerService soundMixerService = new SoundMixerService();
                return soundMixerService.SoundMixer;
            }
        }

    }
}
