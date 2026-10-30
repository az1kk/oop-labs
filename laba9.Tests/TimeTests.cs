using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab9.Tests
{
    [TestClass]
    public class TimeTests
    {
        [TestMethod]
        public void TestConstructorWithoutParameters()
        {
            Time time = new Time();
            Assert.AreEqual(0, time.Hours);
            Assert.AreEqual(0, time.Minutes);
        }

        [TestMethod]
        public void TestConstructorWithParameters()
        {
            Time time = new Time(2, 10);
            Assert.AreEqual(2, time.Hours);
            Assert.AreEqual(10, time.Minutes);
        }

        [TestMethod]
        public void TestConstructorHoursMoreThan23()
        {
            Time time = new Time(30, 59);
            Assert.AreEqual(30, time.Hours);
            Assert.AreEqual(59, time.Minutes);
        }

        [TestMethod]
        public void TestConstructorNegativeHours()
        {
            Time time = new Time(-3, 15);
            Assert.AreEqual(0, time.Hours);
            Assert.AreEqual(15, time.Minutes);
        }

        [TestMethod]
        public void TestConstructorMinutesMoreThan59()
        {
            Time time = new Time(2, 60);
            Assert.AreEqual(2, time.Hours);
            Assert.AreEqual(0, time.Minutes);
        }

        [TestMethod]
        public void TestConstructorNegativeMinutes()
        {
            Time time = new Time(2, -5);
            Assert.AreEqual(2, time.Hours);
            Assert.AreEqual(0, time.Minutes);
        }

        [TestMethod]
        public void TestCount()
        {
            int countBefore = Time.Count;
            new Time(1, 0);
            Assert.IsTrue(Time.Count > countBefore);
        }

        [TestMethod]
        public void TestSubtractWithoutHourChange()
        {
            Time time = new Time(2, 30);
            Time result = time.SubtractMinutes(15);
            Assert.AreEqual(2, result.Hours);
            Assert.AreEqual(15, result.Minutes);
        }

        [TestMethod]
        public void TestSubtractWithHourChange()
        {
            Time time = new Time(2, 10);
            Time result = time.SubtractMinutes(15);
            Assert.AreEqual(1, result.Hours);
            Assert.AreEqual(55, result.Minutes);
        }

        [TestMethod]
        public void TestSubtractToZero()
        {
            Time time = new Time(0, 45);
            Time result = time.SubtractMinutes(45);
            Assert.AreEqual(0, result.Hours);
            Assert.AreEqual(0, result.Minutes);
        }

        [TestMethod]
        public void TestSubtractMoreThanTime()
        {
            Time time = new Time(0, 30);
            Time result = time.SubtractMinutes(45);
            Assert.AreEqual(0, result.Hours);
            Assert.AreEqual(0, result.Minutes);
        }

        [TestMethod]
        public void TestSubtractDoesNotChangeTime()
        {
            Time time = new Time(2, 10);
            time.SubtractMinutes(15);
            Assert.AreEqual(2, time.Hours);
            Assert.AreEqual(10, time.Minutes);
        }

        [TestMethod]
        public void TestDecrement()
        {
            Time time = new Time(1, 30);
            time--;
            Assert.AreEqual(1, time.Hours);
            Assert.AreEqual(29, time.Minutes);
        }

        [TestMethod]
        public void TestDecrementWithHourChange()
        {
            Time time = new Time(1, 0);
            time--;
            Assert.AreEqual(0, time.Hours);
            Assert.AreEqual(59, time.Minutes);
        }

        [TestMethod]
        public void TestDecrementZero()
        {
            Time time = new Time(0, 0);
            time--;
            Assert.AreEqual(0, time.Hours);
            Assert.AreEqual(0, time.Minutes);
        }

        [TestMethod]
        public void TestExplicitInt()
        {
            Time time = new Time(2, 59);
            int hours = (int)time;
            Assert.AreEqual(2, hours);
        }

        [TestMethod]
        public void TestExplicitIntZeroHours()
        {
            Time time = new Time(0, 45);
            int hours = (int)time;
            Assert.AreEqual(0, hours);
        }

        [TestMethod]
        public void TestImplicitBoolTrue()
        {
            Time time = new Time(2, 0);
            bool isNotZero = time;
            Assert.IsTrue(isNotZero);
        }

        [TestMethod]
        public void TestImplicitBoolFalse()
        {
            Time time = new Time(0, 45);
            bool isNotZero = time;
            Assert.IsFalse(isNotZero);
        }

        [TestMethod]
        public void TestAddZeroMinutes()
        {
            Time time = new Time(1, 50);
            Time result = time + 0;
            Assert.AreEqual(1, result.Hours);
            Assert.AreEqual(50, result.Minutes);
        }

        [TestMethod]
        public void TestAddMinutesWithoutHourChange()
        {
            Time time = new Time(1, 10);
            Time result = time + 15;
            Assert.AreEqual(1, result.Hours);
            Assert.AreEqual(25, result.Minutes);
        }

        [TestMethod]
        public void TestAddMinutes()
        {
            Time time = new Time(1, 50);
            Time result = time + 15;
            Assert.AreEqual(2, result.Hours);
            Assert.AreEqual(5, result.Minutes);
        }

        [TestMethod]
        public void TestAddMinutesLeft()
        {
            Time time = new Time(1, 50);
            Time result = 15 + time;
            Assert.AreEqual(2, result.Hours);
            Assert.AreEqual(5, result.Minutes);
        }

        [TestMethod]
        public void TestAddManyMinutes()
        {
            Time time = new Time(0, 45);
            Time result = time + 150;
            Assert.AreEqual(3, result.Hours);
            Assert.AreEqual(15, result.Minutes);
        }

        [TestMethod]
        public void TestAddTimes()
        {
            Time time1 = new Time(1, 40);
            Time time2 = new Time(2, 30);
            Time result = time1 + time2;
            Assert.AreEqual(4, result.Hours);
            Assert.AreEqual(10, result.Minutes);
        }

        [TestMethod]
        public void TestAddTimesMoreThan24Hours()
        {
            Time time1 = new Time(20, 0);
            Time time2 = new Time(5, 0);
            Time result = time1 + time2;
            Assert.AreEqual(25, result.Hours);
            Assert.AreEqual(0, result.Minutes);
        }

        [TestMethod]
        public void TestCompare()
        {
            Time time1 = new Time(2, 10);
            Time time2 = new Time(1, 55);
            Assert.IsTrue(time1 > time2);
            Assert.IsTrue(time2 < time1);
        }

        [TestMethod]
        public void TestCompareEqual()
        {
            Time time1 = new Time(2, 10);
            Time time2 = new Time(2, 10);
            Assert.IsFalse(time1 > time2);
            Assert.IsFalse(time1 < time2);
        }
    }
}