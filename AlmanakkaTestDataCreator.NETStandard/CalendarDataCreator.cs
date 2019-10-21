using System;
using System.Collections.Generic;
using System.Linq;

namespace AlmanakkaTestDataCreator.NETStandard
{
    public class CalendarDataCreator
    {
        private const int firstMonthOfYear = 1;
        private const int lastMonthOfYear = 12;

        public List<Month> Create(DateTime minDay, DateTime maxDay, DayOfWeek dayOfOrderStart, bool isContainDaysOfDifferentMonth)
        {
            IEnumerable<RelationalDay> days = createRelationalDays(createDays(minDay, maxDay));
            var months = new List<Month>();

            var lastMonthFirstDay = new DateTime(maxDay.Year, maxDay.Month, 1);
            var currentMonthFirstDay = new DateTime(minDay.Year, minDay.Month, 1);

            while (currentMonthFirstDay <= lastMonthFirstDay)
            {
                Month month;
                if (isContainDaysOfDifferentMonth)
                {
                    month = createMonthWithContainDaysOfDifferentMonth(days, currentMonthFirstDay, dayOfOrderStart);
                }
                else
                {
                    month = createMonth(days, currentMonthFirstDay, dayOfOrderStart);
                }

                if (month.Weeks.Any())
                {
                    months.Add(month);
                }
                else
                {
                    break;
                }

                currentMonthFirstDay = currentMonthFirstDay.AddMonths(1);
            }

            return months;
        }

        private IEnumerable<Day> createDays(DateTime minDay, DateTime maxDay)
        {
            DateTime createLastDay()
            {
                int year = maxDay.Year;
                int month = maxDay.Month + 1;
                if (lastMonthOfYear < month)
                {
                    year += 1;
                    month = firstMonthOfYear;
                }
                return new DateTime(year, month, 1).AddDays(-1);
            }

            DateTime firstDay = new DateTime(minDay.Year, minDay.Month, 1);
            DateTime lastDay = createLastDay();

            DateTime currentDay = firstDay;
            while (currentDay <= lastDay)
            {
                bool isDisabled = currentDay < minDay || maxDay < currentDay;
                Day day = currentDay.ToDay();
                day.IsDisabled = isDisabled;
                yield return day;
                currentDay = currentDay.AddDays(1);
            }
        }

        private IEnumerable<RelationalDay> createRelationalDays(IEnumerable<Day> days)
        {
            Day previousDay = null;
            Day currentDay = days.First();
            Day nextDay = null;

            foreach (var day in days.Skip(1))
            {
                nextDay = day;

                yield return new RelationalDay
                {
                    PreviousDay = previousDay,
                    Day = currentDay,
                    NextDay = nextDay
                };

                previousDay = currentDay;
                currentDay = nextDay;
            }

            // last day
            yield return new RelationalDay
            {
                PreviousDay = previousDay,
                Day = currentDay,
                NextDay = null
            };
        }

        private Month createMonth(IEnumerable<RelationalDay> days, DateTime monthFirstDay, DayOfWeek dayOfOrderStart)
        {
            RelationalDay firstDay = days.SkipWhile(x => x.Day < monthFirstDay)
                                         .First();

            DayOfWeek dayOfOrderEnd = calculateDayOfOrderEnd(dayOfOrderStart);
            Day previousWeekEndDay = new DateTime(firstDay.Day.Year, firstDay.Day.Month, firstDay.Day.DayOfMonth).AddDays(-1).ToDay();
            var weeks = new List<Week>();
            bool hasNextWeek = true;

            while (hasNextWeek)
            {
                bool isEndWeek = false;
                List<RelationalDay> daysOfWeek = days.SkipWhile(x => x.Day < firstDay.Day)
                                                     .SkipWhile(x => x.Day <= previousWeekEndDay)
                                                     .TakeWhile(x => x.Day.Month == monthFirstDay.Month && isEndWeek == false)
                                                     .Do(x => isEndWeek = x.Day.DayOfWeek == dayOfOrderEnd)
                                                     .ToList();

                if (daysOfWeek.Count != 0)
                {
                    weeks.Add(new Week { Days = daysOfWeek });
                    previousWeekEndDay = daysOfWeek.Last().Day;
                }
                else
                {
                    hasNextWeek = false;
                }
            }

            return new Month
            {
                Year = monthFirstDay.Year,
                MonthOfYear = monthFirstDay.Month,
                Weeks = weeks
            };
        }

        private Month createMonthWithContainDaysOfDifferentMonth(IEnumerable<RelationalDay> days, DateTime monthFirstDay, DayOfWeek dayOfOrderStart)
        {
            RelationalDay firstDay = days.Reverse()
                                         .SkipWhile(x => monthFirstDay < x.Day)
                                         .FirstOrDefault(x => x.Day.DayOfWeek == dayOfOrderStart)
                                         ?? days.SkipWhile(x => x.Day < monthFirstDay).First();

            Day previousWeekEndDay = new DateTime(firstDay.Day.Year, firstDay.Day.Month, firstDay.Day.DayOfMonth).AddDays(-1).ToDay();
            var weeks = new List<Week>();
            bool hasNextWeek = true;

            while (hasNextWeek)
            {
                int count = 0;
                List<RelationalDay> daysOfWeek = days.SkipWhile(x => x.Day < firstDay.Day)
                                                     .SkipWhile(x => x.Day <= previousWeekEndDay)
                                                     .Do(_ => count++)
                                                     .TakeWhile(x => count == 1 || x.Day.DayOfWeek != dayOfOrderStart)
                                                     .ToList();

                if (daysOfWeek.Count != 0 && (weeks.Count != 0 && daysOfWeek.FirstOrDefault()?.Day?.Month == monthFirstDay.Month || weeks.Count == 0))
                {
                    weeks.Add(new Week { Days = daysOfWeek });
                    previousWeekEndDay = daysOfWeek.Last().Day;
                }
                else
                {
                    hasNextWeek = false;
                }
            }

            return new Month
            {
                Year = monthFirstDay.Year,
                MonthOfYear = monthFirstDay.Month,
                Weeks = weeks
            };
        }

        private DayOfWeek calculateDayOfOrderEnd(DayOfWeek dayOfOrderStart)
        {
            int dayOfWeekValue = (int)dayOfOrderStart - 1;

            if (dayOfWeekValue < 0)
            {
                dayOfWeekValue = 6;
            }

            return (DayOfWeek)dayOfWeekValue;
        }
    }
}
