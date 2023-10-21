using CarRental.Shared.Interfaces;

namespace CarRental.Shared.Entities;

public class Customer:IPerson
{
    public int Id { get; set; }
    public string SocialSecurityNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    
}