namespace RentAVehicle.Service.PersonClasses
{
    public class Person
    {

        private string id;
        private string name;
        private string phone;
        private string? email;

        public Person(string name, string phone, string? email)
        {
            this.name = name;
            this.phone = phone;
            this.email = email;
            id = IdGenerator.Make();
        }

        public string GetPhone()
        {
            return this.phone;
        }

        public string GetName()
        {
            return this.name;
        }

        public string GetId()
        {
            return this.id;
        }
    }
}
