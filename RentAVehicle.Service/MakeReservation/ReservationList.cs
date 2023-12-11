
namespace RentAVehicle.Service.MakeReservation
{
    public class ReservationList
    {
        public static List<Reservation> Generate()
        {
            List<Reservation> reservationList = new List<Reservation>();
            Reservation reservation;
            return reservationList;
        }

        public static void PrintReservations(List<Reservation> reservationsList)
        {
            Console.WriteLine("\n===== Reservas =====");
            int counter = 0;
            foreach (Reservation reservation in reservationsList)
            {
                Console.WriteLine($"{counter} - {reservation.ToString()}");
                counter++;
            }
        }
    }
}
