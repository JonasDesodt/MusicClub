using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MusicClub.ApiServices;
using MusicClub.Cms.Blazor;
using MusicClub.Cms.Blazor.Services;
using MusicClub.Cms.Blazor.Controllers;
using MusicClub.Cms.Blazor.Helpers;
using MusicClub.Cms.Blazor.Models.FormModels.Filters;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient("MusicClubApi", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7061");
});

builder.Services.AddScoped<IActService, ActApiService>();
builder.Services.AddScoped<IArtistService, ArtistApiService>();
builder.Services.AddScoped<IImageApiService, ImageApiService>();
builder.Services.AddScoped<ILineupService, LineupApiService>();
builder.Services.AddScoped<IPerformanceService, PerformanceApiService>();
builder.Services.AddScoped<IPersonService, PersonApiService>();

builder.Services.AddScoped<IFilterResultHelpers<ActFilterResult, ActFilterFormModel>, ActFilterResultHelpers>();
builder.Services.AddScoped<IFilterResultHelpers<ArtistFilterResult, ArtistFilterFormModel>, ArtistFilterResultHelpers>();
builder.Services.AddScoped<IFilterResultHelpers<ImageFilterResult, ImageFilterFormModel>, ImageFilterResultHelpers>();
builder.Services.AddScoped<IFilterResultHelpers<LineupFilterResult, LineupFilterFormModel>, LineupFilterResultHelpers>();
builder.Services.AddScoped<IFilterResultHelpers<PerformanceFilterResult, PerformanceFilterFormModel>, PerformanceFilterResultHelpers>();
builder.Services.AddScoped<IFilterResultHelpers<PersonFilterResult, PersonFilterFormModel>, PersonFilterResultHelpers>();

builder.Services.AddScoped<IFilterFormModelHelpers<ActFilterRequest, ActFilterFormModel>, ActFilterFormModelHelpers>();
builder.Services.AddScoped<IFilterFormModelHelpers<ArtistFilterRequest, ArtistFilterFormModel>, ArtistFilterFormModelHelpers>();
builder.Services.AddScoped<IFilterFormModelHelpers<ImageFilterRequest, ImageFilterFormModel>, ImageFilterFormModelHelpers>();
builder.Services.AddScoped<IFilterFormModelHelpers<LineupFilterRequest, LineupFilterFormModel>, LineupFilterFormModelHelpers>();
builder.Services.AddScoped<IFilterFormModelHelpers<PerformanceFilterRequest, PerformanceFilterFormModel>, PerformanceFilterFormModelHelpers>();
builder.Services.AddScoped<IFilterFormModelHelpers<PersonFilterRequest, PersonFilterFormModel>, PersonFilterFormModelHelpers>();

builder.Services.AddScoped<DataController>();

builder.Services.AddScoped<MemoryService>();

builder.Services.AddTransient<JsFunctions>();

var app = builder.Build();

await builder.Build().RunAsync();