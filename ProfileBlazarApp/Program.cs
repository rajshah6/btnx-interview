using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProfileBlazarApp;
using ProfileBlazarApp.Services;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register HttpClient for the API
builder.Services.AddHttpClient("ProfileApi", client => client.BaseAddress = new Uri("http://localhost:5283")); // ** API is running on port 5283 **

// Register ProfileService using the named HttpClient
builder.Services.AddScoped<ProfileService>(sp =>
    new ProfileService(sp.GetRequiredService<IHttpClientFactory>().CreateClient("ProfileApi")));

await builder.Build().RunAsync();
