using CarRental.Shared.Enums;

namespace CarRental.Shared.Interfaces;

public interface ICar
{
    int? NumberOfSeats { get; set; }
    int? NumberOfDoors { get; set; }
    TransmissionType TransmissionType { get; set; }
    bool HasRearViewCamera { get; set; }
    bool HasParkAssist { get; set; }
}