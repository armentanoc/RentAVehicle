
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
            id = IdGenerator.Make();
            vehicleStatus = VehicleStatus.Available;
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
    }
}