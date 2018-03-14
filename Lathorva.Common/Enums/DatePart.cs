using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Lathorva.Common.Enums
{
    public enum DatePart
    {
        Unknown = 0,
        [Description("År")]
        Year = 1,
        [Description("Måned")]
        Month = 2,
        [Description("Uke")]
        Week = 3,
        [Description("Dag")]
        Day = 4,

        [Description("Ukedag")]
        DayOfWeek = 5,

        [Description("Time")]
        Hour = 6,
    }
}
