using CarRental.Shared.Interfaces;

namespace CarRental.Shared.Entities;

public class Booking:IBooking
{
    public int Id { get; set; }
    public DateTime BookingDate { get; }
    public DateTime PickupDate { get; }
    public DateTime ReturnDate { get; set; }
    public int VehicleId { get; }
    public int CustomerId { get; }
    public decimal TotalCost { get; private set; }//if total cost exists, then booking is closed
    
    public Booking(DateTime pickupDate, DateTime returnDate, int vehicleId, int customerId)
    {
        BookingDate = DateTime.Now;
        PickupDate = pickupDate;
        ReturnDate = returnDate;
        VehicleId = vehicleId;
        CustomerId = customerId;
    }
    
    public void CalculateTotalCost(Vehicle vehicle, int mDriver)
    {
        TimeSpan rentalDuration = ReturnDate - PickupDate;
        // TotalCost = (decimal)rentalDuration.Days * vehicle.CostDay + km * vehicle.CostKm;
        TotalCost = (decimal)rentalDuration.Days * vehicle.CostPerDay + mDriver * vehicle.CostPerKm;
    }
}