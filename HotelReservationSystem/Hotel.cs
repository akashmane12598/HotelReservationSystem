using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class Hotel
    {
        public string hotelName;

        public int rates;

        public int ratings;

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="hotelName"></param>
        /// <param name="rates"></param>
        /// <param name="ratings"></param>
        public Hotel(string hotelName, int rates, int ratings)
        {
            this.hotelName = hotelName;

            this.rates = rates;

            this.ratings=ratings;

        }
    }
}
