using Elreg.BusinessObjects.Races;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedParameter.Local
namespace Elreg.UnitTests.CentralUnitTests.EngineDamage.AtMaxSpeed.InQualification
{
    [TestFixture]
    public class When_it_is_activated : EngineDamageAtMaxSpeedBaseTest
    {
        [Test]
        public void And_ProbabilityOfSlowerCarsIsLess_Then_ForFirstCar_Secs_should_be_between_0_and_SecsFor100PercentProbabilityMaxSpeed()
        {
            Probability_should_be_between_0_and_SecsFor100PercentProbabilityMaxSpeed();
        }

        [Test]
        public void And_ProbabilityOfSlowerCarsIsLess_Then_ForThirdCar_Secs_should_be_between_0_and_SecsFor100PercentProbabilityMaxSpeed()
        {
            ProbabilityOfSlowerCarsIsLess_Then_ForThirdCar_Secs_should_be_between_0_and_SecsFor100PercentProbabilityMaxSpeed();
        }

        [Test]
        public void And_ProbabilityOfSlowerCars_must_not_increase_after_lanePosition_increased()
        {
            ProbabilityOfSlowerCars_must_not_increase_after_lanePosition_increased();
        }

        protected override Race.TypeEnum CompetitionType
        {
            get { return Race.TypeEnum.Qualification; }
        }

    }
}
