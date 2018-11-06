using Elreg.BusinessObjects.Races;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedParameter.Local
namespace Elreg.UnitTests.CentralUnitTests.EngineDamage.AtMaxSpeed.InRace
{
    [TestFixture]
    public class When_it_is_activated : EngineDamageAtMaxSpeedBaseTest
    {
        [Test]
        public void SecsForDamagedEngineInMaxSpeed_should_be_between_0_and_SecsFor100PercentProbabilityMaxSpeed()
        {
            Probability_should_be_between_0_and_SecsFor100PercentProbabilityMaxSpeed();
        }

        [Test]
        public void And_ProbabilityOfSlowerCarsIsLess_Then_ForFirstCar_Secs_should_be_between_0_and_SecsFor100PercentProbabilityMaxSpeed()
        {
            StartRaceWithEngineDamageProbabilityOfSlowerCarsLess();

            float expectedMaxSecs = EngineDamageSettings.MaxSecsFor100PercentProbabilityMaxSpeed;
            int sumOfSecs = CalcSumOfSecsForDamagedEngineInMaxSpeed(expectedMaxSecs, Lane1);

            AssertDeltaSumOfSecs(sumOfSecs, expectedMaxSecs);
        }

        [Test]
        public void And_ProbabilityOfSlowerCarsIsLess_Then_ForThirdCar_Secs_should_be_multiplied_by_Factor_and_Position()
        {
            StartRaceWithEngineDamageProbabilityOfSlowerCarsLess();

            float expectedMaxSecs = EngineDamageSettings.MaxSecsFor100PercentProbabilityMaxSpeed * Lane3.Position * 
                                    EngineDamageSettings.FactorEngineDamageProbabilityOfSlowerCarsLess;
            int sumOfSecs = CalcSumOfSecsForDamagedEngineInMaxSpeed(expectedMaxSecs, Lane3);

            Assert.IsTrue(sumOfSecs >= 0);
            AssertDeltaSumOfSecs(sumOfSecs, expectedMaxSecs);
        }

        //[Test]
        //public void ProbabilityOfSlowerCars_should_increase_after_lanePosition_increased()
        //{
        //    StartRaceWithEngineDamageProbabilityOfSlowerCarsLess();

        //    EngineDamageHandler engineDamageHandler = new EngineDamageHandler(Lane3, _centralUnitOptionsService.Options.EngineDamageSettings, CompetitionType);
        //    engineDamageHandler.DoWork(0);

        //    int secsToDamageInThirdPosition = Lane3.SecsForDamagedEngineInMaxSpeed;
        //    WaitSecondsForValidLap();
        //    MockRaceDataProvider.RaiseAddLapForLane(Lane3.Id);
        //    WaitSecondsForValidLap();
        //    MockRaceDataProvider.RaiseAddLapForLane(Lane3.Id);
        //    Assert.AreEqual(1, Lane3.Position);
        //    engineDamageHandler.DoWork(0);
        //    int secsToDamageInFirstPosition = Lane3.SecsForDamagedEngineInMaxSpeed;
        //    WaitSecondsForValidLap();

        //    Assert.IsTrue(secsToDamageInFirstPosition < secsToDamageInThirdPosition);
        //}

        protected override Race.TypeEnum CompetitionType
        {
            get { return Race.TypeEnum.Race; }
        }
    }
}
