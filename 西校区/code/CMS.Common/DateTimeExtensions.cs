using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Common
{
    public static class DateTimeExtensions
    {
        private static readonly GregorianCalendar gregorianCalendar = new GregorianCalendar();

        //public static int GetWeekOfMonth(this DateTime time)
        //{
        //    DateTime first = new DateTime(time.Year, time.Month, 1);
        //    return time.GetWeekOfYear() - first.GetWeekOfYear() + 1;
        //}

        //public static int GetWeekOfYear(this DateTime time)
        //{
        //    return gregorianCalendar.GetWeekOfYear(time, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        //}

        public static int GetWeekOfYear(this DateTime time)
        {
            return gregorianCalendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        /// <summary>
        /// 根据年月日推算这一天属于哪一年的周
        /// 比如2017年01月01日,是2016年的第53周
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int GetYearOfWeek(this DateTime time)
        {
            int weeks = time.GetWeekOfYear();
            if (weeks == 53 && time.Month == 1)
            {
                return time.Year - 1;
            }
            return time.Year;
        }

        /// <summary>
        /// 根据一年中的第几周获取该周的开始日期与结束日期
        /// </summary>
        /// <param name="year"></param>
        /// <param name="weekNumber"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static Tuple<DateTime, DateTime> GetFirstEndDayOfWeek(int year, int weekNumber, System.Globalization.CultureInfo culture)
        {
            System.Globalization.Calendar calendar = culture.Calendar;
            DateTime firstOfYear = new DateTime(year, 1, 1, calendar);
            DateTime targetDay = calendar.AddWeeks(firstOfYear, weekNumber - 1);
            DayOfWeek firstDayOfWeek = culture.DateTimeFormat.FirstDayOfWeek;
            while (targetDay.DayOfWeek != firstDayOfWeek)
            {
                targetDay = targetDay.AddDays(-1);
            }
            return Tuple.Create<DateTime, DateTime>(targetDay, targetDay.AddDays(6));
        }
    }
}
