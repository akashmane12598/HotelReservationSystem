using HotelReservationSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservationSystemTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// TC1 Check whether Hotel is added or not
        /// </summary>
        [TestMethod]
        public void AddHotelandTest_TC1()
        {
            string hotelName = "Lakewood";

            string customerType = "Regular";

            HotelReservation reservation = new HotelReservation();

            reservation.AddHotel(hotelName, customerType);

            Assert.AreEqual(1, reservation.list.Count);

        }

        /// <summary>
        /// TC2 Compare the Cheapest Hotel for Given Date
        /// </summary>
        [TestMethod]
        public void FindCheapestHotelForGivenDate_TC2()
        {
            string[] date = "11Sep2020,12Sep2020".Split(",");

            string expectedHotel = "Lakewood";

            int expectedRate = 200;

            string actualHotel="";

            int actualRate=0;

            try
            {

                HotelReservation reservation = new HotelReservation();

                Dictionary<string, int> hotel = reservation.FindCheapestRates("Regular", date);

                foreach(KeyValuePair<string, int> kv in hotel)
                {
                    actualHotel = kv.Key;

                    actualRate = kv.Value;
                }

                Assert.AreEqual(expectedHotel, actualHotel);

                Assert.AreEqual(expectedRate, actualRate);

            }
            catch (HotelCustomException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        /// <summary>
        /// TC6 Compare the Cheapest Hotel for Given Date
        /// </summary>
        [TestMethod]
        public void FindCheapestAndBestHotelForGivenDate_TC6()
        {
            string[] date = "11Sep2020,12Sep2020".Split(",");

            string expectedHotel = "Bridgewood";

            int expectedRate = 200;

            string actualHotel = "";

            int actualRate = 0;

            try
            {

                HotelReservation reservation = new HotelReservation();

                Dictionary<string, int> hotel = reservation.FindCheapestRatesAndBestRatingHotel("Regular", date);

                foreach (KeyValuePair<string, int> kv in hotel)
                {
                    actualHotel = kv.Key;

                    actualRate = kv.Value;
                }

                Assert.AreEqual(expectedHotel, actualHotel);

                Assert.AreEqual(expectedRate, actualRate);

            }
            catch (HotelCustomException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        /// <summary>
        /// TC7 Compare the Best Hotel for Given Date
        /// </summary>
        [TestMethod]
        public void FindBestHotelForGivenDate_TC7()
        {
            string[] date = "11Sep2020,12Sep2020".Split(",");

            string expectedHotel = "Ridgewood";

            int expectedRate = 370;

            string actualHotel = "";

            int actualRate = 0;

            try
            {

                HotelReservation reservation = new HotelReservation();

                Dictionary<string, int> hotel = reservation.FindBestRatingHotel("Regular", date);

                foreach (KeyValuePair<string, int> kv in hotel)
                {
                    actualHotel = kv.Key;

                    actualRate = kv.Value;
                }

                Assert.AreEqual(expectedHotel, actualHotel);

                Assert.AreEqual(expectedRate, actualRate);

            }
            catch (HotelCustomException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        /// <summary>
        /// TC10 FindCheapestAndBestHotelForRewardedCustomers
        /// </summary>
        [TestMethod]
        public void FindCheapestAndBestHotelForRewardedCustomers_TC10()
        {
            string[] date = "11Sep2020,12Sep2020".Split(",");

            string expectedHotel = "Ridgewood";

            int expectedRate = 140;

            string actualHotel = "";

            int actualRate = 0;

            try
            {

                HotelReservation reservation = new HotelReservation();

                Dictionary<string, int> hotel = reservation.FindCheapestRatesAndBestRatingHotel("Rewards", date);

                foreach (KeyValuePair<string, int> kv in hotel)
                {
                    actualHotel = kv.Key;

                    actualRate = kv.Value;
                }

                Assert.AreEqual(expectedHotel, actualHotel);

                Assert.AreEqual(expectedRate, actualRate);

            }
            catch (HotelCustomException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
