using System;
using AlmanakkaTestDataCreator.NETStandard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlmanakkaTestDataCreator.Test
{
    [TestClass]
    public class DayTest
    {
        [TestMethod]
        public void TestEquals()
        {
            var day1 = new Day { Year = 2018, Month = 2, DayOfMonth = 12 };
            var day2 = new Day { Year = 2018, Month = 2, DayOfMonth = 12 };
            var dateTime = new DateTime(2018, 2, 12);

            Assert.AreEqual(true, Day.Equals(day1, day2));
            Assert.AreEqual(true, Day.Equals(day1, dateTime));
        }

        [TestMethod]
        public void TestCompare()
        {
            var day1 = new Day { Year = 2018, Month = 2, DayOfMonth = 12 };
            var day2 = new Day { Year = 2017, Month = 3, DayOfMonth = 13 };
            var day3 = new Day { Year = 2018, Month = 2, DayOfMonth = 11 };
            var day4 = new Day { Year = 2018, Month = 2, DayOfMonth = 12 };
            var dateTime1 = new DateTime(2018, 2, 12);
            var dateTime2 = new DateTime(2017, 3, 13);
            var dateTime3 = new DateTime(2018, 2, 11);


            Assert.AreEqual(false, day1 < day2);
            Assert.AreEqual(false, day1 <= day2);
            Assert.AreEqual(true, day1 > day2);
            Assert.AreEqual(true, day1 >= day2);

            Assert.AreEqual(false, day1 < day3);
            Assert.AreEqual(false, day1 <= day3);
            Assert.AreEqual(true, day1 > day3);
            Assert.AreEqual(true, day1 >= day3);

            Assert.AreEqual(false, day1 < day4);
            Assert.AreEqual(true, day1 <= day4);
            Assert.AreEqual(false, day1 > day4);
            Assert.AreEqual(true, day1 >= day4);

            Assert.AreEqual(false, day1 < dateTime1);
            Assert.AreEqual(true, day1 <= dateTime1);
            Assert.AreEqual(false, day1 > dateTime1);
            Assert.AreEqual(true, day1 >= dateTime1);

            Assert.AreEqual(false, day1 < dateTime2);
            Assert.AreEqual(false, day1 <= dateTime2);
            Assert.AreEqual(true, day1 > dateTime2);
            Assert.AreEqual(true, day1 >= dateTime2);

            Assert.AreEqual(false, day1 < dateTime3);
            Assert.AreEqual(false, day1 <= dateTime3);
            Assert.AreEqual(true, day1 > dateTime3);
            Assert.AreEqual(true, day1 >= dateTime3);

            Assert.AreEqual(false, dateTime1 < day1);
            Assert.AreEqual(true, dateTime1 <= day1);
            Assert.AreEqual(false, dateTime1 > day1);
            Assert.AreEqual(true, dateTime1 >= day1);

            Assert.AreEqual(true, dateTime2 < day1);
            Assert.AreEqual(true, dateTime2 <= day1);
            Assert.AreEqual(false, dateTime2 > day1);
            Assert.AreEqual(false, dateTime2 >= day1);

            Assert.AreEqual(true, dateTime3 < day1);
            Assert.AreEqual(true, dateTime3 <= day1);
            Assert.AreEqual(false, dateTime3 > day1);
            Assert.AreEqual(false, dateTime3 >= day1);
        }
    }
}
