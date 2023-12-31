using CarRental.Shared.Entities;

namespace CarRental.Shared.Interfaces;

public interface IBooking
{
    int Id { get; }
    DateTime BookingDate { get; }
    DateTime PickupDate { get; }
    DateTime ReturnDate { get; set; }
    int VehicleId { get; }
    int CustomerId { get; }
    double? TotalCost { get; }

    void CalculateTotalCost(IVehicle vehicle, int kmDriven);
}