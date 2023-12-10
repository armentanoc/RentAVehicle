using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RentAVehicle.Service.PersonClasses
{
    public class Client : Person
    {
        public Client(string name, string phone, string email)
            : base(name, phone, email) { }

        public override string ToString()
        {
            return $"Nome = {this.GetName()}, Telefone = {this.GetPhone()}, Id = {this.GetId()}";
        }
    }
}

