﻿using RentAVehicle.Service.PaymentClasses;
using RentAVehicle.Service.PersonClasses;
using RentAVehicle.Service.VehicleClasses;

namespace RentAVehicle.Service.ReservationClasses
{
    public class Reservation
    {
        private string id;
        private Vehicle vehicle;
        private Client client;
        private Salesperson salesperson;
        private DateTime startDate;
        private DateTime endDate;
        private bool isPaid;
        private int totalDays;

        public Reservation(Salesperson salesperson, Vehicle vehicle, Client client, DateTime startDate, DateTime endDate)
        {
            id = IdGenerator.Make();
            this.salesperson = salesperson;
            this.vehicle = vehicle;
            this.client = client;
            this.startDate = startDate;
            this.endDate = endDate;

            isPaid = false;
            vehicle.SetStatus(VehicleStatus.Rented);

            TimeSpan difference = endDate - startDate;
            totalDays = difference.Days;

            salesperson.IncreaseNumberOfReservations();

        }

        public void ExecutePayment(Salesperson salesperson, DateTime paymentDate, PaymentMethod paymentMethod, Reservation reservation)
        {
            Payment payment = new Payment(reservation);
            isPaid = true;
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
            return $"Veículo = {vehicle.GetBrand()}, {vehicle.GetModel()}, {vehicle.GetId()}, isPaid = {isPaid}, totalDays = {totalDays}, id = {id}";
        }

        public Salesperson GetSalesPerson()
        {
            return salesperson;
        }
    }
}