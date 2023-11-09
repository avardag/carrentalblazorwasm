using CarRental.Shared.Interfaces;
using CarRental.Shared.Extensions;

namespace CarRental.Shared.Entities;

public class Booking:IBooking
{
    public int Id { get; set; }
    public DateTime BookingDate { get; set; }
    public DateTime PickupDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public int VehicleId { get; set; }
    public int CustomerId { get; set; }
    public double? TotalCost { get; private set; }//if total cost exists, then booking is closed
    //only for form, to be removed for razor Pages project
    public BookingDetails Details { get; set; }
  
    public void CalculateTotalCost(IVehicle vehicle, int kmDriven)
    {
        // int days = this.RentalDurationInDays();
        int days = PickupDate.RentalDurationInDays(ReturnDate);
        TotalCost = days * vehicle.CostPerDay + kmDriven * vehicle.CostPerKm;
    }
}