
using System.Globalization;

namespace RentAVehicle.Service.People

{
    public class Salesperson : Person
    {
        private string matricula;
        private int totalReservations = 0;
        private decimal amountOfSales = 0;
        public Salesperson(string name, string phone, string? email) : base(name, phone, email)
        {
            matricula = IdGenerator.Make();
        }
        public override string ToString()
        {
            return $"Nome = {GetName()}, Total de Reservas = {totalReservations}, Valor vendido = {amountOfSales.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}";
        }

        public void IncreaseAmountOfSales(decimal newSale)
        {
            amountOfSales += newSale;
        }

        public void IncreaseNumberOfReservations()
        {
            totalReservations += 1;
        }
    }
}
