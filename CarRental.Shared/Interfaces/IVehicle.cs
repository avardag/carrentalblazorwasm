using CarRental.Shared.Enums;

namespace CarRental.Shared.Interfaces;

public class IVehicle
{
    int Id { get; }
    string RegistrationNumber { get; set; }
    string Make { get; set; }
    string Model { get; set; }
    double Odometer { get; set; }
    decimal CostPerDay { get; set; }
    decimal CostPerKm { get; set; }
    VehicleType VehicleType { get; set; }
    VehicleAvailabilityStatus VehicleStatus { get; set; }
}