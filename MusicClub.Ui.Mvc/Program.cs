using MusicClub.Dto.Abstractions;
using MusicClub.ApiServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("MusicClubApi", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7061");
});

builder.Services.AddScoped<IActService, ActApiService>();
builder.Services.AddScoped<ILineupService, LineupApiService>();
builder.Services.AddScoped<IPerformanceService, PerformanceApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
