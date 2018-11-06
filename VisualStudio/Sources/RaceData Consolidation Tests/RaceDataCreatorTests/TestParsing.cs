using System;
using System.Collections.Generic;
using System.Xml;
using Elreg.RaceConsolidationService;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Elreg.UnitTests.RaceDataConsolidation.RaceDataCreatorTests
{
    [TestFixture]
    public class TestParsing
    {
        [Test]
        public void Test()
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"\TestData\RaceLog.txt";
            RaceDataCreator raceDataCreator = new RaceDataCreator(fileName);
            raceDataCreator.DoWork();
            Assert.IsTrue(raceDataCreator.RaceDataList.Count > 0);
        }

        [Test]
        public void Test2()
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"\TestData\RaceLog.txt";
            RaceDataCreator raceDataCreator = new RaceDataCreator(fileName);
            raceDataCreator.DoWork();

            LinearRaceDataCreator linearRaceDataModifier = new LinearRaceDataCreator(raceDataCreator.RaceDataList);
            linearRaceDataModifier.DoWork();

            Assert.IsTrue(linearRaceDataModifier.LinearRaceDataList.Count > 0);
        }

        [Test]
        public void Test3()
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"\TestData\RaceLog.txt";
            RaceDataCreator raceDataCreator = new RaceDataCreator(fileName);
            raceDataCreator.DoWork();

            LinearRaceDataCreator linearRaceDataModifier = new LinearRaceDataCreator(raceDataCreator.RaceDataList);
            linearRaceDataModifier.DoWork();

            RaceDataDictCreator raceDataDictCreator = new RaceDataDictCreator(linearRaceDataModifier.LinearRaceDataList);
            raceDataDictCreator.DoWork();

            Assert.AreEqual(1, raceDataDictCreator.RaceDataDict.Count);
            Assert.IsTrue(raceDataDictCreator.RaceDataDict[0].Value.Count > 0);
        }

        [Test]
        public void Test4()
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"\TestData\RaceLog.txt";
            RaceDataCreator raceDataCreator = new RaceDataCreator(fileName);
            raceDataCreator.DoWork();

            LinearRaceDataCreator linearRaceDataModifier = new LinearRaceDataCreator(raceDataCreator.RaceDataList);
            linearRaceDataModifier.DoWork();

            RaceDataDictCreator raceDataDictCreator = new RaceDataDictCreator(linearRaceDataModifier.LinearRaceDataList);
            raceDataDictCreator.DoWork();

            List<LinearRaceData> raceDataList = raceDataDictCreator.RaceDataDict[0].Value;
            RaceDataTableCreator raceDataTableCreator = new RaceDataTableCreator(raceDataList, true, true);
            raceDataTableCreator.CreateForDiagram();

            Assert.IsTrue(raceDataTableCreator.RaceDataTable != null && raceDataTableCreator.RaceDataTable.Rows.Count > 0);

        }
    }
}
