using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAVehicle.Service.VehicleClasses
{
    internal class VehicleList
    {
        public static List<Vehicle> Generate()
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            Vehicle vehicle;

            vehicle = new Vehicle(VehicleType.car, "Ford", "Ka", "Preto", "PKO1073", 100);
            vehicleList.Add(vehicle);

            vehicle = new Vehicle(VehicleType.car, "Ford", "Fiesta", "Branco", "ANA1073", 120);
            vehicleList.Add(vehicle);

            vehicle = new Vehicle(VehicleType.car, "Chevrolet", "Ônix", "Prata", "PMU89D5", 130);
            vehicleList.Add(vehicle);

            vehicle = new Vehicle(VehicleType.car, "Hiunday", "Creta", "Branco", "PKO13S5", 200);
            vehicleList.Add(vehicle);

            vehicle = new Vehicle(VehicleType.motorcycle, "Honda", "CG150", "Preta", "CSF5648", 60);
            vehicleList.Add(vehicle);

            return vehicleList;
        }
    }
}
