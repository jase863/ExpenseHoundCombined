using ExpenseHound;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ExpenseHound.Services;
using Microsoft.Extensions.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//TODO: Need to work on this for the API.
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://expensehoundapi20241217152909.azurewebsites.net/") });
builder.Services.AddScoped<ExpenseService>();
builder.Services.AddHttpClient("ExpenseAPI", client =>
{
    client.BaseAddress = new Uri("https://expensehoundapi20241217152909.azurewebsites.net/");
});
builder.Services.AddScoped<AuthService>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

await builder.Build().RunAsync();
