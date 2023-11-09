using CarRental.Shared.Entities;

namespace CarRental.Shared.Extensions;

public static class BookingExtension
{
    public static int RentalDurationInDays(this  DateTime startDate, DateTime endDate)
    {
        TimeSpan rentalDuration = endDate - startDate;
        int days = rentalDuration.Days > 0 ? rentalDuration.Days : 1;
        return days;
    }
    public static int RentalDurationInDays(this Booking booking) //extension method for Booking Class
    {
        TimeSpan rentalDuration = booking.ReturnDate - booking.PickupDate;
        int days = rentalDuration.Days > 0 ? rentalDuration.Days : 1;
        return days;
    }
}