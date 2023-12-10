
using RentAVehicle.Service.PersonClasses;
using RentAVehicle.Service.VehicleClasses;
using RentAVehicle.Service.PaymentClasses;
using RentAVehicle.Service.ReservationClasses;

namespace RentAVehicle.Service
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehiclesList = VehicleList.Generate();

            Client client =
                new Client("Ana Carolina", "71991562955", "armentanocarolina@gmail.com");

            Salesperson salesperson =
                new Salesperson("Ingryd", "71984535950", "eingrydalves@gmail.com");

            Console.WriteLine("\nCliente: " + client.ToString());
            Console.WriteLine("\nVendedor antes da reserva: " + salesperson.ToString());

            DateTime startDate = DateTime.Today;
            DateTime endDate = startDate.AddDays(5);

            Reservation reservation = new Reservation(salesperson, vehiclesList[0], client, startDate, endDate);
            Console.WriteLine("\nReserva: " + reservation.ToString());
            
            PrintAvailableVehicles(vehiclesList);
       
            Console.WriteLine("\nVendedor após a reserva e antes do pagamento: " + salesperson.ToString());

            Payment payment = new Payment(reservation);

            Console.WriteLine("\nObjeto pagamento antes de executar/efetuar: " + payment.ToString());
            Console.WriteLine("\nValor a pagar: " + payment.GetAmount());
            
            payment.ExecutePayment(startDate, PaymentMethod.creditCard);
            Console.WriteLine("\nObjeto pagamento após executar/efetuar: " + payment.ToString());

            Console.WriteLine("\nVendedor após a reserva e depois do pagamento: " + salesperson.ToString());

        }

        private static void PrintAvailableVehicles(List<Vehicle> vehiclesList)
        {
            Console.WriteLine("\nLista de Veículos: ");
            foreach(Vehicle vehicle in vehiclesList)
            {
                Console.WriteLine(vehicle.ToString());
            }
        }
    }
}
