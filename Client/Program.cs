using BCWilliamsDev.Client;
using BCWilliamsDev.Client.Services.JsInterop;
using BCWilliamsDev.Client.Services.JsInterop.Interfaces;
using BCWilliamsDev.Client.Services.UI;
using BCWilliamsDev.Client.Services.UI.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<ContactFormService>();
builder.Services.AddMudServices();
builder.Services.AddHttpClient("BCWilliamsDev.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BCWilliamsDev.ServerAPI"));
await builder.Build().RunAsync();
