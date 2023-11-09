using CarRental.Shared.Entities;

namespace CarRental.Shared.Extensions;

public static class VehicleExtension
{
    public static string VehicleFullName(this Vehicle vehicle)
    {
        return $"{vehicle.Make} {vehicle.Model}";
    }
}