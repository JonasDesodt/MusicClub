using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MusicClub.ApiServices;
using MusicClub.Cms.Blazor;
using MusicClub.Dto.Abstractions;
using MusicClub.Cms.Blazor.Services;
using MusicClub.Cms.Blazor.Controllers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient("MusicClubApi", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7061");
});

builder.Services.AddScoped<IActApiService, ActApiService>();
builder.Services.AddScoped<IArtistApiService, ArtistApiService>();
builder.Services.AddScoped<IImageApiService, ImageApiService>();
builder.Services.AddScoped<ILineupApiService, LineupApiService>();
builder.Services.AddScoped<IPerformanceApiService, PerformanceApiService>();
builder.Services.AddScoped<IPersonApiService, PersonApiService>();

builder.Services.AddScoped<DataController>();

builder.Services.AddScoped<MemoryService>();

builder.Services.AddTransient<JsFunctions>();

var app = builder.Build();

await builder.Build().RunAsync();