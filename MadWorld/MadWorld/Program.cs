using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MadWorld;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

string baseUrl = "http://kgdeykk4pavbklgz63slsvy5wptng7fskukka74yebun3jph35efjoyd.onion";
if (builder.HostEnvironment.IsDevelopment())
{
    baseUrl = "https://localhost:7128";
}

builder.Services.AddHttpClient("MadWorldAPI", client =>
{
    client.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();

