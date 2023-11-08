using System.ComponentModel.DataAnnotations;
using CarRental.Shared.Entities;
using CarRental.Shared.Enums;
using CarRental.Shared.Interfaces;

namespace CarRentalWasm.Models;


public class VehicleAddFormModel : IVehicle, ICar, IMotorcycle
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
    public void Rent()
    {
        throw new NotImplementedException();
    }

    public void Return(int kmDriven)
    {
        throw new NotImplementedException();
    }

    public int? NumberOfSeats { get; set; }
    public int? NumberOfDoors { get; set; }
    public TransmissionType TransmissionType { get; set; }
    public bool HasRearViewCamera { get; set; }
    public bool HasParkAssist { get; set; }
    public int? EngineSize { get; set; }
}

