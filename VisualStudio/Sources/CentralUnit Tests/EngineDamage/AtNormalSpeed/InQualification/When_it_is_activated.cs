using Elreg.BusinessObjects.Races;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedParameter.Local
namespace Elreg.UnitTests.CentralUnitTests.EngineDamage.AtNormalSpeed.InQualification
{
    [TestFixture]
    public class When_it_is_activated : EngineDamageAtNormalSpeedBaseTest
    {
        [Test]
        public void And_ProbabilityOfSlowerCarsIsLess_Then_ForFirstCar_Secs_should_be_between_0_and_SecsFor100PercentProbabilityNormalSpeed()
        {
            Probability_should_be_between_0_and_SecsFor100PercentProbabilityNormalSpeed();
        }

        [Test]
        public void And_ProbabilityOfSlowerCarsIsLess_Then_ForThirdCar_Secs_should_be_between_0_and_SecsFor100PercentProbabilityNormalSpeed()
        {
            ProbabilityOfSlowerCarsIsLess_Then_ForThirdCar_Secs_should_be_between_0_and_SecsFor100PercentProbabilityNormalSpeed();
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
