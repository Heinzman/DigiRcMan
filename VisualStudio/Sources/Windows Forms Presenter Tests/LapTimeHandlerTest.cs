using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.UnitTests.TestHelper;
using Elreg.WindowsFormsPresenter.RaceGrid.LapTime;
using Elreg.WindowsFormsView;
using NUnit.Framework;

namespace Elreg.UnitTests.WindowsFormsPresenter
{
    public class LapTimeHandlerTest : BaseLapTest
    {
        // todo
        //private LapTimeHandler_Accessor _lapTimeHandlerAccessor;
        //private IRaceGridPresenter _raceGridPresenter;

        //[Test]
        //public void TestAutoDetectedLapCheckBackcolor()
        //{
        //    InitLapTimeHandler();
        //    StartRace();
        //    _lapTimeHandlerAccessor.AutoDetectedLapAdded(LaneId.Lane1);
        //    // todo
        //    //Color backcolorExpected = _lapTimeHandlerAccessor.GetBackgroundColorForAutoDetectedLap();
        //    //Color backcolorActual = _lapTimeHandlerAccessor._backgroundColor;

        //    //Assert.AreEqual(backcolorExpected, backcolorActual);
        //}

        //[Test]
        //public void TestLapNotAddedDueMinSecondsAfterAutoDetectedLapCheckBackcolor()
        //{
        //    InitLapTimeHandler();
        //    StartRace();
        //    AddRegularLapAndWaitValidSeconds();
        //    AutoDetectLap();
        //    _lapTimeHandlerAccessor.AutoDetectedLapAdded(LaneId.Lane1);
        //    _lapTimeHandlerAccessor.LapNotAddedDueMinSeconds(LaneId.Lane1);
        //    // todo
        //    //Color backcolorExpected = _lapTimeHandlerAccessor.GetBackgroundColorForLapNotAddedDueMinSecondsAfterAutoDetectedLap();
        //    //Color backcolorActual = _lapTimeHandlerAccessor._backgroundColor;

        //    //Assert.AreEqual(backcolorExpected, backcolorActual);
        //}

        //private void InitLapTimeHandler()
        //{
        //    IRaceGridView raceGridView = new MockRaceGridView();
        //    _raceGridPresenter = new MockRaceGridPresenter();
        //    _lapTimeHandlerAccessor = new LapTimeHandler_Accessor(RaceModel, raceGridView, _raceGridPresenter);
        //}

    }
}
