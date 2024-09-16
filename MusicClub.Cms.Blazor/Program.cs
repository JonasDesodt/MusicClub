using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MusicClub.ApiServices;
using MusicClub.Cms.Blazor;
using MusicClub.Dto.Abstractions;
using MusicClub.Cms.Blazor.Services;
using Microsoft.AspNetCore.Components;

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

builder.Services.AddScoped<DataControllerService>();
builder.Services.AddScoped<MemoryService>();

var app = builder.Build();

var navigationManager = app.Services.GetRequiredService<NavigationManager>();
var dataControllerService = app.Services.GetRequiredService<DataControllerService>();
var memoryService = app.Services.GetRequiredService<MemoryService>();

await dataControllerService.HandleLocationChanged(navigationManager.Uri);

navigationManager.RegisterLocationChangingHandler(async args =>
{
    if (memoryService.HasUnsavedData)
    {
        memoryService.NavigationRequest = args.TargetLocation;

        args.PreventNavigation();

        memoryService.RequireConfirmation();
    }
    else
    {
        await dataControllerService.HandleLocationChanged(args.TargetLocation);
    }
});

await app.RunAsync();

//await builder.Build().RunAsync();