using RentAVehicle.Service.People;
using RentAVehicle.Service.ProcessPayments;
using RentAVehicle.Service.VehicleInformation;

namespace RentAVehicle.Service.MakeReservation
{
    public class Reservation
    {
        private string id;
        private Vehicle vehicle;
        private Client client;
        private Salesperson salesperson;
        private DateTime startDate;
        private DateTime endDate;
        public bool IsPaid { get; private set; }
        private int totalDays;

        public Reservation(Salesperson salesperson, Vehicle vehicle, Client client, DateTime startDate, DateTime endDate)
        {
            id = IdGenerator.Make();
            this.salesperson = salesperson;
            this.vehicle = vehicle;
            this.client = client;
            this.startDate = startDate;
            this.endDate = endDate;

            IsPaid = false;

            TimeSpan difference = endDate - startDate;
            totalDays = difference.Days;

            salesperson.IncreaseNumberOfReservations();

        }

        public void ExecutePayment(Salesperson salesperson, DateTime paymentDate, PaymentMethodEnum paymentMethod, Reservation reservation)
        {
            Payment payment = new Payment(reservation);
            salesperson.IncreaseAmountOfSales(payment.GetAmount());
        }

        public int GetTotalDays()
        {
            return totalDays;
        }

        public Vehicle GetVehicle()
        {
            return vehicle;
        }

        public override string ToString()
        {
            return $"Marca = {vehicle.GetBrand()}, Modelo = {vehicle.GetModel()}, Está pago = {IsPaid}, Data de Início = {startDate}, " +
                $"Data Final = {endDate}, Dias Totais = {totalDays}, Vendedor = {salesperson.GetName()}, Cliente = {client.GetName()}";
        }

        public Salesperson GetSalesPerson()
        {
            return salesperson;
        }

        public DateTime GetStartDate()
        {
            return startDate;
        }

        public DateTime GetEndDate()
        {
            return endDate;
        }
        public string GetId()
        {
            return id;
        }

        internal void SetIsPaid(bool isPaid)
        {
            IsPaid = true;
        }
    }
}
