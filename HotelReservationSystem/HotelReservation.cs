using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class HotelReservation
    {
        public List<Hotel> list;

        public HotelReservation()
        {
            list = new List<Hotel>();
        }


        /// <summary>
        /// UC1 Choose Desired Hotel
        /// </summary>
        /// <param name="hotelName"></param>
        public void AddHotel(string hotelName)
        {
            Hotel hotel;
            if (hotelName.Equals("Lakewood"))
            {
                hotel = new Hotel(hotelName, 110, 3);
                list.Add(hotel);
            }
            else if (hotelName.Equals("Bridgewood"))
            {
                hotel = new Hotel(hotelName, 160, 4);
                list.Add(hotel);
            }
            else if (hotelName.Equals("Ridgewood"))
            {
                hotel = new Hotel(hotelName, 220, 5);
                list.Add(hotel);
            }
            else
            {
                throw new HotelCustomException(HotelCustomException.ExceptionType.INVALID_HOTEL_NAME, "Invalid Hotel Name");
            }            
        }

        public void GetReservation(string customerType, string[] dates)
        {

        }
    }
}
