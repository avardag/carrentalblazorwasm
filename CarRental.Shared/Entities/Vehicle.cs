using CarRental.Shared.Enums;

namespace CarRental.Shared.Entities;

public class Vehicle
{
    public int Id { get; }
    public string RegistrationNumber { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public double Odometer { get; set; }
    public decimal CostPerDay { get; set; }
    public decimal CostPerKm { get; set; }
    public VehicleType VehicleType { get; set; }
    public VehicleAvailabilityStatus AvailabilityStatus { get; set; }
    
    public Vehicle(
        string registrationNumber, string make, string model,
        double odometer, decimal costPerDay, decimal costPerKm,
        VehicleType vehicleType, VehicleAvailabilityStatus availabilityStatus)
    {
        RegistrationNumber = registrationNumber;
        Make = make;
        Model = model;
        Odometer = odometer;
        CostPerDay = costPerDay;
        CostPerKm = costPerKm;
        VehicleType = vehicleType;
        AvailabilityStatus = availabilityStatus;
    }
}