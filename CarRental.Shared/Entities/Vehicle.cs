using CarRental.Shared.Enums;
using CarRental.Shared.Interfaces;

namespace CarRental.Shared.Entities;

public class Vehicle:IVehicle
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
        int id, string registrationNumber, string make, string model,
        double odometer, decimal costPerDay, decimal costPerKm,
        VehicleType vehicleType, VehicleAvailabilityStatus availabilityStatus)
    {
        Id = id;
        RegistrationNumber = registrationNumber;
        Make = make;
        Model = model;
        Odometer = odometer;
        CostPerDay = costPerDay;
        CostPerKm = costPerKm;
        VehicleType = vehicleType;
        AvailabilityStatus = availabilityStatus;
    }
    public void Rent()
    {
        if (AvailabilityStatus == VehicleAvailabilityStatus.Available)
        {
            AvailabilityStatus = VehicleAvailabilityStatus.Rented;
        }
        else
        {
            // Display err message
            Console.WriteLine($"The vehicle with reg num {RegistrationNumber} is not available for rent.");
        }
        
    }

    public void Return(int kmDriven)
    {
        if (AvailabilityStatus == VehicleAvailabilityStatus.Rented)
        {
            AvailabilityStatus = VehicleAvailabilityStatus.Available;
            // Update odometer
            Odometer += kmDriven;
            // Calculate the rental cost ?
            // double rentalCost = CostPerDay + CostPerKm * kmDriven;
        }
        else
        {
            // Display err message
            Console.WriteLine($"The vehicle with reg num {RegistrationNumber} is not rented.");
        }
        
    }
}