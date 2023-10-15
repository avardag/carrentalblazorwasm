using CarRental.Shared.Enums;

namespace CarRental.Shared.Entities;

public class Car: Vehicle
{
    public Car(
        string registrationNumber, string make, string model,
        double odometer, decimal costPerDay, decimal costPerKm,
        VehicleType vehicleType, 
        VehicleAvailabilityStatus availabilityStatus)
        : base(registrationNumber, make, model, odometer, costPerDay, costPerKm, vehicleType, availabilityStatus)
    {
    }
}