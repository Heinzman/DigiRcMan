﻿using System.Reflection;
using Elreg.BusinessObjects;
using Elreg.CentralUnitService;
using Elreg.CentralUnitService.Settings;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Elreg.UnitTests.CentralUnitTests
{
    [TestFixture]
    public class When_CentralUnit_is_activated : CentralUnitBaseTest
    {
        protected override void InitCentralUnitOptionsService()
        {
            _centralUnitOptionsService.Options = new Options
            {
                IsCentralUnitActivated = true,
                TurboOptions =
                {
                    IsActivated = true,
                    MaxLevelWithoutTurbo = (uint)ControllerLevel.L14,
                    LevelOfTurbo = ControllerLevel.L15
                },
                DelayOptions = { IsActivated = true }
            };
        }

        [Test]
        public void Controlling_Arduino_should_be_started()
        {
            bool isTaskStarted = false;

            FieldInfo fieldInfo = (typeof(CentralUnit)).GetField("_started", BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo != null)
                isTaskStarted = (bool)fieldInfo.GetValue(_centralUnit);

            Assert.AreEqual(true, isTaskStarted);
        }
    }
}
