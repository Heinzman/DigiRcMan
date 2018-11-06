using System;
using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Races;
using Elreg.Exceptions;
using Elreg.HelperClasses;
using NUnit.Framework;
using Elreg.DomainModels.RaceModel;

namespace Elreg.UnitTests.DomainModels
{
    [TestFixture]
    public class RaceModelTest
    {
        private RaceModel _raceModel;
        private List<InitialLane> _initialLanes;

        [SetUp]
        public void StartUp()
        {
            CreateRaceModel();
        }

        [Test]
        public void TestInitRaceIsStatusInitializedIfWasNotDefined()
        {
            CreateInitialLanes();
            _raceModel.InitialLanes = _initialLanes;
            _raceModel.InitRace();

            Assert.IsTrue(_raceModel.Race.Status == Race.StatusEnum.Initialized);
        }

        [Test]
        public void TestInitRaceIsChangedAfterTwiceInits()
        {
            CreateInitialLanes();
            _raceModel.InitialLanes = _initialLanes;
            _raceModel.InitRace();

            CreateInitialLanes();
            const float changedTankMaximumInLitres = 50f;
            _initialLanes[0].Car.TankMaximumInLitres = changedTankMaximumInLitres;
            _raceModel.InitialLanes = _initialLanes;
            _raceModel.InitRace();

            Assert.IsTrue(_raceModel.Race.Status == Race.StatusEnum.Initialized);
            Assert.IsTrue(Math.Abs(_raceModel.Race.Lanes[0].Car.TankMaximumInLitres - changedTankMaximumInLitres) < SystemHelper.Epsilon);
        }

        [Test, ExpectedException(typeof(LcException))]
        public void TestInitRaceThrowExceptionIfInitialLanesAreNull()
        {
            _raceModel.InitialLanes = null;
            _raceModel.InitRace();
        }

        [Test, ExpectedException(typeof(LcException))]
        public void TestInitRaceThrowExceptionIfRaceStatusIsStarted()
        {
            TestInitRaceThrowExceptionIfRaceStatusIs(Race.StatusEnum.Started);
        }

        [Test, ExpectedException(typeof(LcException))]
        public void TestInitRaceThrowExceptionIfRaceStatusIsPaused()
        {
            TestInitRaceThrowExceptionIfRaceStatusIs(Race.StatusEnum.PausedByKeyboard);
        }

        [Test, ExpectedException(typeof(LcException))]
        public void TestInitRaceThrowExceptionIfRaceStatusIsPausedByParallelPort()
        {
            TestInitRaceThrowExceptionIfRaceStatusIs(Race.StatusEnum.PausedByParallelPort);
        }

        [Test, ExpectedException(typeof(LcException))]
        public void TestInitRaceThrowExceptionIfRaceStatusIsRestartCountDown()
        {
            TestInitRaceThrowExceptionIfRaceStatusIs(Race.StatusEnum.RestartCountDown);
        }

        [Test, ExpectedException(typeof(LcException))]
        public void TestInitRaceThrowExceptionIfRaceStatusIsStartCountDown()
        {
            TestInitRaceThrowExceptionIfRaceStatusIs(Race.StatusEnum.StartCountDown);
        }

        [Test, ExpectedException(typeof(LcException))]
        public void TestInitRaceThrowExceptionIfRaceStatusIsWaitingForStartByParallelPort()
        {
            TestInitRaceThrowExceptionIfRaceStatusIs(Race.StatusEnum.WaitingForStartByParallelPort);
        }

        private void TestInitRaceThrowExceptionIfRaceStatusIs(Race.StatusEnum status)
        {
            CreateInitialLanes();
            _raceModel.InitialLanes = _initialLanes;
            _raceModel.InitRace();

            _raceModel.Race.Status = status;
            _raceModel.InitRace();
        }

        private void CreateInitialLanes()
        {
            _initialLanes = new List<InitialLane>();
            Driver driver1 = new Driver { Name = "Driver1", Id = 1 };
            Driver driver2 = new Driver { Name = "Driver2", Id = 2 };
            Car car1 = new Car { Name = "Car1", Id = 1 };
            Car car2 = new Car { Name = "Car2", Id = 2 };
            const float tankMaximumInLitres = 100f;
            const float fuelconsumptionFactor = 1f;
            _initialLanes.Add(new InitialLane(LaneId.Lane1, tankMaximumInLitres, fuelconsumptionFactor, driver1, car1));
            _initialLanes.Add(new InitialLane(LaneId.Lane2, tankMaximumInLitres, fuelconsumptionFactor, driver2, car2));
        }

        private void CreateRaceModel()
        {
            _raceModel = new RaceModel();
        }
    }
}
