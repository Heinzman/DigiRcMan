using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Races.Types;
using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Elreg.UnitTests.DomainModels.RacesTests
{
    [TestFixture]
    public class CompetitionTests : BaseLapTest
    {
        private delegate void CreateInitialLanesFunc();

        private CreateInitialLanesFunc _createInitialLanesFunc;

        [Test]
        public void WhenNoInitialPositionsExistThenOrderShouldBeById()
        {
            _createInitialLanesFunc = CreateInitialLanesWithCountOf6;
            StartRace();

            Competition competition = new Competition(RaceModel.Race);
            competition.OrderByPosition();

            Assert.AreEqual(LaneId.Lane1, RaceModel.Race.Lanes[0].Id);
            Assert.AreEqual(LaneId.Lane2, RaceModel.Race.Lanes[1].Id);
            Assert.AreEqual(LaneId.Lane3, RaceModel.Race.Lanes[2].Id);
            Assert.AreEqual(LaneId.Lane4, RaceModel.Race.Lanes[3].Id);
            Assert.AreEqual(LaneId.Lane5, RaceModel.Race.Lanes[4].Id);
            Assert.AreEqual(LaneId.Lane6, RaceModel.Race.Lanes[5].Id);
        }

        [Test]
        public void WhenInitialPositionsExistThenOrderShouldBeByInitialPositions()
        {
            _createInitialLanesFunc = CreateInitialLanesWithCountOf6;
            StartRace();
            LoadPositions();

            Competition competition = new Competition(RaceModel.Race);
            competition.OrderByPosition();

            Assert.AreEqual(LaneId.Lane1, RaceModel.Race.Lanes[5].Id);
            Assert.AreEqual(LaneId.Lane2, RaceModel.Race.Lanes[4].Id);
            Assert.AreEqual(LaneId.Lane3, RaceModel.Race.Lanes[3].Id);
            Assert.AreEqual(LaneId.Lane4, RaceModel.Race.Lanes[2].Id);
            Assert.AreEqual(LaneId.Lane5, RaceModel.Race.Lanes[1].Id);
            Assert.AreEqual(LaneId.Lane6, RaceModel.Race.Lanes[0].Id);
        }

        [Test]
        public void When3LanesAndInitialPositionsExistThenOrderShouldBeByInitialPositions()
        {
            _createInitialLanesFunc = CreateInitialLanesWithCountOf3;
            StartRace();
            LoadPositions();

            Competition competition = new Competition(RaceModel.Race);
            competition.OrderByPosition();

            Assert.AreEqual(LaneId.Lane1, RaceModel.Race.Lanes[2].Id);
            Assert.AreEqual(LaneId.Lane2, RaceModel.Race.Lanes[1].Id);
            Assert.AreEqual(LaneId.Lane3, RaceModel.Race.Lanes[0].Id);
        }

        private void LoadPositions()
        {
            int position = RaceModel.Race.Lanes.Count;
            foreach (Lane lane in RaceModel.Race.Lanes)
                lane.Position = position--;
        }

        protected override void CreateInitialLanes()
        {
            _createInitialLanesFunc();
        }

        private void CreateInitialLanesWithCountOf3()
        {
            CreateInitialLanesWithCountOf(3);
        }

        private void CreateInitialLanesWithCountOf6()
        {
            CreateInitialLanesWithCountOf(6);
        }

        private void CreateInitialLanesWithCountOf(int count)
        {
            const float tankMaximumInLitres = 100f;
            const float fuelconsumptionFactor = 1f;

            InitialLanes = new List<InitialLane>();

            for (int id = 0; id < count; id++)
            {
                Driver driver = CreateNewDriver(id);
                Car car = CreateNewCar(id);
                InitialLanes.Add(new InitialLane((LaneId)id, tankMaximumInLitres, fuelconsumptionFactor, driver, car));
            }
        }
    }
}
