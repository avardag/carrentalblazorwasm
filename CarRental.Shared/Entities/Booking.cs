using CarRental.Shared.Interfaces;

namespace CarRental.Shared.Entities;

public class Booking:IBooking
{
    public int Id { get; set; }
    public DateTime BookingDate { get; set; }
    public DateTime PickupDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public int VehicleId { get; set; }
    public int CustomerId { get; set; }
    public decimal? TotalCost { get; private set; }//if total cost exists, then booking is closed
  
    public void CalculateTotalCost(Vehicle vehicle, int kmDriven)
    {
        TimeSpan rentalDuration = ReturnDate - PickupDate;
        TotalCost = (decimal)rentalDuration.Days * vehicle.CostPerDay + kmDriven * vehicle.CostPerKm;
    }
}