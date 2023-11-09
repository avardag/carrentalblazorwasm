using CarRental.Shared.Entities;

namespace CarRental.Shared.Extensions;

public static class PersonExtension
{
    public static string FullName(this Customer person)
    {
        // return person.FirstName + " " + person.LastName;
        return $"{person.FirstName} {person.LastName}";
    }
}