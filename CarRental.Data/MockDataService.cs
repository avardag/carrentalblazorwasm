using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;
using CarRental.Shared.Entities;
using CarRental.Shared.Enums;
using CarRental.Shared.Extensions;
using CarRental.Shared.Interfaces;

namespace CarRental.Data;

public class MockDataService : IMockDataService
{
    // Properties
    public int NextVehicleId { get; private set; }//private setters
    public int NextPersonId { get; private set; }
    public int NextBookingId { get; private set; }

    // Fields
    private readonly List<IBooking> _bookings;
    private readonly List<Customer> _customers;
    private readonly List<IVehicle> _vehicles;

    // Constructor
    public MockDataService()
    {
        _bookings = new List<IBooking>();
        _customers = new List<Customer>();
        _vehicles = new List<IVehicle>();

        NextVehicleId = 1;
        NextPersonId = 1;
        NextBookingId = 1;

        SeedData();
    }

    public void SeedData()
    {
        // Add some customers
        _customers.Add(new Customer
        {
            Id=1,
            SocialSecurityNumber = "1233321",
            FirstName = "Alex",
            LastName = "Sade",
            DateOfBirth = new DateTime(1982, 12, 10)
        });
        _customers.Add(new Customer
        {
            Id=2,
            SocialSecurityNumber = "2347",
            FirstName = "Sasha",
            LastName = "Pala",
            DateOfBirth = new DateTime(1982, 12, 10)
        });
        _customers.Add(new Customer
        {
            Id=3,
            SocialSecurityNumber = "4959",
            FirstName = "Paco",
            LastName = "Mero",
            DateOfBirth = new DateTime(1982, 12, 10)
        });
        // Add some vehicles
        // _vehicles.Add(new Car(NextVehicleId++, "2344sdf", "Toyota", "Corolla", 2300, 50, 0.35m, VehicleType.Sedan, 4, 4, VehicleAvailabilityStatus.Available, TransmissionType.Automatic));
        //object initilizer syntax instead
        _vehicles.Add(new Car
        {
            Id = NextVehicleId++,
            RegistrationNumber = "wkkdd",
            Make = "Toyota",
            Model = "Corolla",
            Odometer = 12300,
            CostPerDay = 30,
            CostPerKm = 0.4,
            VehicleType = VehicleType.Sedan,
            AvailabilityStatus = VehicleAvailabilityStatus.Available,
            NumberOfSeats = 4,
            NumberOfDoors = 4,
            TransmissionType = TransmissionType.Automatic
        
        });
        _vehicles.Add(new Car
        {
            Id = NextVehicleId++,
            RegistrationNumber = "3ehfkdk",
            Make = "Honda",
            Model = "Civic",
            Odometer = 39000,
            CostPerDay = 24,
            CostPerKm = 0.2,
            VehicleType = VehicleType.Coupe,
            AvailabilityStatus = VehicleAvailabilityStatus.Available,
            NumberOfSeats = 4,
            NumberOfDoors = 2,
            TransmissionType = TransmissionType.Automatic
        
        });
        _vehicles.Add(new Car
        {
            Id = NextVehicleId++,
            RegistrationNumber = "39dnfk",
            Make = "BMW",
            Model = "X6",
            Odometer = 12000,
            CostPerDay = 70,
            CostPerKm = 0.7,
            VehicleType = VehicleType.SUV,
            AvailabilityStatus = VehicleAvailabilityStatus.Available,
            NumberOfSeats = 4,
            NumberOfDoors = 2,
            TransmissionType = TransmissionType.Automatic
        
        });
        _vehicles.Add(new Car
        {
            Id = NextVehicleId++,
            RegistrationNumber = "dkf069",
            Make = "Volvo",
            Model = "XC60",
            Odometer = 45000,
            CostPerDay = 54,
            CostPerKm = 0.56,
            VehicleType = VehicleType.Combi,
            AvailabilityStatus = VehicleAvailabilityStatus.Available,
            NumberOfSeats = 4,
            NumberOfDoors = 4,
            TransmissionType = TransmissionType.Manual
        
        });
        _vehicles.Add(new Motorcycle
        {
            Id = NextVehicleId++,
            RegistrationNumber = "JKL-012",
            Make = "Harley-Davidson", 
            Model= "Sportster",
            Odometer = 5000,
            CostPerDay = 30,
            CostPerKm = 0.3,
            VehicleType = VehicleType.Motorcycle,
            EngineSize = 1200,
            AvailabilityStatus = VehicleAvailabilityStatus.Available  
        });
        // _vehicles.Add(new Motorcycle(NextVehicleId++, "MNO-345", "Yamaha", "R1", 8000, 35, 0.35m, VehicleType.Motorcycle, 235, VehicleAvailabilityStatus.Available));
        //
        // // Add some bookings
        // _bookings.Add(RentVehicle(_vehicles[0].Id, _customers[0].Id));
        // _bookings.Add(RentVehicle(_vehicles[1].Id, _customers[2].Id));
        //update next Ids
        NextVehicleId = _vehicles.Max(v => v.Id) + 1;
        NextPersonId = _customers.Max(c => c.Id) + 1;
        RentVehicle(_vehicles[0].Id, _customers[0].Id);
        RentVehicle(_vehicles[1].Id, _customers[2].Id);
        RentVehicle(_vehicles[4].Id, _customers[1].Id);
    }
    
    private List<T> GetList<T>()
    {
        // reflection to get the type name of T
        var typeName = typeof(T).Name;

        if (typeName == nameof(Booking))
        {
            return _bookings.Cast<T>().ToList();
        }
        if (typeName == nameof(Vehicle))
        {
            return _vehicles.Cast<T>().ToList();
        }
        if (typeName == nameof(Customer))
        {
            return _customers.Cast<T>().ToList();
        }
        else
        {
            throw new ArgumentException("The type is not supported.");
        }
    }

    public List<T> Get<T>(Expression<Func<T, bool>>? predicate)
    {
        var list = GetList<T>();
        // If the predicate is null, return the whole list
        if (predicate == null) return list;
        
        return list.Where(predicate.Compile()).ToList();
    }

    // public List<T> Get<T>(Expression<Func<T, bool>>? predicate = null)
    // {
    //    
    //     // if (typeof(T).Name == nameof(Booking))
    //     if (typeof(T) == typeof(Booking))
    //     {
    //         // return _bookings.Cast<T>().ToList();
    //         // return (predicate == null ? _vehicles : _vehicles.AsQueryable().Where(predicate).ToList()) as List<T>; //gives err
    //         // return predicate == null ? _bookings.Cast<T>().ToList() : _bookings.AsQueryable().Where(predicate).Cast<T>().ToList(); //gives err
    //         // return predicate == null ? _bookings.Cast<T>().ToList() : _bookings.AsQueryable().Where(b=> b.VehicleId < 1).Cast<T>().ToList(); //gives err
    //         // return predicate == null ? _bookings.Cast<T>().ToList() : _bookings.AsQueryable().Cast<T>().Where(predicate).ToList(); //might work
    //         return predicate == null
    //             ? _bookings.Cast<T>().ToList()
    //             : _bookings.AsQueryable().Cast<T>().Where(predicate).ToList(); //works
    //     }
    //     else if (typeof(T) == typeof(Customer))
    //     {
    //         // return expression == null ? _customers.Cast<T>().ToList() : _customers.AsQueryable().Where(expression).Cast<T>().ToList();
    //         return predicate == null
    //             ? _bookings.Cast<T>().ToList()
    //             : _bookings.AsQueryable().Cast<T>().Where(predicate).ToList();
    //     }
    //     else if (typeof(T) == typeof(Vehicle))
    //     {
    //         // return expression == null ? _vehicles.Cast<T>().ToList() : _vehicles.AsQueryable().Where(expression).Cast<T>().ToList();
    //         return predicate == null
    //             ? _bookings.Cast<T>().ToList()
    //             : _bookings.AsQueryable().Cast<T>().Where(predicate).ToList();
    //     }
    //     else
    //     {
    //         throw new ArgumentException("The type is not supported.");
    //     }
    // }

   
    public T? Single<T>(Expression<Func<T, bool>>? expression = null)
    {
        if (expression == null)
        {
            return Get<T>(null).SingleOrDefault();
        }
        return Get<T>(null).SingleOrDefault(expression.Compile());
        // return Get<T>().SingleOrDefault(expression);
        //or use GetList<>
        // then  do list.SingleOrDefault(predicate.Compile());
    }
    // public void Add<T>(T item) //Version 1
    // {
    //     // Get the list of entities based on the type parameter
    //     var list = GetList<T>();
    //
    //     // Add the item to the list
    //     list.Add(item);
    // }
    public void Add<T>(T item) //Version 2
    {
        // Check the type of T and add the item to the corresponding list and update the next id
        if (typeof(T) == typeof(Booking))
        {
            // _bookings.Add(item as Booking);
            // NextBookingId++;
            Booking booking = item as Booking;
            booking.Id = NextBookingId++;
            _bookings.Add(booking);
        }
        else if (typeof(T) == typeof(Customer))
        {
            Customer customer = item as Customer;
            customer.Id = NextPersonId++;
            _customers.Add(customer);
        }
        else if (typeof(T) == typeof(Vehicle))
        {
            Vehicle vehicle = item as Vehicle;
            vehicle.Id = NextVehicleId++;
            _vehicles.Add(vehicle);
        }
        else
        {
            throw new ArgumentException("The type is not supported.");
        }
    }

    public async Task<IBooking>  RentVehicle(int vehicleId, int customerId)
    {
        var vehicle = _vehicles.Find(v => v.Id == vehicleId);
        var customer = _customers.Find(c => c.Id == customerId);

        // Check if the vehicle is available
        if (vehicle != null && vehicle.AvailabilityStatus == VehicleAvailabilityStatus.Available && customer !=null)
        {
            //new booking with the current date as the pickup date and a estimated return date of one week later
            var booking = new Booking
            {
                BookingDate= DateTime.Now,
                PickupDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(7),
                VehicleId = vehicleId,
                CustomerId = customerId,
                Details = new BookingDetails(vehicle.VehicleFullName(),  customer.FullName() , vehicle.RegistrationNumber, false)
            };

            // Add the booking to the list
            Add(booking);
            // Rent the vehicle
            vehicle.Rent();
            //fake API call delay
            await Task.Delay(1500);
            
            return booking;
        }
        else
        {
            // if the vehicle is not available or not found
            return null;
            
        }
    }

    public async Task<IBooking>  ReturnVehicle(int vehicleId, int odometerReading)
    {
         // Find the booking by vehicle id
         var booking = _bookings.Find(b => b.VehicleId == vehicleId);

         // Check if the booking exists
         if (booking != null)
         {
             // Find the vehicle by id
             var vehicle = _vehicles.Find(v => v.Id == vehicleId);

             // Check if the vehicle exists and is rented
             if (vehicle != null && vehicle.AvailabilityStatus == VehicleAvailabilityStatus.Rented)
             {
                 booking.ReturnDate = DateTime.Now;
                 int kmDriven = odometerReading - vehicle.Odometer;
                 //total cost of the booking based on the vehicle's cost per day and cost per km
                 booking.CalculateTotalCost(vehicle, kmDriven);

                 vehicle.Return(odometerReading);
                 await Task.Delay(1500);
                 return booking;
             }
             else
             {
                 // Return null if the vehicle does not exist or is not rented
                 return null;
             }
         }
         else
         {
             // Return null if the booking does not exist
             return null;
         }
    }
}