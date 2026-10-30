using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab9.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestStaticSubtract()
        {
            Time time = new Time(2, 10);
            Time result = Program.SubtractMinutes(time, 15);
            Assert.AreEqual(1, result.Hours);
            Assert.AreEqual(55, result.Minutes);
        }

        [TestMethod]
        public void TestStaticSubtractMoreThanTime()
        {
            Time time = new Time(0, 30);
            Time result = Program.SubtractMinutes(time, 45);
            Assert.AreEqual(0, result.Hours);
            Assert.AreEqual(0, result.Minutes);
        }

        [TestMethod]
        public void TestStaticSubtractZero()
        {
            Time time = new Time(2, 10);
            Time result = Program.SubtractMinutes(time, 0);
            Assert.AreEqual(2, result.Hours);
            Assert.AreEqual(10, result.Minutes);
        }

        [TestMethod]
        public void TestMaxInMiddle()
        {
            Time[] elements = { new Time(1, 0), new Time(5, 30), new Time(2, 45) };
            TimeArray times = new TimeArray(elements);
            Assert.AreEqual(1, Program.FindMaxIndex(times));
        }

        [TestMethod]
        public void TestMaxFirst()
        {
            Time[] elements = { new Time(9, 0), new Time(5, 30) };
            TimeArray times = new TimeArray(elements);
            Assert.AreEqual(0, Program.FindMaxIndex(times));
        }

        [TestMethod]
        public void TestMaxLast()
        {
            Time[] elements = { new Time(1, 0), new Time(2, 0), new Time(3, 0) };
            TimeArray times = new TimeArray(elements);
            Assert.AreEqual(2, Program.FindMaxIndex(times));
        }

        [TestMethod]
        public void TestMaxSameHours()
        {
            Time[] elements = { new Time(2, 10), new Time(2, 50), new Time(2, 30) };
            TimeArray times = new TimeArray(elements);
            Assert.AreEqual(1, Program.FindMaxIndex(times));
        }

        [TestMethod]
        public void TestMaxEqualElements()
        {
            Time[] elements = { new Time(5, 30), new Time(1, 0), new Time(5, 30) };
            TimeArray times = new TimeArray(elements);
            Assert.AreEqual(0, Program.FindMaxIndex(times));
        }

        [TestMethod]
        public void TestMaxOneElement()
        {
            Time[] elements = { new Time(4, 0) };
            TimeArray times = new TimeArray(elements);
            Assert.AreEqual(0, Program.FindMaxIndex(times));
        }

        [TestMethod]
        public void TestMaxEmptyArray()
        {
            TimeArray times = new TimeArray();
            Assert.AreEqual(-1, Program.FindMaxIndex(times));
        }
    }
}