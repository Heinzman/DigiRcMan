using System;
using System.Collections.Generic;
using Elreg.ArduinoService;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Moq;
using NUnit.Framework;

namespace Elreg.UnitTests.CentralUnitTests.ArduinoReaderTests
{
    [TestFixture]
    public class TestUpperButtonClicks
    {
        private bool _isRaisedUpperButtonClicked;
        private readonly List<LaneId> _raisedLaneIds = new List<LaneId>();

        [Test]
        public void TestUpperButtonClickOfLane1()
        {
            TestUpperButtonClickOf(LaneId.Lane1, "E8 01 ");
        }

        [Test]
        public void TestUpperButtonClickOfLane2()
        {
            TestUpperButtonClickOf(LaneId.Lane2, "E8 21 ");
        }

        [Test]
        public void TestUpperButtonClickOfLane3()
        {
            TestUpperButtonClickOf(LaneId.Lane3, "E8 41 ");
        }

        [Test]
        public void TestUpperButtonClickOfLane4()
        {
            TestUpperButtonClickOf(LaneId.Lane4, "E8 61 ");
        }

        [Test]
        public void TestUpperButtonClickOfLane5()
        {
            TestUpperButtonClickOf(LaneId.Lane5, "E8 81 ");
        }

        [Test]
        public void TestUpperButtonClickOfLane6()
        {
            TestUpperButtonClickOf(LaneId.Lane6, "E8 A1 ");
        }

        [Test]
        public void TestUpperButtonClickOfSeveralLanes()
        {
            const string data = "E8 01 E8 21 E8 41 E8 61 E8 81 E8 A1 ";

            _isRaisedUpperButtonClicked = false;
            _raisedLaneIds.Clear();

            Mock<ISerialPortReader> serialPortReaderMock = new Mock<ISerialPortReader>();
            ArduinoReader arduinoReader = new ArduinoReader(serialPortReaderMock.Object);
            arduinoReader.UpperButtonClicked += ArduinoReaderUpperButtonClicked;

            arduinoReader.SerialPortDataReceived(null, data, new DateTime());

            Assert.IsTrue(_isRaisedUpperButtonClicked);
            Assert.AreEqual(LaneId.Lane1, _raisedLaneIds[0]);
            Assert.AreEqual(LaneId.Lane2, _raisedLaneIds[1]);
            Assert.AreEqual(LaneId.Lane3, _raisedLaneIds[2]);
            Assert.AreEqual(LaneId.Lane4, _raisedLaneIds[3]);
            Assert.AreEqual(LaneId.Lane5, _raisedLaneIds[4]);
            Assert.AreEqual(LaneId.Lane6, _raisedLaneIds[5]);
        }

        [Test]
        public void TestUpperButtonClickOfSeveralLanesSplittedData()
        {
            const string data1 = "E8 01 E8 ";
            const string data2 = "21 E8 41 E8 61 E8 ";
            const string data3 = "81 E8 A1 ";

            _isRaisedUpperButtonClicked = false;
            _raisedLaneIds.Clear();

            Mock<ISerialPortReader> serialPortReaderMock = new Mock<ISerialPortReader>();
            ArduinoReader arduinoReader = new ArduinoReader(serialPortReaderMock.Object);
            arduinoReader.UpperButtonClicked += ArduinoReaderUpperButtonClicked;

            arduinoReader.SerialPortDataReceived(null, data1, new DateTime());
            arduinoReader.SerialPortDataReceived(null, data2, new DateTime());
            arduinoReader.SerialPortDataReceived(null, data3, new DateTime());

            Assert.IsTrue(_isRaisedUpperButtonClicked);
            Assert.AreEqual(LaneId.Lane1, _raisedLaneIds[0]);
            Assert.AreEqual(LaneId.Lane2, _raisedLaneIds[1]);
            Assert.AreEqual(LaneId.Lane3, _raisedLaneIds[2]);
            Assert.AreEqual(LaneId.Lane4, _raisedLaneIds[3]);
            Assert.AreEqual(LaneId.Lane5, _raisedLaneIds[4]);
            Assert.AreEqual(LaneId.Lane6, _raisedLaneIds[5]);
        }

        private void TestUpperButtonClickOf(LaneId expectedLaneId, string data)
        {
            _isRaisedUpperButtonClicked = false;
            _raisedLaneIds.Clear();

            Mock<ISerialPortReader> serialPortReaderMock = new Mock<ISerialPortReader>();
            ArduinoReader arduinoReader = new ArduinoReader(serialPortReaderMock.Object);
            arduinoReader.UpperButtonClicked += ArduinoReaderUpperButtonClicked;

            arduinoReader.SerialPortDataReceived(null, data, new DateTime());

            Assert.IsTrue(_isRaisedUpperButtonClicked);
            Assert.AreEqual(expectedLaneId, _raisedLaneIds[0]);
        }

        private void ArduinoReaderUpperButtonClicked(object sender, LaneId laneId)
        {
            _isRaisedUpperButtonClicked = true;
            _raisedLaneIds.Add(laneId);
        }
    }
}
