using System;
namespace AlmanakkaTestDataCreator.NETStandard
{
    public static class DateTimeExtensions
    {
        public static Day ToDay(this DateTime dateTime)
        {
            return new Day
            {
                Year = dateTime.Year,
                Month = dateTime.Month,
                DayOfMonth = dateTime.Day,
                DayOfWeek = dateTime.DayOfWeek
            };
        }
    }
}
