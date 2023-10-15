namespace CarRental.Shared.Interfaces;


public interface IPerson
{
    int Id {get; set; }
    string SocialSecurityNumber { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    DateTime DateOfBirth { get; set; }
}