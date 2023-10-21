using CarRental.Shared.Enums;

namespace CarRental.Shared.Entities;

public class Car: Vehicle
{
    public int NumberOfSeats { get; set; }
    public int NumberOfDoors { get; set; }
    public TransmissionType TransmissionType { get; set; }
    public bool? HasRearViewCamera { get; set; }
    public bool? HasParkAssist { get; set; }
    
    //not needed when using object initilizer syntax
    // public Car(
    //     int id, string registrationNumber, string make, string model,
    //     double odometer, decimal costPerDay, decimal costPerKm,
    //     VehicleType vehicleType, int numberOfSeats, int numberOfDoors,
    //     VehicleAvailabilityStatus availabilityStatus, TransmissionType transmission)
    //     : base(id, registrationNumber, make, model, odometer, costPerDay, costPerKm, vehicleType, availabilityStatus)
    // {
    //     NumberOfSeats = numberOfSeats;
    //     NumberOfDoors = numberOfDoors;
    //     TransmissionType = transmission;
    // }
}