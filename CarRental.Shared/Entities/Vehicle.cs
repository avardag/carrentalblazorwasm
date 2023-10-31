using System.ComponentModel.DataAnnotations;
using CarRental.Shared.Enums;
using CarRental.Shared.Interfaces;

namespace CarRental.Shared.Entities;

public class Vehicle:IVehicle
{
    public int Id { get; set; }
    [Required]
    [StringLength(8, ErrorMessage = "The {0} value cannot exceed {1} characters. ")] 
    public string RegistrationNumber { get; set; }
    [Required]
    [StringLength(24, ErrorMessage = "The {0} value cannot exceed {1} characters. ")] 
    public string Make { get; set; }
    [Required]
    [StringLength(24, ErrorMessage = "The {0} value cannot exceed {1} characters. ")] 
    public string Model { get; set; }
    [Required]
    [Range(10, 1000000000, 
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int Odometer { get; set; }
    [Required]
    [Range(1, 3000)]
    public double CostPerDay { get; set; }
    [Required]
    [Range(0.01, 100)]
    public double CostPerKm { get; set; }
    [Required]
    public VehicleType VehicleType { get; set; }
    [Required]
    public VehicleAvailabilityStatus AvailabilityStatus { get; set; }
    
    //not needed when using object initilizer syntax
    // public Vehicle(
    //     int id, string registrationNumber, string make, string model,
    //     double odometer, double costPerDay, double costPerKm,
    //     VehicleType vehicleType, VehicleAvailabilityStatus availabilityStatus)
    // {
    //     Id = id;
    //     RegistrationNumber = registrationNumber;
    //     Make = make;
    //     Model = model;
    //     Odometer = odometer;
    //     CostPerDay = costPerDay;
    //     CostPerKm = costPerKm;
    //     VehicleType = vehicleType;
    //     AvailabilityStatus = availabilityStatus;
    // }
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

    public void Return(int newOdometerReading)
    {
        if(newOdometerReading <= Odometer)
        {
            throw  new Exception("Odometer reading cannot be less than or equal to the current odometer reading.");
        }
        if (AvailabilityStatus == VehicleAvailabilityStatus.Rented)
        {
            AvailabilityStatus = VehicleAvailabilityStatus.Available;
            // Update odometer
            Odometer = newOdometerReading;
        }
        else
        {
            // Display err message
            Console.WriteLine($"The vehicle with reg num {RegistrationNumber} is not rented.");
        }
        
    }
}