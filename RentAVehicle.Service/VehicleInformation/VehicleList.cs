
namespace RentAVehicle.Service.VehicleInformation
{
    internal class VehicleList
    {
        public static List<Vehicle> Generate()
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            Vehicle vehicle;

            vehicle = new Vehicle(VehicleTypeEnum.car, "Ford", "Ka", "Preto", "PKO1073", 100);
            vehicleList.Add(vehicle);

            vehicle = new Vehicle(VehicleTypeEnum.car, "Ford", "Fiesta", "Branco", "ANA1073", 120);
            vehicleList.Add(vehicle);

            vehicle = new Vehicle(VehicleTypeEnum.car, "Chevrolet", "Ônix", "Prata", "PMU89D5", 130);
            vehicleList.Add(vehicle);

            vehicle = new Vehicle(VehicleTypeEnum.car, "Hiunday", "Creta", "Branco", "PKO13S5", 200);
            vehicleList.Add(vehicle);

            vehicle = new Vehicle(VehicleTypeEnum.motorcycle, "Honda", "CG150", "Preta", "CSF5648", 60);
            vehicleList.Add(vehicle);

            return vehicleList;
        }
    }
}
