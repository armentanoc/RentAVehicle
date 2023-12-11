
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
            return $"Matricula = {matricula}, Nome = {GetName()}, Total de Reservas = {totalReservations}, Valor vendido = {amountOfSales}";
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
