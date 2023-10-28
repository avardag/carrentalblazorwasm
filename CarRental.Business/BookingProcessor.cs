using CarRental.Data;
using CarRental.Shared.Entities;
using CarRental.Shared.Enums;
using CarRental.Shared.Interfaces;

namespace CarRental.Business;

public class BookingProcessor
{
    private readonly IMockDataService _db;
    public BookingProcessor(IMockDataService db) => _db = db;

    public IEnumerable<IBooking> GetBookings()
    {
        return _db.Get<Booking>(null);
    }

    public IEnumerable<Customer> GetCustomers()
    {
        return _db.Get<Customer>(null);
    }

    public IPerson? GetPerson(string ssn)
    {
        return _db.Single<Customer>(c => c.SocialSecurityNumber == ssn);
    }

    public IEnumerable<IVehicle> GetVehicles(VehicleAvailabilityStatus status = default)
    {
        // return _db.Get<Vehicle>(v => v.AvailabilityStatus == status);
        return _db.Get<Vehicle>(null);
    }

    public IVehicle? GetVehicle(int vehicleId)
    {
            return _db.Single<Vehicle>(v => v.Id == vehicleId); 
    }
    //TODO:implement
    // public IVehicle? GetVehicle(string regNo) { }
    public async Task RentVehicle(int vehicleId, int customerId)
    { 
        await Task.Delay(3000);
        _db.RentVehicle(vehicleId, customerId);
    }

    public IBooking ReturnVehicle(int vehicleId, int newOdometerReading)
    {
            return _db.ReturnVehicle(vehicleId, newOdometerReading); 
    }

    public void AddVehicle(string registrationNumber, string make, string model, int
        odometer, decimal costKm, decimal costDay, VehicleType type)
    {
            _db.Add<Vehicle>(new Vehicle
            {
                RegistrationNumber = registrationNumber,
                Make = make,
                Model = model,
                Odometer = odometer,
                CostPerDay = costDay,
                CostPerKm = costKm,
                AvailabilityStatus = VehicleAvailabilityStatus.Available,
                VehicleType = type
            }); 
        
    }

    public void AddCustomer(Customer newCustomer)
    {
            _db.Add<Customer>(newCustomer);
    }
    // Calling Default Interface Methods
    public string[] VehicleStatusNames => _db.VehicleStatusNames;
    public string[] VehicleTypeNames => _db.VehicleTypeNames;
    public VehicleType GetVehicleType(string name) => _db.GetVehicleType(name);
}