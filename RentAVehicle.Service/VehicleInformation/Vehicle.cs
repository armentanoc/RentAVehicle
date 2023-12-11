

using System.Globalization;

namespace RentAVehicle.Service.VehicleInformation
{
    public class Vehicle
    {

        private string id;
        private string licensePlate;
        private string color;
        private string brand;
        private string model;
        private VehicleTypeEnum vehicleType;
        private VehicleStatus vehicleStatus;
        private decimal dailyPrice;
        public Vehicle(VehicleTypeEnum vehicleType, string brand, string model, string color, string licensePlate, decimal dailyPrice)
        {
            this.licensePlate = licensePlate;
            this.vehicleType = vehicleType;
            this.dailyPrice = dailyPrice;
            this.brand = brand;
            this.model = model;
            this.color = color;
            this.vehicleStatus = VehicleStatus.Available;
            id = IdGenerator.Make();
        }

        internal decimal GetDailyPrice()
        {
            return dailyPrice;
        }

        public override string ToString()
        {
            return $"Marca = {brand}, Modelo = {model}, Tipo = {vehicleType}, Status = {vehicleStatus}, Cor = {color},  Diária = {dailyPrice.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}";
        }

        public string GetBrand()
        {
            return brand;
        }

        public string GetModel()
        {
            return model;
        }

        public string GetId()
        {
            return id;
        }

        public void SetStatus(VehicleStatus vehicleStatus)
        {
            this.vehicleStatus = vehicleStatus;
        }

        public VehicleStatus GetStatus()
        {
            return vehicleStatus;
        }
    }
}