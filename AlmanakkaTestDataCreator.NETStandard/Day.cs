using System;
using System.Runtime.Serialization;

namespace AlmanakkaTestDataCreator.NETStandard
{
    public class Day
    {
        public int Year { get; set; }

        public int Month { get; set; }

        [DataMember(Name = "Day")]
        public int DayOfMonth { get; set; }

        [IgnoreDataMember]
        public DayOfWeek DayOfWeek { get; set; }

        [DataMember(Name = "DayOfWeek")]
        public int DayOfWeekValue => (int)DayOfWeek;

        public bool IsDisabled { get; set; }

        public static bool Equals(Day left, Day right)
        {
            if(left ==null || right == null)
            {
                return false;
            }

            return left.Year == right.Year && left.Month == right.Month && left.DayOfMonth == right.DayOfMonth;
        }

        public static bool operator <(Day left, Day right)
        {
            return left.Year < right.Year
                || (left.Year == right.Year && left.Month < right.Month)
                || (left.Year == right.Year && left.Month == right.Month && left.DayOfMonth < right.DayOfMonth);
        }

        public static bool operator >(Day left, Day right)
        {
            return Equals(left, right) == false && (left < right) == false;
        }

        public static bool operator <=(Day left, Day right)
        {
            return Equals(left, right) || left < right;
        }

        public static bool operator >=(Day left, Day right)
        {
            return Equals(left, right) || left > right;
        }

        public static bool Equals(Day left, DateTime right)
        {
            if(left == null)
            {
                return false;
            }

            return left.Year == right.Year && left.Month == right.Month && left.DayOfMonth == right.Day;
        }

        public static bool operator <(Day left, DateTime right)
        {
            return left.Year < right.Year
                || (left.Year == right.Year && left.Month < right.Month)
                || (left.Year == right.Year && left.Month == right.Month && left.DayOfMonth < right.Day);
        }

        public static bool operator >(Day left, DateTime right)
        {
            return Equals(left, right) == false && (left < right) == false;
        }

        public static bool operator <(DateTime left, Day right)
        {
            return right > left;
        }

        public static bool operator >(DateTime left, Day right)
        {
            return right < left;
        }

        public static bool operator <=(Day left, DateTime right)
        {
            return Equals(left, right) || left < right;
        }

        public static bool operator >=(Day left, DateTime right)
        {
            return Equals(left, right) || left > right;
        }

        public static bool operator <=(DateTime left, Day right)
        {
            return Equals(right, left) || left < right;
        }

        public static bool operator >=(DateTime left, Day right)
        {
            return Equals(right, left) || left > right;
        }
    }

    public class RelationalDay
    {
        [DataMember(Order = 0)]
        public Day PreviousDay { get; set; }

        [DataMember(Order = 1)]
        public Day Day { get; set; }

        [DataMember(Order = 2)]
        public Day NextDay { get; set; }

    }
}
