using System;
using System.Collections.Generic;

namespace AlmanakkaTestDataCreator.NETStandard
{
    public class Month
    {
        public int Year { get; set; }

        public int MonthOfYear { get; set; }

        public List<Week> Weeks { get; set; }
    }
}
