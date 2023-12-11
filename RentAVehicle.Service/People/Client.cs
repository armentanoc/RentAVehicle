
namespace RentAVehicle.Service.People
{
    public class Client : Person
    {
        public Client(string name, string phone, string email)
            : base(name, phone, email) { }

        public override string ToString()
        {
            return $"Nome = {GetName()}, Telefone = {GetPhone()}, Id = {GetId()}";
        }
    }
}

