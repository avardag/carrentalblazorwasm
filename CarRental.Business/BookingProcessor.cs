using CarRental.Data;
using CarRental.Shared.Entities;
using CarRental.Shared.Enums;
using CarRental.Shared.Interfaces;

namespace CarRental.Business;

public class BookingProcessor
{
    private readonly IMockDataService _db;
    public BookingProcessor(IMockDataService db) => _db = db;

    public IEnumerable<Booking> GetBookings()
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

    public IEnumerable<IVehicle> GetVehicles(VehicleAvailabilityStatus status)
    {
        // return _db.Get<Vehicle>(v => v.AvailabilityStatus == status);
        return _db.Get<Vehicle>(null);
    }
    public IEnumerable<IVehicle> GetVehicles()
    {
        return _db.Get<Vehicle>(null);
    }

    public IVehicle? GetVehicle(int vehicleId)
    {
            return _db.Single<Vehicle>(v => v.Id == vehicleId); 
    }
    public IVehicle? GetVehicle(string regNo)
    {
        return _db.Single<Vehicle>(v => v.RegistrationNumber == regNo);
    }
    public async Task<IBooking> RentVehicle(int vehicleId, int customerId)
    { 
        var booking =  await _db.RentVehicle(vehicleId, customerId);
        return booking;
    }

    public async Task<IBooking> ReturnVehicle(int vehicleId, int newOdometerReading)
    {
            var booking = await _db.ReturnVehicle(vehicleId, newOdometerReading); 
            return booking;
    }

    public void AddVehicle(bool isMotorcycle, string registrationNumber, string make, string model, int
        odometer, double costKm, double costDay, VehicleType type, int? numberOfDoors, int? numberOfSeats,
        bool hasRearViewCamera, bool hasParkAssist, int? engineSize)
    {
        if (isMotorcycle)
        {
            _db.Add<Vehicle>(new Motorcycle
            {
                RegistrationNumber = registrationNumber,
                Make = make,
                Model = model,
                Odometer = odometer,
                CostPerDay = costDay,
                CostPerKm = costKm,
                AvailabilityStatus = VehicleAvailabilityStatus.Available,
                VehicleType = VehicleType.Motorcycle,
                EngineSize = engineSize
            });
        }
        else
        {
            _db.Add<Vehicle>(new Car
            {
                RegistrationNumber = registrationNumber,
                Make = make,
                Model = model,
                Odometer = odometer,
                CostPerDay = costDay,
                CostPerKm = costKm,
                AvailabilityStatus = VehicleAvailabilityStatus.Available,
                VehicleType = type,
                NumberOfDoors = numberOfDoors,
                NumberOfSeats = numberOfSeats,
                HasParkAssist = hasParkAssist,
                HasRearViewCamera = hasRearViewCamera
            }); 
        }
    }

    public void AddCustomer(Customer newCustomer)
    {
            _db.Add<Customer>(newCustomer);
    }
    //for bookings table
    public void ShowHideDetails(int id)
    {
        var tmpBooking = this.GetBookings().First(f => f.Id == id);
        tmpBooking.Details.ShowDetails = !tmpBooking.Details.ShowDetails;
    }
    // Calling Default Interface Methods
    public string[] VehicleStatusNames => _db.VehicleStatusNames;
    public string[] VehicleTypeNames => _db.VehicleTypeNames;
    public VehicleType GetVehicleType(string name) => _db.GetVehicleType(name);
}