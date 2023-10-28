using System.ComponentModel.DataAnnotations;
using CarRental.Shared.Interfaces;

namespace CarRental.Shared.Entities;

public class Customer:IPerson
{
    public int Id { get; set; }

    [Required]
    [StringLength(12, ErrorMessage = "SSN must be at least 8 characters long.", MinimumLength = 8)]
    public string SocialSecurityNumber { get; set; } = "";
    [Required]
    [StringLength(64, ErrorMessage = "Name must be at least 2 characters long.", MinimumLength = 2)]
    public string FirstName { get; set; }= "";
    [Required]
    [StringLength(64, ErrorMessage = "Last name must be at least 2 characters long.", MinimumLength = 2)]
    public string LastName { get; set; }= "";
    public DateTime? DateOfBirth { get; set; }
    
}