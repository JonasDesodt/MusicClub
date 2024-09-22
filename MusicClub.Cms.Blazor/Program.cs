using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MusicClub.ApiServices;
using MusicClub.Cms.Blazor;
using MusicClub.Dto.Abstractions;
using MusicClub.Cms.Blazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient("MusicClubApi", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7061");
});

builder.Services.AddScoped<IArtistService, ArtistApiService>();
builder.Services.AddScoped<IImageService, ImageApiService>();
builder.Services.AddScoped<IPersonService, PersonApiService>();

builder.Services.AddScoped<DataController>();
builder.Services.AddScoped<MemoryService>();

builder.Services.AddTransient<JsFunctions>();

var app = builder.Build();

await builder.Build().RunAsync();