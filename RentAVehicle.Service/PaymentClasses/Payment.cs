using RentAVehicle.Service.ReservationClasses;
using RentAVehicle.Service.VehicleClasses;

namespace RentAVehicle.Service.PaymentClasses
{
    public class Payment
    {
        private string id;
        private decimal amount;
        private Reservation reservation;
        private DateTime paymentDate;
        private PaymentMethod paymentMethod;

        public Payment(Reservation reservation)
        {
            id = IdGenerator.Make();
            Vehicle vehicle = reservation.GetVehicle();
            int totalDays = reservation.GetTotalDays();
            decimal dailyPrice = vehicle.GetDailyPrice();

            this.reservation = reservation;
            this.amount = totalDays * dailyPrice;
        }

        public void ExecutePayment(DateTime paymentDate, PaymentMethod paymentMethod)
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
            return $"Reservation = {reservation}, Amount = {amount}, PaymentDate = {paymentDate}, paymentMethod = {paymentMethod}";
        }
    }
}
