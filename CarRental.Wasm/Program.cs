using CarRental.Business;
using CarRental.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CarRentalWasm;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//mudblazor
builder.Services.AddMudServices();
//services
builder.Services.AddScoped<IMockDataService, MockDataService>();//TODO:comment later
builder.Services.AddScoped<BookingProcessor>();
await builder.Build().RunAsync();
