using Blazored.LocalStorage;
using BlazorWasm.BudgetApp;
using BlazorWasm.BudgetApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorageAsSingleton();
builder.Services.AddSingleton<IDbService, LocalStorageService>();
//builder.Services.AddSingleton<IDbService, ApiService>();

builder.Services.AddMudServices();
//builder.Services.AddSingleton<UserInfoState>();
builder.Services.AddScoped<UserInfoState>();
await builder.Build().RunAsync();
