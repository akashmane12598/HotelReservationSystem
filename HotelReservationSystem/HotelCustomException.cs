using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    /// <summary>
    /// Used to throw Custom Exceptions
    /// </summary>
    public class HotelCustomException:Exception
    {
        public ExceptionType type;

        public enum ExceptionType
        {
            INVALID_HOTEL_NAME, INVALID_DATE, INVALID_CUSTOMER_TYPE
        }

        public HotelCustomException(ExceptionType type, string msg):base(msg)
        {
            this.type = type;
        }

    }
}
