using HarveerPortfolio;
using HarveerPortfolio.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<GitHubService>();

builder.Services.AddHttpClient<GitHubService>(client =>
{
    client.DefaultRequestHeaders.UserAgent.ParseAdd("request");
});

builder.Services.AddScoped(sp => new HttpClient());

await builder.Build().RunAsync();
