namespace CarRental.Shared.Entities;

//needed only for table UI
public class BookingDetails
{
    public bool ShowDetails { get; set; }
    public string VehicleRegistrationNumber { get; set; }
    public string CustomerName { get; set; }
    public string VehicleName { get; set; }

    public BookingDetails(string vehicleName, string customerName, string vehicleRegistrationNumber, bool showDetails)
    {
        VehicleName = vehicleName;
        CustomerName = customerName;
        VehicleRegistrationNumber = vehicleRegistrationNumber;
        ShowDetails = showDetails;
    }
}