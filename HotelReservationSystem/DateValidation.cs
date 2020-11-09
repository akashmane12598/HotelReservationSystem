using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class DateValidation
    {
        /// <summary>
        /// Validates the dates passed as string and converts into Days of week
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string[] Validate(string[] date)
        {
            if (date == null)
            {
                throw new HotelCustomException(HotelCustomException.ExceptionType.INVALID_DATE, "Dates are null");
            }

            DateTime startDate = ConvertToDate(date[0]);

            DateTime endDate = ConvertToDate(date[1]);

            if(startDate>endDate)
            {
                throw new HotelCustomException(HotelCustomException.ExceptionType.INVALID_DATE, "Invalid Dates");
            }

            string[] days = new string[]
            {
                startDate.DayOfWeek.ToString(), endDate.DayOfWeek.ToString()
            };

            return days;
        }

        public static DateTime ConvertToDate(string date)
        {
            try
            {
                DateTime requiredDate = DateTime.Parse(date);
                return requiredDate;
            }
            catch(FormatException)
            {
                throw new HotelCustomException(HotelCustomException.ExceptionType.INVALID_DATE_FORMAT, "Invalid Date Format");
            }
        }
    }
}
