using FindPets.Client;
using FindPets.Client.Services;
using FindPets.Shared.Pets;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Add dependencies

builder.Services.AddScoped<IPetService, PetServiceClient>();

await builder.Build().RunAsync();
