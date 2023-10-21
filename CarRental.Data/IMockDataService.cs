using System.Linq.Expressions;
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
}