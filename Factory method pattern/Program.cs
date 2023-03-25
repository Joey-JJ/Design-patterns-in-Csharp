// Factory method pattern
using System;


namespace FactoryMethodPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            var factory = new HotelReservationFactory();
            var reservation = factory.CreateReservation();
            reservation.Book();
            Console.WriteLine(reservation.IsBooked);
        }
    }


    public interface Reservation
    {
        bool IsBooked { get; }
        void Book();
    }

    public class HotelReservation : Reservation
    {
        public bool IsBooked { get; private set; }

        public HotelReservation(bool IsBooked) => this.IsBooked = IsBooked;
        public void Book() { IsBooked = true; }
    }

    public interface ReservationFactory
    {
        Reservation CreateReservation();
    }

    public class HotelReservationFactory : ReservationFactory
    {
        public Reservation CreateReservation() => new HotelReservation(false);
    }
}