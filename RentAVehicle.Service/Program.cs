using RentAVehicle.Service.VehicleInformation;
using RentAVehicle.Service.ProcessPayments;
using RentAVehicle.Service.People;
using RentAVehicle.Service.MakeReservation;

namespace RentAVehicle.Service
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehiclesList = VehicleList.Generate();
            List<Client> clientsList = ClientList.Generate();
            List<Salesperson> salespersonList = SalespersonList.Generate();
           
            Console.WriteLine("\nCliente: " + clientsList[0].ToString());
            Console.WriteLine("\nVendedor antes da reserva: " + salespersonList[0].ToString());

            DateTime startDate = DateTime.Today;
            DateTime endDate = startDate.AddDays(5);

            Reservation reservation = new Reservation(salespersonList[0], vehiclesList[0], clientsList[0], startDate, endDate);
            Console.WriteLine("\nReserva: " + reservation.ToString());
            
            PrintAvailableVehicles(vehiclesList);
       
            Console.WriteLine("\nVendedor após a reserva e antes do pagamento: " + salespersonList[0].ToString());

            Payment payment = new Payment(reservation);

            Console.WriteLine("\nObjeto pagamento antes de executar/efetuar: " + payment.ToString());
            Console.WriteLine("\nValor a pagar: " + payment.GetAmount());
            
            payment.ExecutePayment(startDate, PaymentMethodEnum.creditCard);
            Console.WriteLine("\nObjeto pagamento após executar/efetuar: " + payment.ToString());

            Console.WriteLine("\nVendedor após a reserva e depois do pagamento: " + salespersonList[0].ToString());

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
