using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab9.Tests
{
    [TestClass]
    public class TimeArrayTests
    {
        [TestMethod]
        public void TestEmptyArray()
        {
            TimeArray times = new TimeArray();
            Assert.AreEqual(0, times.Length);
        }

        [TestMethod]
        public void TestRandomArray()
        {
            TimeArray times = new TimeArray(5);
            Assert.AreEqual(5, times.Length);
            for (int i = 0; i < times.Length; i++)
            {
                Assert.IsTrue(times[i].Hours >= 0 && times[i].Hours <= 23);
                Assert.IsTrue(times[i].Minutes >= 0 && times[i].Minutes <= 59);
            }
        }

        [TestMethod]
        public void TestRandomArrayOneElement()
        {
            TimeArray times = new TimeArray(1);
            Assert.AreEqual(1, times.Length);
        }

        [TestMethod]
        public void TestRandomArrayZeroLength()
        {
            TimeArray times = new TimeArray(0);
            Assert.AreEqual(0, times.Length);
        }

        [TestMethod]
        public void TestArrayFromTimes()
        {
            TimeArray times = new TimeArray(new Time[] { new Time(1, 10), new Time(2, 30) });
            Assert.AreEqual(2, times.Length);
            Assert.AreEqual(2, times[1].Hours);
            Assert.AreEqual(30, times[1].Minutes);
        }

        [TestMethod]
        public void TestArrayFromEmptyTimes()
        {
            TimeArray times = new TimeArray(new Time[0]);
            Assert.AreEqual(0, times.Length);
        }

        [TestMethod]
        public void TestIndexerSet()
        {
            TimeArray times = new TimeArray(new Time[] { new Time(1, 10), new Time(2, 30) });
            times[0] = new Time(7, 0);
            Assert.AreEqual(7, times[0].Hours);
            Assert.AreEqual(0, times[0].Minutes);
        }

        [TestMethod]
        public void TestIndexerNegativeIndex()
        {
            TimeArray times = new TimeArray(new Time[] { new Time(1, 10), new Time(2, 30) });
            Assert.ThrowsExactly<ArgumentException>(() => times[-1]);
        }

        [TestMethod]
        public void TestIndexerIndexEqualsLength()
        {
            TimeArray times = new TimeArray(new Time[] { new Time(1, 10), new Time(2, 30) });
            Assert.ThrowsExactly<ArgumentException>(() => times[2]);
        }

        [TestMethod]
        public void TestIndexerEmptyArray()
        {
            TimeArray times = new TimeArray();
            Assert.ThrowsExactly<ArgumentException>(() => times[0]);
        }

        [TestMethod]
        public void TestIndexerSetWrongIndex()
        {
            TimeArray times = new TimeArray(new Time[] { new Time(1, 10), new Time(2, 30) });
            Assert.ThrowsExactly<ArgumentException>(() => times[5] = new Time(7, 0));
        }

        [TestMethod]
        public void TestArrayCount()
        {
            int countBefore = TimeArray.Count;
            new TimeArray();
            Assert.IsTrue(TimeArray.Count > countBefore);
        }
    }
}