using CarRental.Shared.Interfaces;

namespace CarRental.Shared.Entities;

public class Booking:IBooking
{
    public int Id { get; }
    public DateTime BookingDate { get; }
    public DateTime PickupDate { get; }
    public DateTime ReturnDate { get; }
    public int VehicleId { get; }
    public int CustomerId { get; }
    public decimal TotalCost { get; private set; }
    
    // public Booking(DateTime pickupDate, DateTime returnDate, int carId, int customerId)
    // {
    //     BookingDate = DateTime.Now;
    //     PickupDate = pickupDate;
    //     ReturnDate = returnDate;
    //     VehicleId = carId;
    //     CustomerId = customerId;
    // }
    
    public void CalculateTotalCost()
    {
        TimeSpan rentalDuration = ReturnDate - PickupDate;
        //TotalCost = (decimal)rentalDuration.Days * vehicle.CostDay + km * vehicle.CostKm;
        TotalCost = 50 * (decimal)rentalDuration.Days;
    }
}