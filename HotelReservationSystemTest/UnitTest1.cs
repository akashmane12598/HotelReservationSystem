using HotelReservationSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            HotelReservation reservation = new HotelReservation();

            reservation.AddHotel(hotelName);

            Assert.AreEqual(1, reservation.list.Count);

        }
    }
}
