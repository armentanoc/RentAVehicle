using RentAVehicle.Service.MakeReservation;
using RentAVehicle.Service.VehicleInformation;

namespace RentAVehicle.Service.ProcessPayments
{
    public class Payment
    {
        private string id;
        private decimal amount;
        private Reservation reservation;
        private DateTime paymentDate;
        private PaymentMethodEnum paymentMethod;

        public Payment(Reservation reservation)
        {
            id = IdGenerator.Make();
            Vehicle vehicle = reservation.GetVehicle();
            int totalDays = reservation.GetTotalDays();
            decimal dailyPrice = vehicle.GetDailyPrice();

            this.reservation = reservation;
            amount = totalDays * dailyPrice;
        }

        public void ExecutePayment(DateTime paymentDate, PaymentMethodEnum paymentMethod)
        {
            this.paymentDate = paymentDate;
            this.paymentMethod = paymentMethod;
            reservation.ExecutePayment(reservation.GetSalesPerson(), paymentDate, paymentMethod, reservation);
        }

        public decimal GetAmount()
        {
            return amount;
        }

        public override string ToString()
        {
            return $"Valor = {amount}, Data de Pagamento = {paymentDate}, Método de Pagamento = {paymentMethod}, Reserva = {reservation.GetId()}";
        }
    }
}
