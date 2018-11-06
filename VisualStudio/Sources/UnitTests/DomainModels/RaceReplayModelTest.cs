using System;
using System.IO;
using System.Reflection;
using System.Threading;
using Elreg.DomainModels.RaceReplay;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels
{
    [TestFixture]
    public class RaceReplayModelTest
    {
        [Test]
        public void TestInitRaceIsStatusInitializedIfWasNotDefined()
        {
            var assemblyFileName = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            var path = Path.GetDirectoryName(assemblyFileName);
            string fileName = path + @"\TestData\RaceReplayLog.txt";

            RaceReplayModel raceReplayModel = new RaceReplayModel(fileName);
            raceReplayModel.ParseFile();
            raceReplayModel.CreateRaceReplayTableFile(); 
            Thread.Sleep(1000);
        }

    }
}
