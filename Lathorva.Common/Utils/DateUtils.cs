using System;
using System.Collections.Generic;
using System.Text;

namespace Lathorva.Common.Extensions
{
    public static class DateUtils
    {
        /// <summary>
        /// Get all dates between two dates
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static IEnumerable<DateTime> GetAllDatesFromAndTo(DateTime startDate, DateTime endDate)
        {
            if(endDate < startDate) throw new Exception("EndDate is bigger than startDate");
            var dates = new List<DateTime>();
            while (startDate < endDate)
            {
                dates.Add(startDate);
                startDate = startDate.AddDays(1);
            }

            return dates;
        }
    }
}
