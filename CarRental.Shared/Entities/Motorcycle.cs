using CarRental.Shared.Enums;

namespace CarRental.Shared.Entities;

public class Motorcycle:Vehicle
{
    public int EngineSize { get; set; }
    
    public Motorcycle(
        int id, string registrationNumber, string make, string model,
        double odometer, decimal costPerDay, decimal costPerKm, 
        VehicleType vehicleType, int engineSize,
        VehicleAvailabilityStatus availabilityStatus)
        : base(id, registrationNumber, make, model, odometer, costPerDay, costPerKm, vehicleType, availabilityStatus)
    {
        EngineSize = engineSize;
    }
}