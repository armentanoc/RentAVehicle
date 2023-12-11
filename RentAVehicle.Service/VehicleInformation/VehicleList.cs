


using System.Diagnostics.Metrics;

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
        public static void PrintAvailableVehicles(List<Vehicle> vehiclesList)
        {
            Console.WriteLine("\n===== Veículos Disponíveis =====");
        
            foreach (Vehicle vehicle in vehiclesList)
            {
                if(vehicle.GetStatus().Equals(VehicleStatus.Available))
                Console.WriteLine(vehicle.ToString());
            }
        }

        public static void PrintRentedVehicles(List<Vehicle> vehiclesList)
        {
            Console.WriteLine("\n===== Rented Vehicles =====");

            foreach (Vehicle vehicle in vehiclesList)
            {
                if (vehicle.GetStatus().Equals(VehicleStatus.Rented))
                    Console.WriteLine(vehicle.ToString());
            }
        }
    }
}
