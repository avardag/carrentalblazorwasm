using CarRental.Shared.Enums;

namespace CarRentalWasm;

public class ApplicationState
{
    public bool IsMotorcycle { get; set; } = false;
    /// <summary>
    /// The State property with an initial value
    /// </summary>
    public int Value { get; set; } = 0;
    /// <summary>
    /// The event that will be raised for state changed
    /// </summary>
    public event Action OnStateChange;

    /// <summary>
    /// The method that will be accessed by the sender component
    /// to update the state
    /// </summary>
    public void SetValue(int value)
    {
        Value = value;
        NotifyStateChanged();
    }

    /// <summary>
    /// The state change event notification
    /// </summary>
    private void NotifyStateChanged() => OnStateChange?.Invoke();
}