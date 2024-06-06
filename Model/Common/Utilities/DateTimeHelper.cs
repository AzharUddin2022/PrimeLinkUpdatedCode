using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;

namespace Wrappers
{
    public static class DateTimeHelper
    {
        //Ref: http://stackoverflow.com/questions/24245523/getting-the-first-and-last-day-of-a-month-using-a-given-datetime-object
        public static DateTime FirstDayOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1);

        }
        public static DateTime LastDayOfMonth(this DateTime value)
        {
            return FirstDayOfMonth(value).AddMonths(1).AddDays(-1);

        }
        //public static DateTime LastDayOfMonth(this DateTime value)
        //{
        //    return new DateTime(value.Year, value.Month, value.DaysInMonth());
        //}
        public static int DaysInMonth(this DateTime value)
        {
            return DateTime.DaysInMonth(value.Year, value.Month);
        }
        public static string ToMonthName(this string value)
        {

            int Month = Convert.ToInt32(value);

            var oDateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;

            string MonthName = oDateTimeFormat.GetMonthName(Month);
            string AbbreviatedMonthName = oDateTimeFormat.GetAbbreviatedMonthName(Month);

            return AbbreviatedMonthName;
        }
        public static int ToMonthNumber(this string value)
        {
            return DateTime.ParseExact(value, "MMM", CultureInfo.InvariantCulture).Month;
        }
        public static DateTime GetCustomDate(int payDay, string payMonth, int payYear)
        {
            int MonthInDigit = DateTime.ParseExact(payMonth, "MMM", CultureInfo.InvariantCulture).Month;
            DateTime Date = new DateTime(payYear, MonthInDigit, payDay);

            return Date;
        }

        public static DateTime GetCustomDate(int payDay, int payMonth, int payYear)
        {
            DateTime Date = new DateTime(payYear, payMonth, payDay);

            return Date;
        }

        public static int MonthDifference(this DateTime lValue, DateTime rValue)
        {
            return (lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year);
        }

        public static int DaysDifference(this DateTime FValue, DateTime TValue)
        {
            return (FValue - TValue).Days;
        }

        public static SelectList GetMonthInDays(string monthName, int year)
        {
            int month = DateTimeHelper.ToMonthNumber(monthName);
            DateTime AttendanceDate = new DateTime(year, month, 1);
            var DaysInMonth = AttendanceDate.DaysInMonth();
            var ListOfDays = new List<string>(DaysInMonth);

            for (int day = 1; day <= DaysInMonth; day++)
            {
                ListOfDays.Add(day.ToString());
            }

            var DaysInMonthList = new SelectList(ListOfDays);
            return DaysInMonthList;
        }





        public static IEnumerable<KeyValuePair<int, string>> GetMonthList(int FromMonth, int ToMonth)
        {

            for (int i = FromMonth; i <= ToMonth; i++)
            {
                yield return new KeyValuePair<int, string>(i, DateTimeFormatInfo.CurrentInfo.GetMonthName(i));
            }
        }



        public static IEnumerable<KeyValuePair<int, int>> GetYearList(int FromYear, int ToYear)
        {

            for (int i = FromYear; i <= ToYear; i++)
            {
                yield return new KeyValuePair<int, int>(i, i);
            }
        }

        public static IEnumerable<KeyValuePair<int, string>> GetCurrentMonthListByYear(long selectedYear)
        {
            var IsCurrentYearSelected = false;
            if (selectedYear <= 0 || selectedYear == DateTime.Now.Year)
            {
                IsCurrentYearSelected = true;
            }
            if (IsCurrentYearSelected)
            {
                var CurrentMonth = DateTime.Now.Month;
                return GetMonthList(CurrentMonth, 12);
            }
            return GetMonthList(1, 12);
        }

        public static IEnumerable<KeyValuePair<int, string>> GetCurrentFutureMonthList(long selectedMonth)
        {
            var IsCurrentMonthSelected = false;
            if (selectedMonth <= 0 || selectedMonth >= DateTime.Now.Month)
            {
                IsCurrentMonthSelected = true;
            }
            if (IsCurrentMonthSelected)
            {
                var CurrentMonth = DateTime.Now.Month;
                return GetMonthList(CurrentMonth, 12);
            }
            return GetMonthList(1, 12);
        }


        /// <summary>
        /// This method is Written to get past hours like 
        /// 1- 10 Minutes Ago.
        /// 2- 3  Days Ago.
        /// 3- 5  Days Ago.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static String TimeAgo(this DateTimeOffset dateTime)
        {
            String result = string.Empty;
            var timeSpan = DateTimeOffset.Now.Subtract(dateTime);

            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                result = String.Format("{0} seconds ago", timeSpan.Seconds);
            }
            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                result = timeSpan.Minutes > 1 ?
                    String.Format("{0} minutes ago", timeSpan.Minutes) :
                    "a minute ago";
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                result = timeSpan.Hours > 1 ?
                    String.Format("{0} hours ago", timeSpan.Hours) :
                    "an hour ago";
            }
            else if (timeSpan <= TimeSpan.FromDays(30))
            {
                result = timeSpan.Days > 1 ?
                    String.Format("{0} days ago", timeSpan.Days) :
                    "yesterday";
            }
            else if (timeSpan <= TimeSpan.FromDays(365))
            {
                result = timeSpan.Days > 30 ?
                    String.Format("{0} months ago", timeSpan.Days / 30) :
                    "a month ago";
            }
            else
            {
                result = timeSpan.Days > 365 ?
                    String.Format("{0} years ago", timeSpan.Days / 365) :
                    "a year ago";
            }

            return result;
        }
    }
}
