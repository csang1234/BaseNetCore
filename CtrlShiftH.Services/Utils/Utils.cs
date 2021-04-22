using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CtrlShiftH.Services.Utils
{
    public static class Utils
    {
        public static readonly CultureInfo cultureInfo = CultureInfo.GetCultureInfo("vi-VN");
        public static readonly string[] dateTimeFormats 
            = new string[] {
                "yyyy",
                "dd/MM/yyyy",
                "dd-MM-yyyy",
                "dd/MM/yyyy HH:mm", 
                "dd/MM/yyyy h:mm tt",
                "dd/MM/yyyy hh:mm tt",
                "dd/MM/yyyy hh:mm:ss",
                "dd/MM/yyyy hh:mm:ss tt",
                "dd-MM-yyyy HH:mm", 
                "dd-MM-yyyy h:mm tt",
                "dd-MM-yyyy hh:mm tt",
                "dd-MM-yyyy hh:mm:ss",
                "dd-MM-yyyy hh:mm:ss tt"};

        //public static string GetPropertyNameInVNese(string property)
        //{
        //    switch (property)
        //    {

        //    }
        //}

        public static string ToShortCode(this string code)
        {
            string result = code;
            // remove disease code
            result = result.Remove(0, 3);
            // remove year
            result = result.Remove(3, 2);
            return result;
        }

        public static bool EqualDate(this DateTime date1, DateTime date2)
        {
            if (date1 == null && date2 == null)
                return true;
            else if (date1 == null || date2 == null)
                return false;
            else if (date1.ToShortDateString() == date2.ToShortDateString())
                return true;
            else
                return false;
        }

        /// <summary>
        /// dd/MM/yyyy
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToVNDate(this DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// dd/MM/yyyy HH:mm
        /// </summary>
        /// <param name="date"></param>
        /// <returns>dd/MM/yyyy HH:mm</returns>
        public static string ToVNDateTime(this DateTime date)
        {
            return date.ToString("dd/MM/yyyy HH:mm");
        }

        /// <summary>
        /// dd/MM/yyyy hh:mm tt
        /// </summary>
        /// <param name="date"></param>
        /// <returns>dd/MM/yyyy hh:mm tt</returns>
        public static string ToVNDateTime2(this DateTime date)
        {
            return date.ToString("dd/MM/yyyy hh:mm tt");
        }

        public static DateTime tryParseDateTime(this string dateS)
        {
            try
            {
                var result = DateTime.ParseExact(dateS, dateTimeFormats, CultureInfo.InvariantCulture);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
