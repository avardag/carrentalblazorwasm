using System.Linq.Expressions;
using CarRental.Shared.Enums;
using CarRental.Shared.Interfaces;

namespace CarRental.Data;

public interface IMockDataService
{
    int NextVehicleId { get; }
    int NextPersonId { get; }
    int NextBookingId { get; }

    void SeedData();
    List<T> Get<T>(Expression<Func<T, bool>>? predicate);
    T? Single<T>(Expression<Func<T, bool>>? expression);
    void Add<T>(T item);
    IBooking RentVehicle(int vehicleId, int customerId);
    IBooking ReturnVehicle(int vehicleId, int odometerReading);
    // Default Interface Methods
    public string[] VehicleStatusNames => System.Enum.GetNames(typeof (VehicleAvailabilityStatus));
    public string[] VehicleTypeNames => System.Enum.GetNames(typeof (VehicleType));
    //Retunera en enum konstants värde med hjälp av konstantens namn
    public VehicleType GetVehicleType(string name)
    {
        bool success = Enum.TryParse<VehicleType>(name, out VehicleType result);
        return success ? result : VehicleType.Other;
    }
}