using System;
using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Lanes;
using Elreg.Log;
using Elreg.RaceSound.Interfaces;
using Elreg.RaceSound.Sound3D;
using Elreg.RaceSoundService;
using Microsoft.DirectX;

namespace Elreg.CarSound.Test
{
    public class RaceCarSoundTestHandler
    {
        private readonly string _soundFilename;
        private readonly CarSoundsService _carSoundsService;
        private readonly List<RaceCarSoundTestPlayer> _raceCarSoundTestPlayers = new List<RaceCarSoundTestPlayer>();

        public RaceCarSoundTestHandler(string soundFilename, CarSoundsService carSoundsService)
        {
            _soundFilename = soundFilename;
            _carSoundsService = carSoundsService;
        }

        public void CreateRaceCarSoundPlayers(List<Lane> lanes)
        {
            _raceCarSoundTestPlayers.Clear();
            IPosition3DCreator position3DCreator = new Position3DCreatorLinear(lanes, AddRaceCarSoundTestPlayer);
            position3DCreator.Create();
        }

        private void AddRaceCarSoundTestPlayer(Vector3 position, LaneId laneId)
        {
            try
            {
                RaceCarSoundTestPlayer raceCarSoundTestPlayer = new RaceCarSoundTestPlayer(laneId, _soundFilename, position, _carSoundsService);
                _raceCarSoundTestPlayers.Add(raceCarSoundTestPlayer);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void Activate(LaneId laneId)
        {
            RaceCarSoundTestPlayer raceCarSoundTestPlayer = _raceCarSoundTestPlayers.Find(foundRaceCarSound => foundRaceCarSound.LaneId == laneId);

            if (raceCarSoundTestPlayer != null)
                raceCarSoundTestPlayer.Activate();
        }

        public void DeactivateAll()
        {
            foreach (RaceCarSoundTestPlayer raceCarSoundTestPlayer in _raceCarSoundTestPlayers)
                raceCarSoundTestPlayer.Deactivate();
        }
    }
}
