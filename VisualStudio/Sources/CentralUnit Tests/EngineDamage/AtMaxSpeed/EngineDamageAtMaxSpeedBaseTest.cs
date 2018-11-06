using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Options;
using Elreg.BusinessObjects.Races;
using Elreg.CentralUnitService.Settings;
using Elreg.DomainModels.RaceModel.LaneModel;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Elreg.UnitTests.CentralUnitTests.EngineDamage.AtMaxSpeed
{
    [TestFixture]
    public abstract class EngineDamageAtMaxSpeedBaseTest : CentralUnitBaseTest
    {
        const int iterations = 100000;

        protected void Probability_should_be_between_0_and_SecsFor100PercentProbabilityMaxSpeed()
        {
            StartRaceWithEngineDamageProbabilityOfSlowerCarsLess();

            float expectedMaxSecs = EngineDamageSettings.MaxSecsFor100PercentProbabilityMaxSpeed;
            int sumOfSecs = CalcSumOfSecsForDamagedEngineInMaxSpeed(expectedMaxSecs, Lane1);

            AssertDeltaSumOfSecs(sumOfSecs, expectedMaxSecs);
        }

        protected void ProbabilityOfSlowerCarsIsLess_Then_ForThirdCar_Secs_should_be_between_0_and_SecsFor100PercentProbabilityMaxSpeed()
        {
            StartRaceWithEngineDamageProbabilityOfSlowerCarsLess();

            float expectedMaxSecs = EngineDamageSettings.MaxSecsFor100PercentProbabilityMaxSpeed;
            int sumOfSecs = CalcSumOfSecsForDamagedEngineInMaxSpeed(expectedMaxSecs, Lane3);

            Assert.IsTrue(sumOfSecs >= 0);
            AssertDeltaSumOfSecs(sumOfSecs, expectedMaxSecs);
        }

        protected void ProbabilityOfSlowerCars_must_not_increase_after_lanePosition_increased()
        {
            StartRaceWithEngineDamageProbabilityOfSlowerCarsLess();

            EngineDamageHandler engineDamageHandler = new EngineDamageHandler(Lane3, _centralUnitOptionsService.Options.EngineDamageSettings, CompetitionType);
            engineDamageHandler.DoWork(0);

            int secsToDamageInThirdPosition = Lane3.SecsForDamagedEngineInMaxSpeed;
            WaitSecondsForValidLap();
            MockRaceDataProvider.RaiseAddLapForLane(Lane3.Id);
            WaitSecondsForValidLap();
            MockRaceDataProvider.RaiseAddLapForLane(Lane3.Id);
            WaitSecondsForValidLap();
            Assert.AreEqual(1, Lane3.Position);
            engineDamageHandler.DoWork(0);
            int secsToDamageInFirstPosition = Lane3.SecsForDamagedEngineInMaxSpeed;

            Assert.IsTrue(secsToDamageInFirstPosition == secsToDamageInThirdPosition);
        }


        protected override void InitCentralUnitOptionsService()
        {
            _centralUnitOptionsService.Options = new Options
            {
                IsCentralUnitActivated = true,
                TurboOptions = new TurboSettings { IsActivated = false },
                StutterOptions = new StutterSettings { IsActivated = false, PercentFuelForStuttering = 10 },
                DelayOptions = new DelaySettings { IsActivated = false, PercentFuelForZeroDelay = 20 },
                EngineDamageSettings = new EngineDamageSettings
                {
                    IsActivated = true,
                    IsActivatedDamageAtMaxSpeed = true,
                    IsActivatedDamageAtNormalSpeed = false,
                    EngineDamageProbabilityOfSlowerCars = RaceSettings.EngineDamageProbabilityOfSlowerCars.Equal
                }
            };
        }

        protected int CalcSumOfSecsForDamagedEngineInMaxSpeed(float expectedMaxSecs, Lane lane)
        {
            int sumOfSecs = 0;
            for (int i = 0; i < iterations; i++)
            {
                EngineDamageHandler engineDamageHandler = new EngineDamageHandler(lane, _centralUnitOptionsService.Options.EngineDamageSettings, CompetitionType);
                engineDamageHandler.DoWork(0);
                sumOfSecs = lane.SecsForDamagedEngineInMaxSpeed;
                Assert.IsTrue(lane.SecsForDamagedEngineInMaxSpeed >= 0);
                Assert.IsTrue(lane.SecsForDamagedEngineInMaxSpeed <= expectedMaxSecs);
            }
            return sumOfSecs;
        }

        protected static void AssertDeltaSumOfSecs(int sumOfSecs, float expectedMaxSecs)
        {
            Assert.IsTrue(sumOfSecs < expectedMaxSecs);
        }


        protected EngineDamageSettings EngineDamageSettings
        {
            get { return _centralUnitOptionsService.Options.EngineDamageSettings; }
        }


        protected void StartRaceWithEngineDamageProbabilityOfSlowerCarsLess()
        {
            EngineDamageSettings.EngineDamageProbabilityOfSlowerCars = RaceSettings.EngineDamageProbabilityOfSlowerCars.Less;
            EngineDamageSettings.SecsToSpareDamageAfterPositionChange = 0.001m;
            EngineDamageSettings.IsCurrentDamageAdjustedAfterPositionChange = true;
            StartCompetition(CompetitionType);
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            MockRaceDataProvider.RaiseAddLapForLane(Lane2.Id);
            MockRaceDataProvider.RaiseAddLapForLane(Lane3.Id);
        }

        protected abstract Race.TypeEnum CompetitionType { get; }

    }
}
