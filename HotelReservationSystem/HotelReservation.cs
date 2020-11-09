using System;
using System.Collections.Generic;
using System.Linq;
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
        public void AddHotel(string hotelName, string customerType)
        {
            Hotel hotel;
            if (customerType.Equals("Regular"))
            {
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
            else if (customerType.Equals("Rewards"))
            {
                if (hotelName.Equals("Lakewood"))
                {
                    hotel = new Hotel(hotelName, 80, 3);
                    list.Add(hotel);
                }
                else if (hotelName.Equals("Bridgewood"))
                {
                    hotel = new Hotel(hotelName, 110, 4);
                    list.Add(hotel);
                }
                else if (hotelName.Equals("Ridgewood"))
                {
                    hotel = new Hotel(hotelName, 100, 5);
                    list.Add(hotel);
                }
                else
                {
                    throw new HotelCustomException(HotelCustomException.ExceptionType.INVALID_HOTEL_NAME, "Invalid Hotel Name");
                }
            }
            else
            {
                throw new HotelCustomException(HotelCustomException.ExceptionType.INVALID_CUSTOMER_TYPE, "Invalid Customer Type");
            }
        }


        /// <summary>
        /// UC2 Find the Cheapest Hotel and it's Rate for a given date
        /// </summary>
        /// <param name="customerType"></param>
        /// <param name="dates"></param>
        /// <returns></returns>
        public Dictionary<string, int> FindCheapestRates(string customerType, string[] dates)
        {
            Dictionary<string, int> hotelDetails = new Dictionary<string, int>();

            if (customerType.Equals("Regular"))
            { 
                int rateOfLake = 0;
                int rateOfBridge = 0;
                int rateOfRidge = 0;
                foreach (string date in dates)
                {
                    string day = DateTime.Parse(date).DayOfWeek.ToString();

                    if(day.Equals("Saturday") || day.Equals("Sunday"))
                    {
                        rateOfLake += 90;
                        rateOfBridge += 60;
                        rateOfRidge += 150;
                    }
                    else
                    {
                        AddHotel("Lakewood", customerType);
                        rateOfLake = list.Where(x=>x.hotelName.Equals("Lakewood")).Sum(x => x.rates);
                        
                        AddHotel("Bridgewood", customerType);
                        rateOfBridge = list.Where(x=>x.hotelName.Equals("Bridgewood")).Sum(x => x.rates);
                        
                        AddHotel("Ridgewood", customerType);
                        rateOfRidge = list.Where(x => x.hotelName.Equals("Ridgewood")).Sum(x => x.rates);
                        
                    }
                }
                hotelDetails.Add("Lakewood", rateOfLake);
                hotelDetails.Add("Bridgewood", rateOfBridge);
                hotelDetails.Add("Ridgewood", rateOfRidge);

                int min = hotelDetails.Select(x => x.Value).Min();

                Dictionary<string, int> cheapHotel = new Dictionary<string, int>();

                foreach (KeyValuePair<string, int> kv in hotelDetails)
                {
                    if (kv.Value==min)
                    {
                        cheapHotel.Add(kv.Key, kv.Value);
                    }
                }
                return cheapHotel;
            }
            else if (customerType.Equals("Rewards"))
            {
                int rateOfLake = 0;
                int rateOfBridge = 0;
                int rateOfRidge = 0;
                foreach (string date in dates)
                {
                    string day = DateTime.Parse(date).DayOfWeek.ToString();

                    if (day.Equals("Saturday") || day.Equals("Sunday"))
                    {
                        rateOfLake += 80;
                        rateOfBridge += 50;
                        rateOfRidge += 40;
                    }
                    else
                    {
                        AddHotel("Lakewood", customerType);
                        rateOfLake = list.Where(x => x.hotelName.Equals("Lakewood")).Sum(x => x.rates);

                        AddHotel("Bridgewood", customerType);
                        rateOfBridge = list.Where(x => x.hotelName.Equals("Bridgewood")).Sum(x => x.rates);

                        AddHotel("Ridgewood", customerType);
                        rateOfRidge = list.Where(x => x.hotelName.Equals("Ridgewood")).Sum(x => x.rates);

                    }
                }

                hotelDetails.Add("Lakewood", rateOfLake);
                hotelDetails.Add("Bridgewood", rateOfBridge);
                hotelDetails.Add("Ridgewood", rateOfRidge);

                int min = hotelDetails.Select(x => x.Value).Min();

                Dictionary<string, int> cheapHotel = new Dictionary<string, int>();

                foreach (KeyValuePair<string, int> kv in hotelDetails)
                {
                    if (kv.Value == min)
                    {
                        cheapHotel.Add(kv.Key, kv.Value);
                    }
                }
                return cheapHotel;
            }
            else
            {
                throw new HotelCustomException(HotelCustomException.ExceptionType.INVALID_CUSTOMER_TYPE,"Invalid Customer Type");
            }
        }

        /// <summary>
        /// UC6 Find the Cheapest Hotel and it's Rate for a given date
        /// </summary>
        /// <param name="customerType"></param>
        /// <param name="dates"></param>
        /// <returns></returns>
        public Dictionary<string, int> FindCheapestRatesAndBestRatingHotel(string customerType, string[] dates)
        {
            Dictionary<string, int> hotelDetails = new Dictionary<string, int>();

            if (customerType.Equals("Regular"))
            {
                int rateOfLake = 0;
                int rateOfBridge = 0;
                int rateOfRidge = 0;
                foreach (string date in dates)
                {
                    string day = DateTime.Parse(date).DayOfWeek.ToString();

                    if (day.Equals("Saturday") || day.Equals("Sunday"))
                    {
                        rateOfLake += 90;
                        rateOfBridge += 60;
                        rateOfRidge += 150;
                    }
                    else
                    {
                        AddHotel("Lakewood", customerType);
                        rateOfLake = list.Where(x => x.hotelName.Equals("Lakewood")).Sum(x => x.rates);

                        AddHotel("Bridgewood", customerType);
                        rateOfBridge = list.Where(x => x.hotelName.Equals("Bridgewood")).Sum(x => x.rates);

                        AddHotel("Ridgewood", customerType);
                        rateOfRidge = list.Where(x => x.hotelName.Equals("Ridgewood")).Sum(x => x.rates);

                    }
                }
                hotelDetails.Add("Lakewood", rateOfLake);
                hotelDetails.Add("Bridgewood", rateOfBridge);
                hotelDetails.Add("Ridgewood", rateOfRidge);

                int min = hotelDetails.Select(x => x.Value).Min();

                Dictionary<string, int> cheapHotel = new Dictionary<string, int>();

                foreach (KeyValuePair<string, int> kv in hotelDetails)
                {
                    if (kv.Value == min)
                    {
                        if (kv.Key.Equals("Ridgewood"))
                        {
                            cheapHotel.Add(kv.Key, kv.Value);
                        }
                        else if (kv.Key.Equals("Bridgewood"))
                        {
                            cheapHotel.Add(kv.Key, kv.Value);
                        }
                        else if (kv.Key.Equals("Lakewood"))
                        {
                            cheapHotel.Add(kv.Key, kv.Value);
                        }
                    }
                }
                return cheapHotel;
            }
            else if (customerType.Equals("Rewards"))
            {
                int rateOfLake = 0;
                int rateOfBridge = 0;
                int rateOfRidge = 0;
                foreach (string date in dates)
                {
                    string day = DateTime.Parse(date).DayOfWeek.ToString();

                    if (day.Equals("Saturday") || day.Equals("Sunday"))
                    {
                        rateOfLake += 80;
                        rateOfBridge += 50;
                        rateOfRidge += 40;
                    }
                    else
                    {
                        AddHotel("Lakewood", customerType);
                        rateOfLake = list.Where(x => x.hotelName.Equals("Lakewood")).Sum(x => x.rates);

                        AddHotel("Bridgewood", customerType);
                        rateOfBridge = list.Where(x => x.hotelName.Equals("Bridgewood")).Sum(x => x.rates);

                        AddHotel("Ridgewood", customerType);
                        rateOfRidge = list.Where(x => x.hotelName.Equals("Ridgewood")).Sum(x => x.rates);

                    }
                }

                hotelDetails.Add("Lakewood", rateOfLake);
                hotelDetails.Add("Bridgewood", rateOfBridge);
                hotelDetails.Add("Ridgewood", rateOfRidge);

                int min = hotelDetails.Select(x => x.Value).Min();

                Dictionary<string, int> cheapHotel = new Dictionary<string, int>();

                foreach (KeyValuePair<string, int> kv in hotelDetails)
                {
                    if (kv.Value == min)
                    {
                        if (kv.Key.Equals("Ridgewood"))
                        {
                            cheapHotel.Add(kv.Key, kv.Value);
                        }
                        else if (kv.Key.Equals("Bridgewood"))
                        {
                            cheapHotel.Add(kv.Key, kv.Value);
                        }
                        else if (kv.Key.Equals("Lakewood"))
                        {
                            cheapHotel.Add(kv.Key, kv.Value);
                        }
                    }
                }
                return cheapHotel;
            }
            else
            {
                throw new HotelCustomException(HotelCustomException.ExceptionType.INVALID_CUSTOMER_TYPE, "Invalid Customer Type");
            }
        }

        /// <summary>
        /// UC7 Find the Best Hotel for a given date
        /// </summary>
        /// <param name="customerType"></param>
        /// <param name="dates"></param>
        /// <returns></returns>
        public Dictionary<string, int> FindBestRatingHotel(string customerType, string[] dates)
        {
            Dictionary<string, int> hotelDetails = new Dictionary<string, int>();

            if (customerType.Equals("Regular"))
            {
                int rateOfLake = 0;
                int rateOfBridge = 0;
                int rateOfRidge = 0;
                foreach (string date in dates)
                {
                    string day = DateTime.Parse(date).DayOfWeek.ToString();

                    if (day.Equals("Saturday") || day.Equals("Sunday"))
                    {
                        rateOfLake += 90;
                        rateOfBridge += 60;
                        rateOfRidge += 150;
                    }
                    else
                    {
                        AddHotel("Lakewood", customerType);
                        rateOfLake = list.Where(x => x.hotelName.Equals("Lakewood")).Sum(x => x.rates);

                        AddHotel("Bridgewood", customerType);
                        rateOfBridge = list.Where(x => x.hotelName.Equals("Bridgewood")).Sum(x => x.rates);

                        AddHotel("Ridgewood", customerType);
                        rateOfRidge = list.Where(x => x.hotelName.Equals("Ridgewood")).Sum(x => x.rates);

                    }
                }
                hotelDetails.Add("Lakewood", rateOfLake);
                hotelDetails.Add("Bridgewood", rateOfBridge);
                hotelDetails.Add("Ridgewood", rateOfRidge);

                int max = hotelDetails.Select(x => x.Value).Max();

                Dictionary<string, int> bestHotel = new Dictionary<string, int>();

                foreach (KeyValuePair<string, int> kv in hotelDetails)
                {
                    if (kv.Value == max)
                    {
                        if (kv.Key.Equals("Ridgewood"))
                        {
                            bestHotel.Add(kv.Key, kv.Value);
                        }
                        else if (kv.Key.Equals("Bridgewood"))
                        {
                            bestHotel.Add(kv.Key, kv.Value);
                        }
                        else if (kv.Key.Equals("Lakewood"))
                        {
                            bestHotel.Add(kv.Key, kv.Value);
                        }
                    }
                }
                return bestHotel;
            }
            else if (customerType.Equals("Rewards"))
            {
                int rateOfLake = 0;
                int rateOfBridge = 0;
                int rateOfRidge = 0;
                foreach (string date in dates)
                {
                    string day = DateTime.Parse(date).DayOfWeek.ToString();

                    if (day.Equals("Saturday") || day.Equals("Sunday"))
                    {
                        rateOfLake += 80;
                        rateOfBridge += 50;
                        rateOfRidge += 40;
                    }
                    else
                    {
                        AddHotel("Lakewood", customerType);
                        rateOfLake = list.Where(x => x.hotelName.Equals("Lakewood")).Sum(x => x.rates);

                        AddHotel("Bridgewood", customerType);
                        rateOfBridge = list.Where(x => x.hotelName.Equals("Bridgewood")).Sum(x => x.rates);

                        AddHotel("Ridgewood", customerType);
                        rateOfRidge = list.Where(x => x.hotelName.Equals("Ridgewood")).Sum(x => x.rates);

                    }
                }

                hotelDetails.Add("Lakewood", rateOfLake);
                hotelDetails.Add("Bridgewood", rateOfBridge);
                hotelDetails.Add("Ridgewood", rateOfRidge);

                int max = hotelDetails.Select(x => x.Value).Max();

                Dictionary<string, int> bestHotel = new Dictionary<string, int>();

                foreach (KeyValuePair<string, int> kv in hotelDetails)
                {
                    if (kv.Value == max)
                    {
                        if (kv.Key.Equals("Ridgewood"))
                        {
                            bestHotel.Add(kv.Key, kv.Value);
                        }
                        else if (kv.Key.Equals("Bridgewood"))
                        {
                            bestHotel.Add(kv.Key, kv.Value);
                        }
                        else if (kv.Key.Equals("Lakewood"))
                        {
                            bestHotel.Add(kv.Key, kv.Value);
                        }
                    }
                }
                return bestHotel;
            }
            else
            {
                throw new HotelCustomException(HotelCustomException.ExceptionType.INVALID_CUSTOMER_TYPE, "Invalid Customer Type");
            }
        }
    }
}
