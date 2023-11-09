using CarRental.Shared.Entities;
using CarRental.Shared.Interfaces;

namespace CarRental.Shared.Extensions;

public static class VehicleExtension
{
    public static string VehicleFullName(this IVehicle vehicle)
    {
        return $"{vehicle.Make} {vehicle.Model}";
    }
}