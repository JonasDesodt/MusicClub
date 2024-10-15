using Microsoft.EntityFrameworkCore;
using MusicClub.Dto.Abstractions;
using MusicClub.DbCore;
using MusicClub.DbServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options => 
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("https://localhost:7096")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());

    options.AddPolicy("MusicClub.Ui.Mvc",
        builder => builder
            .WithOrigins("https://localhost:7234")
            .AllowAnyHeader()
            .WithMethods("GET")
            .AllowCredentials());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MusicClubDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IArtistService, ArtistDbService>();
builder.Services.AddScoped<IActService, ActDbService>();
builder.Services.AddScoped<IImageDbService, ImageDbService>();
builder.Services.AddScoped<ILineupService, LineupDbService>();
builder.Services.AddScoped<IPerformanceService, PerformanceDbService>();
builder.Services.AddScoped<IPersonService, PersonDbService>();

var app = builder.Build();

app.UseCors("AllowSpecificOrigin").UseCors("MusicClub.Ui.Mvc");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
