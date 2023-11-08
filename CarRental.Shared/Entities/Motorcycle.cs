using CarRental.Shared.Enums;
using CarRental.Shared.Interfaces;

namespace CarRental.Shared.Entities;

public class Motorcycle:Vehicle, IMotorcycle
{
    
    public int? EngineSize { get; set; }
    
    // public Motorcycle(
    //     int id, string registrationNumber, string make, string model,
    //     double odometer, decimal costPerDay, decimal costPerKm, 
    //     VehicleType vehicleType, int engineSize,
    //     VehicleAvailabilityStatus availabilityStatus)
    //     : base()
    // {
    //     EngineSize = engineSize;
    // }
}