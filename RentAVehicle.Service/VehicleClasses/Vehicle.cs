using RentAVehicle.Service.PersonClasses;

namespace RentAVehicle.Service.VehicleClasses
{
    public class Vehicle
    {

        private string id;
        private string licensePlate;
        private string color;
        private string brand;
        private string model;
        private VehicleType vehicleType;
        private VehicleStatus vehicleStatus;
        private decimal dailyPrice;
        public Vehicle(VehicleType vehicleType, string brand, string model, string color, string licensePlate, decimal dailyPrice)
        {
            this.licensePlate = licensePlate;
            this.vehicleType = vehicleType;
            this.dailyPrice = dailyPrice;
            this.brand = brand;
            this.model = model;
            this.id = IdGenerator.Make();
            this.vehicleStatus = VehicleStatus.Available;
        }

        internal decimal GetDailyPrice()
        {
           return dailyPrice;
        }

        public override string ToString()
        {
            return $"Id = {id}, Marca = {brand}, Modelo = {model}, Tipo = {vehicleType}, Status = {vehicleStatus}";
        }

        public string GetBrand()
        {
            return this.brand;
        }

        public string GetModel()
        {
            return this.model;
        }

        public string GetId()
        {
            return this.id;
        }

        public void SetStatus(VehicleStatus vehicleStatus)
        {
            this.vehicleStatus=vehicleStatus;
        }
    }
}