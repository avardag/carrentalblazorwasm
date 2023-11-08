using CarRental.Shared.Interfaces;
using CarRentalWasm.Components;
using Microsoft.AspNetCore.Components;
using MudBlazor;


namespace CarRentalWasm.Pages;

public partial class VehicleListBase: ComponentBase
{
    [Inject] private IDialogService DialogService { get; set; }
    
    public async Task OpenBookingDialog(IVehicle vehicle)
    {
        var parameters = new DialogParameters<BookingDialog> { { x => x.Vehicle, vehicle } };
        var options = new DialogOptions() { CloseButton = false, MaxWidth = MaxWidth.Medium };

        var dialog = await DialogService.ShowAsync<BookingDialog>("Rent a vehicle", parameters, options);
        
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            //In a real world scenario we would reload the data from the source here since we "removed" it in the dialog already.
            // Guid.TryParse(result.Data.ToString(), out Guid deletedServer);
            // Servers.RemoveAll(item => item.Id == deletedServer);
        }
    }
    public async Task OpenReturnDialog(IVehicle vehicle)
    {
        var parameters = new DialogParameters<ReturnVehicleDialog> { { x => x.Vehicle, vehicle } };
        var dialog = await DialogService.ShowAsync<ReturnVehicleDialog>("Rent a vehicle", parameters);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            //In a real world scenario we would reload the data from the source here since we "removed" it in the dialog already.
            // Guid.TryParse(result.Data.ToString(), out Guid deletedServer);
            // Servers.RemoveAll(item => item.Id == deletedServer);
        }
    }
}