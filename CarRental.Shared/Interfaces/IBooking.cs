namespace CarRental.Shared.Interfaces;

public interface IBooking
{
    int Id { get; }
    DateTime BookingDate { get; }
    DateTime PickupDate { get; }
    DateTime ReturnDate { get; }
    int VehicleId { get; }
    int CustomerId { get; }
    decimal TotalCost { get; }

    void CalculateTotalCost();
}