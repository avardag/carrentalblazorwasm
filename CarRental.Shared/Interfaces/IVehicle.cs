using CarRental.Shared.Enums;

namespace CarRental.Shared.Interfaces;

public interface IVehicle
{
    int Id { get; }
    string RegistrationNumber { get; set; }
    string Make { get; set; }
    string Model { get; set; }
    int Odometer { get; set; }
    decimal CostPerDay { get; set; }
    decimal CostPerKm { get; set; }
    VehicleType VehicleType { get; set; }
    VehicleAvailabilityStatus AvailabilityStatus { get; set; }
    void Rent();
    void Return(int kmDriven);
}