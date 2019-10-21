using System;
using System.Collections.Generic;
using AlmanakkaTestDataCreator.NETStandard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AlmanakkaTestDataCreator.Test
{
    [TestClass]
    public class CalendarDataCreatorTest
    {
        #region DayCreate
        [TestMethod]
        public void TestDayCreate_In_2019_1()
        {
            var creator = new CalendarDataCreator();

            List<Month> months = creator.Create(new DateTime(2019, 1, 1), new DateTime(2019, 1, 31), DayOfWeek.Sunday, false);
            List<Day> days = months.SelectMany(x => x.Weeks).SelectMany(x => x.Days).Where(x => x != null).Select(x => x.Day).ToList();

            for (int i = 0; i < days.Count; i++)
            {
                var day = days[i];

                Assert.AreEqual(2019, day.Year);
                Assert.AreEqual(1, day.Month);
                Assert.AreEqual(i + 1, day.DayOfMonth);
                // 1/1 is Tuesday
                Assert.AreEqual(((i % 7) + 2) % 7, day.DayOfWeekValue);
            }
        }

        [TestMethod]
        public void TestDayCreate_Between_2019_1_And_2019_2()
        {
            var creator = new CalendarDataCreator();

            List<Month> months = creator.Create(new DateTime(2019, 1, 1), new DateTime(2019, 2, 28), DayOfWeek.Sunday, false);
            List<Day> days = months.SelectMany(x => x.Weeks).SelectMany(x => x.Days).Where(x => x != null).Select(x => x.Day).ToList();

            for (int i = 0; i < days.Count; i++)
            {
                var day = days[i];

                Assert.AreEqual(2019, day.Year);

                if (i < 31)
                {
                    Assert.AreEqual(1, day.Month);
                    Assert.AreEqual(i + 1, day.DayOfMonth);
                    // 1/1 is Tuesday
                    Assert.AreEqual(((i % 7) + 2) % 7, day.DayOfWeekValue);
                }
                else
                {
                    Assert.AreEqual(2, day.Month);
                    Assert.AreEqual((i - 31) + 1, day.DayOfMonth);
                    // 2/1 is Friday
                    Assert.AreEqual((((i - 31) % 7) + 5) % 7, day.DayOfWeekValue);
                }
            }
        }

        [TestMethod]
        public void TestDayCreate_Between_2018_12_And_2019_1()
        {
            var creator = new CalendarDataCreator();

            List<Month> months = creator.Create(new DateTime(2018, 12, 1), new DateTime(2019, 1, 31), DayOfWeek.Sunday, false);
            List<Day> days = months.SelectMany(x => x.Weeks).SelectMany(x => x.Days).Where(x => x != null).Select(x => x.Day).ToList();

            for (int i = 0; i < days.Count; i++)
            {
                var day = days[i];

                if (i < 31)
                {
                    Assert.AreEqual(2018, day.Year);
                    Assert.AreEqual(12, day.Month);
                    Assert.AreEqual(i + 1, day.DayOfMonth);
                    // 12/1 is Saturday
                    Assert.AreEqual(((i % 7) + 6) % 7, day.DayOfWeekValue);
                }
                else
                {
                    Assert.AreEqual(2019, day.Year);
                    Assert.AreEqual(1, day.Month);
                    Assert.AreEqual((i - 31) + 1, day.DayOfMonth);
                    // 1/1 is Tuesday
                    Assert.AreEqual((((i - 31) % 7) + 2) % 7, day.DayOfWeekValue);
                }
            }
        }

        [TestMethod]
        public void TestDayCreate__FewRange()
        {
            var creator = new CalendarDataCreator();

            List<Month> months = creator.Create(new DateTime(2019, 1, 15), new DateTime(2019, 1, 15), DayOfWeek.Sunday, false);
            List<Day> days = months.SelectMany(x => x.Weeks).SelectMany(x => x.Days).Where(x => x != null).Select(x => x.Day).ToList();

            for (int i = 0; i < days.Count; i++)
            {
                var day = days[i];

                Assert.AreEqual(2019, day.Year);
                Assert.AreEqual(1, day.Month);
                Assert.AreEqual(i + 1, day.DayOfMonth);
                // 1/1 is Tuesday
                Assert.AreEqual(((i % 7) + 2) % 7, day.DayOfWeekValue);
            }
        }
        #endregion DayCreate

        #region DayRelation
        [TestMethod]
        public void TestDayRelation_In_2019_1()
        {
            var creator = new CalendarDataCreator();

            List<Month> months = creator.Create(new DateTime(2019, 1, 1), new DateTime(2019, 1, 31), DayOfWeek.Sunday, false);
            List<RelationalDay> days = months.SelectMany(x => x.Weeks).SelectMany(x => x.Days).Where(x => x != null).ToList();

            Assert.AreEqual(31, days.Count);

            for (int i = 0; i < days.Count; i++)
            {
                var day = days[i];

                if (i != 0)
                {
                    Assert.AreEqual(true, Day.Equals(days[i - 1].Day, day.PreviousDay));
                }

                if (i != days.Count - 1)
                {
                    Assert.AreEqual(true, Day.Equals(days[i + 1].Day, day.NextDay));
                }
            }
        }

        [TestMethod]
        public void TestDayRelaition_Between_2019_1_And_2019_2()
        {
            var creator = new CalendarDataCreator();

            List<Month> months = creator.Create(new DateTime(2019, 1, 1), new DateTime(2019, 2, 28), DayOfWeek.Sunday, false);
            List<RelationalDay> days = months.SelectMany(x => x.Weeks).SelectMany(x => x.Days).Where(x => x != null).ToList();

            Assert.AreEqual(59, days.Count);

            for (int i = 0; i < days.Count; i++)
            {
                var day = days[i];

                if (i != 0)
                {
                    Assert.AreEqual(true, Day.Equals(days[i - 1].Day, day.PreviousDay));
                }

                if (i != days.Count - 1)
                {
                    Assert.AreEqual(true, Day.Equals(days[i + 1].Day, day.NextDay));
                }
            }
        }

        [TestMethod]
        public void TestDayRelaition_Between_2018_12_And_2018_1()
        {
            var creator = new CalendarDataCreator();

            List<Month> months = creator.Create(new DateTime(2018, 12, 1), new DateTime(2019, 1, 31), DayOfWeek.Sunday, false);
            List<RelationalDay> days = months.SelectMany(x => x.Weeks).SelectMany(x => x.Days).Where(x => x != null).ToList();

            Assert.AreEqual(62, days.Count);

            for (int i = 0; i < days.Count; i++)
            {
                var day = days[i];

                if (i != 0)
                {
                    Assert.AreEqual(true, Day.Equals(days[i - 1].Day, day.PreviousDay));
                }

                if (i != days.Count - 1)
                {
                    Assert.AreEqual(true, Day.Equals(days[i + 1].Day, day.NextDay));
                }
            }
        }
        #endregion DayRelation

        #region DayDisable
        [TestMethod]
        public void TestDayDisable_OneMonth()
        {
            var creator = new CalendarDataCreator();

            List<Month> months = creator.Create(new DateTime(2019, 1, 2), new DateTime(2019, 1, 2), DayOfWeek.Sunday, false);
            List<Day> days = months.SelectMany(x => x.Weeks).SelectMany(x => x.Days).Where(x => x != null).Select(x => x.Day).ToList();

            for (int i = 0; i < days.Count; i++)
            {
                var day = days[i];

                Assert.AreEqual((i + 1) != 2, day.IsDisabled);
            }
        }

        [TestMethod]
        public void TestDayDisable_MultiMonth()
        {
            var creator = new CalendarDataCreator();

            List<Month> months = creator.Create(new DateTime(2019, 1, 2), new DateTime(2019, 2, 27), DayOfWeek.Sunday, false);
            List<Day> days = months.SelectMany(x => x.Weeks).SelectMany(x => x.Days).Where(x => x != null).Select(x => x.Day).ToList();

            for (int i = 0; i < days.Count; i++)
            {
                var day = days[i];

                Assert.AreEqual(i == 0 || i == days.Count - 1, day.IsDisabled);
            }
        }
        #endregion DayDisable

        #region ContainDaysOfDifferentMonth
        [TestMethod]
        public void TestWeekSize_ContainsDaysOfDifferentMonth()
        {
            var creator = new CalendarDataCreator();

            List<Month> months = creator.Create(new DateTime(2019, 1, 1), new DateTime(2020, 12, 31), DayOfWeek.Sunday, true);
            List<Week> weeks = months.SelectMany(x => x.Weeks).ToList();

            // first and last week will be lack of days
            for (int i = 1; i < weeks.Count - 1; i++)
            {
                var week = weeks[i];
                Assert.AreEqual(7, week.Days.Count);
            }
        }

        [TestMethod]
        public void TestDayOfWeekOrder_ContainsDaysOfDifferentMonth()
        {
            var creator = new CalendarDataCreator();

            checkDayOfWeekStart(creator.Create(new DateTime(2019, 1, 1), new DateTime(2020, 12, 31), DayOfWeek.Sunday, true), DayOfWeek.Sunday);
            checkDayOfWeekStart(creator.Create(new DateTime(2019, 1, 1), new DateTime(2020, 12, 31), DayOfWeek.Monday, true), DayOfWeek.Monday);
            checkDayOfWeekStart(creator.Create(new DateTime(2019, 1, 1), new DateTime(2020, 12, 31), DayOfWeek.Tuesday, true), DayOfWeek.Tuesday);
            checkDayOfWeekStart(creator.Create(new DateTime(2019, 1, 1), new DateTime(2020, 12, 31), DayOfWeek.Wednesday, true), DayOfWeek.Wednesday);
            checkDayOfWeekStart(creator.Create(new DateTime(2019, 1, 1), new DateTime(2020, 12, 31), DayOfWeek.Thursday, true), DayOfWeek.Thursday);
            checkDayOfWeekStart(creator.Create(new DateTime(2019, 1, 1), new DateTime(2020, 12, 31), DayOfWeek.Friday, true), DayOfWeek.Friday);
            checkDayOfWeekStart(creator.Create(new DateTime(2019, 1, 1), new DateTime(2020, 12, 31), DayOfWeek.Saturday, true), DayOfWeek.Saturday);

            void checkDayOfWeekStart(List<Month> months, DayOfWeek dayOfWeekStart)
            {
                foreach (var week in months.SelectMany(x => x.Weeks))
                {
                    if (week.Days.Count == 7)
                    {
                        Assert.AreEqual(dayOfWeekStart, week.Days[0].Day.DayOfWeek);
                    }
                }
            }
        }
        #endregion ContainDaysOfDifferentMonth

        #region NotContainDaysOfDifferentMonth
        [TestMethod]
        public void TestWeekSize_NotContainsDaysOfDifferentMonth()
        {
            var creator = new CalendarDataCreator();
            List<Month> months = creator.Create(new DateTime(2019, 1, 1), new DateTime(2020, 12, 31), DayOfWeek.Sunday, false);

            foreach (var month in months)
            {
                List<Week> weeks = month.Weeks;

                // first and last week will be lack of days
                for (int i = 1; i < weeks.Count - 1; i++)
                {
                    var week = weeks[i];
                    Assert.AreEqual(7, week.Days.Count);
                }
            }
        }

        [TestMethod]
        public void TestDayOfWeekOrder_NotContainsDaysOfDifferentMonth()
        {
            var creator = new CalendarDataCreator();

            checkDayOfWeekStart(creator.Create(new DateTime(2019, 1, 1), new DateTime(2020, 12, 31), DayOfWeek.Sunday, false), DayOfWeek.Sunday);
            checkDayOfWeekStart(creator.Create(new DateTime(2019, 1, 1), new DateTime(2020, 12, 31), DayOfWeek.Monday, false), DayOfWeek.Monday);
            checkDayOfWeekStart(creator.Create(new DateTime(2019, 1, 1), new DateTime(2020, 12, 31), DayOfWeek.Tuesday, false), DayOfWeek.Tuesday);
            checkDayOfWeekStart(creator.Create(new DateTime(2019, 1, 1), new DateTime(2020, 12, 31), DayOfWeek.Wednesday, false), DayOfWeek.Wednesday);
            checkDayOfWeekStart(creator.Create(new DateTime(2019, 1, 1), new DateTime(2020, 12, 31), DayOfWeek.Thursday, false), DayOfWeek.Thursday);
            checkDayOfWeekStart(creator.Create(new DateTime(2019, 1, 1), new DateTime(2020, 12, 31), DayOfWeek.Friday, false), DayOfWeek.Friday);
            checkDayOfWeekStart(creator.Create(new DateTime(2019, 1, 1), new DateTime(2020, 12, 31), DayOfWeek.Saturday, false), DayOfWeek.Saturday);

            void checkDayOfWeekStart(List<Month> months, DayOfWeek dayOfWeekStart)
            {
                foreach (var month in months)
                {
                    for (int i = 0; i < month.Weeks.Count; i++)
                    {
                        Week week = month.Weeks[i];
                        if (0 < i || week.Days.Count == 7)
                        {
                            Assert.AreEqual(dayOfWeekStart, week.Days[0].Day.DayOfWeek);
                        }
                    }
                }
            }
        }
        #endregion NotContainDaysOfDifferentMonth
    }
}
