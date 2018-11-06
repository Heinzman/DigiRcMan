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
    public class TestPauseOrRestartRequested
    {
        private bool _isRaisedPauseOrRestartRequested;
        private readonly List<LaneId> _raisedLaneIds = new List<LaneId>();

        [Test]
        public void TestPauseOrRestartRequestedOfLane1()
        {
            TestPauseOrRestartRequestedOf(LaneId.Lane1, "E8 02 ");
        }

        [Test]
        public void TestPauseOrRestartRequestedOfLane2()
        {
            TestPauseOrRestartRequestedOf(LaneId.Lane2, "E8 22 ");
        }

        [Test]
        public void TestPauseOrRestartRequestedOfLane3()
        {
            TestPauseOrRestartRequestedOf(LaneId.Lane3, "E8 42 ");
        }

        [Test]
        public void TestPauseOrRestartRequestedOfLane4()
        {
            TestPauseOrRestartRequestedOf(LaneId.Lane4, "E8 62 ");
        }

        [Test]
        public void TestPauseOrRestartRequestedOfLane5()
        {
            TestPauseOrRestartRequestedOf(LaneId.Lane5, "E8 82 ");
        }

        [Test]
        public void TestPauseOrRestartRequestedOfLane6()
        {
            TestPauseOrRestartRequestedOf(LaneId.Lane6, "E8 A2 ");
        }

        [Test]
        public void TestPauseOrRestartRequestedOfSeveralLanes()
        {
            const string data = "E8 02 E8 22 E8 42 E8 62 E8 82 E8 A2 ";

            _isRaisedPauseOrRestartRequested = false;
            _raisedLaneIds.Clear();

            Mock<ISerialPortReader> serialPortReaderMock = new Mock<ISerialPortReader>();
            ArduinoReader arduinoReader = new ArduinoReader(serialPortReaderMock.Object);
            arduinoReader.PauseOrRestartRequested += ArduinoReaderPauseOrRestartRequesteded;

            arduinoReader.SerialPortDataReceived(null, data, new DateTime());

            Assert.IsTrue(_isRaisedPauseOrRestartRequested);
            Assert.AreEqual(LaneId.Lane1, _raisedLaneIds[0]);
            Assert.AreEqual(LaneId.Lane2, _raisedLaneIds[1]);
            Assert.AreEqual(LaneId.Lane3, _raisedLaneIds[2]);
            Assert.AreEqual(LaneId.Lane4, _raisedLaneIds[3]);
            Assert.AreEqual(LaneId.Lane5, _raisedLaneIds[4]);
            Assert.AreEqual(LaneId.Lane6, _raisedLaneIds[5]);
        }

        [Test]
        public void TestPauseOrRestartRequestedOfSeveralLanesSplittedData()
        {
            const string data1 = "E8 02 E8 ";
            const string data2 = "22 E8 42 E8 62 E8 ";
            const string data3 = "82 E8 A2 ";

            _isRaisedPauseOrRestartRequested = false;
            _raisedLaneIds.Clear();

            Mock<ISerialPortReader> serialPortReaderMock = new Mock<ISerialPortReader>();
            ArduinoReader arduinoReader = new ArduinoReader(serialPortReaderMock.Object);
            arduinoReader.PauseOrRestartRequested += ArduinoReaderPauseOrRestartRequesteded;

            arduinoReader.SerialPortDataReceived(null, data1, new DateTime());
            arduinoReader.SerialPortDataReceived(null, data2, new DateTime());
            arduinoReader.SerialPortDataReceived(null, data3, new DateTime());

            Assert.IsTrue(_isRaisedPauseOrRestartRequested);
            Assert.AreEqual(LaneId.Lane1, _raisedLaneIds[0]);
            Assert.AreEqual(LaneId.Lane2, _raisedLaneIds[1]);
            Assert.AreEqual(LaneId.Lane3, _raisedLaneIds[2]);
            Assert.AreEqual(LaneId.Lane4, _raisedLaneIds[3]);
            Assert.AreEqual(LaneId.Lane5, _raisedLaneIds[4]);
            Assert.AreEqual(LaneId.Lane6, _raisedLaneIds[5]);
        }

        private void TestPauseOrRestartRequestedOf(LaneId expectedLaneId, string data)
        {
            _isRaisedPauseOrRestartRequested = false;
            _raisedLaneIds.Clear();

            Mock<ISerialPortReader> serialPortReaderMock = new Mock<ISerialPortReader>();
            ArduinoReader arduinoReader = new ArduinoReader(serialPortReaderMock.Object);
            arduinoReader.PauseOrRestartRequested += ArduinoReaderPauseOrRestartRequesteded;

            arduinoReader.SerialPortDataReceived(null, data, new DateTime());

            Assert.IsTrue(_isRaisedPauseOrRestartRequested);
            Assert.AreEqual(expectedLaneId, _raisedLaneIds[0]);
        }

        private void ArduinoReaderPauseOrRestartRequesteded(object sender, LaneId laneId)
        {
            _isRaisedPauseOrRestartRequested = true;
            _raisedLaneIds.Add(laneId);
        }
    }
}
