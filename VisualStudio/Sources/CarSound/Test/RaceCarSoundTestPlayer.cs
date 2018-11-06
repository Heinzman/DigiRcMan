using System;
using Elreg.BusinessObjects;
using Elreg.Log;
using Elreg.RaceSound.Sound3D;
using Elreg.RaceSoundService;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectSound;

namespace Elreg.CarSound.Test
{
    public class RaceCarSoundTestPlayer 
    {
        private readonly LaneId _laneId;
        private SecondaryBuffer _bufferRunningEngine;
        private readonly string _soundEngineFilename;
        private readonly Vector3 _position;
        private readonly CarSoundsService _carSoundsService;

        public RaceCarSoundTestPlayer(LaneId laneId, string soundEngineFilename, Vector3 position, CarSoundsService carSoundsService)
        {
            _laneId = laneId;
            _soundEngineFilename = soundEngineFilename;
            _position = position;
            _carSoundsService = carSoundsService;
            InitSoundBuffers();
        }

        public LaneId LaneId
        {
            get { return _laneId; }
        }

        public void Deactivate()
        {
            if (_bufferRunningEngine != null)
                _bufferRunningEngine.Stop();
        }

        public void Activate()
        {
            if (_bufferRunningEngine != null)
                _bufferRunningEngine.Play(0, BufferPlayFlags.Looping);
        }

        private void InitSoundBuffers()
        {
            CreateBufferRunningEngine();
            if (_bufferRunningEngine != null)
                Sound3DHelper.AssignBuffer3DTo(_bufferRunningEngine, _position);
        }

        private void CreateBufferRunningEngine()
        {
            try
            {
                _bufferRunningEngine = new SecondaryBuffer(_soundEngineFilename, _carSoundsService.BufferDescription, _carSoundsService.Device);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }
    }
}
